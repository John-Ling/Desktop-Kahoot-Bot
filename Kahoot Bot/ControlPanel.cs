using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

// TODO actually implement functinality
// Things to implement 
// - Manual override (make all bots pick a specific option)
// - Remove individual bots
// - End all bots
// - Internal Bot scoreboard
// - Show bot placements
// - Show progress of game using webscraping to get the number of kahoot questions
// - Log top 5 bots and bottom 5 in points and accuracy
// - Add manual editing of each bot via context menu (context menu will open a tab)
// Manual Bot Editing:
//  - See name
//  - Disable (not answer)
//  - Kick (permanent)
//  - See points and accuracy
//  - Set manual override

namespace Kahoot_Bot
{
    public partial class ControlPanel : Form
    {
        private Bitmap fullLogo;
        private Host host;

        public ControlPanel(Host host, ListView listView)
        {
            InitializeComponent();
            this.host = host;

            if (fullLogo is not null)
            {
                fullLogo.Dispose();
            }
            logoFull.SizeMode = PictureBoxSizeMode.StretchImage;
            fullLogo = new Bitmap(@"C:\Users\John\Source\Repos\Kahoot-Bot\Kahoot Bot\logo_full.png");
            logoFull.Image = fullLogo;

            progressBar.Minimum = 0;
            progressBar.Step = 1;

            Initialise_Status_List_View(listView);
        }

        private void ControlPanel_Shown(object sender, EventArgs e)
        {
            var playGameTask = ControlPanel_Shown_Async(sender, e);
        }

        private async Task ControlPanel_Shown_Async(object sender, EventArgs e)
        {
            await Play_Game(host);
        }
        
        private async Task Play_Game(Host host)
        {
            // all bots randomly select an answer to a kahoot question
            // this process continues until the game ends
            await Task.Run(async () =>
            {
                const string ENDING_URL = "https://kahoot.it/ranking";
                var wait = new WebDriverWait(Host.driver, new TimeSpan(0, 0, 3));
                int question = 0;
                if (Host.driver is null)
                {
                    throw new NullReferenceException("Driver is null");
                }
                Debug.WriteLine(Host.driver.Url);
                Debug.WriteLine("Starting game");
                host.Wait_For_URL_Change();

                // repeat until game has ended
                while (Host.driver.Url != ENDING_URL)
                {
                    question++;
                    if (question == 1)
                    {
                        try
                        {
                            // scrape number of questions in game and adjust progress bar
                            Debug.WriteLine("Scraping questions");
                            //var e = Host.driver.FindElement(By.XPath("/html/body/div/div[1]/div/div/main/div[1]/div/div[1]"));
                            const string QUESTION_XPATH = "//*[@id='root']/div[1]/div/div/main/div[3]/div/div[1]";
                            var e = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(QUESTION_XPATH)));
                            //int questionCount = Int32.Parse(e.Text);
                            //progressBar.Maximum = questionCount * 10;
                            //Debug.WriteLine(questionCount);
                            Debug.WriteLine(e.Text);
                        }
                        catch (WebDriverTimeoutException)
                        {
                            //progressBar.Enabled = false;
                            questionLabel.Text = "Failed";
                        }
                    }

                    for (int j = 0; j < 10; j++) // update progress bar
                    {
                        progressBar.PerformStep();
                    }

                    host.Wait_For_URL_Change();
                    Debug.WriteLine(Host.driver.Url);
                    await Task.Delay(1000);
                    Debug.WriteLine($"Removing unavailable buttons");
                    List<string> availableButtons = new List<string>(host.Remove_Options());

                    int i = 0;
                    Debug.WriteLine("Answering question");
                    foreach (var bot in host.Bots)
                    {
                        if (bot.joinSuccessful)
                        {
                            Host.driver.SwitchTo().Window(Host.driver.WindowHandles[i]);
                            host.Answer_Question(availableButtons);
                        }
                        i++;
                    }

                    // this is not a typo
                    Debug.WriteLine("Waiting for URL change 1");
                    host.Wait_For_URL_Change();  // wait until page changes from correct/wrong answer screen
                    Debug.WriteLine("Waiting for URL change 2");
                    host.Wait_For_URL_Change(); // wait until page changes from question loading screen
                }

                await Task.Delay(5000);
                Host.driver.Quit();
                GC.Collect();
            });
        }

        private void Initialise_Status_List_View(ListView listView)
        {
            // update status list view with contents of list view from loading screen
            int playerCount = listView.Items.Count;

            // populate list view
            for (int i = 0; i < playerCount; i++)
            {
                string name = listView.Items[i].Text;
                var item = new ListViewItem(name);
                string status = listView.Items[i].SubItems[1].Text;
                item.SubItems.Add(status);

                statusListView.Items.Add(item);
            }
        }

        private void Initialise_Leaderboard()
        {
            // references data from status list view to ignore bots that have been kicked
            throw new NotImplementedException();
        }
    }
}