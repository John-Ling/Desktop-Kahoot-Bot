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
// - Log top 5 bots and bottom 5 in points and accuracy
// - Add manual editing of each bot via context menu (context menu will open a tab)
// Manual Bot Editing:
//  - See name
//  - Disable (not answer)
//  - Kick (permanent)
//  - See points and accuracy
//  - Set manual override
// Fix error System.Reflection.TargetParameterCountException in Update_Leaderboard()

namespace Kahoot_Bot
{
    public partial class ControlPanel : Form
    {
        private Bitmap fullLogo;
        private Host host;

        public ControlPanel(Host host)
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

            progressBar.Minimum = 0; // maximum will be set up later in Play_Game()
            progressBar.Step = 1;

            Update_Status_ListView();
            Update_Leaderboard();
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
                if (Host.driver is null)
                {
                    throw new NullReferenceException("Driver is null");
                }
                Debug.WriteLine(Host.driver.Url);
                Debug.WriteLine("Starting game");
                host.Wait_For_URL_Change();

                // repeat until game has ended
                int question = 0;
                int questionCount = 0;
                bool scrapeSuccessful = true;
                while (Host.driver.Url != ENDING_URL)
                {
                    question++;
                    if (question == 1)
                    {
                        scrapeSuccessful = Scrape_Question_Progress(ref questionCount);
                    }
                    string currentQuestion = "Failed";
                    if (scrapeSuccessful)
                    {
                        currentQuestion = question.ToString() + " of " + questionCount.ToString();
                    }
                    
                    Invoke(new Action(() => questionLabel.Text = currentQuestion));

                    Invoke(new Action(() =>
                    {
                       for (int i = 0; i < 10; i++)
                       {
                           progressBar.PerformStep();
                       }
                   }));

                    host.Wait_For_URL_Change();
                    // wait until answer blocks are revealed

                    await Task.Delay(1000); // potentially adjust
                    Debug.WriteLine($"Removing unavailable buttons");
                    var availableButtons = new List<string>(host.Remove_Options());

                    int i = 0;
                    Debug.WriteLine("Answering question");
                    foreach (var bot in host.Bots)
                    {
                        Host.driver.SwitchTo().Window(Host.driver.WindowHandles[i]);
                        if (bot.joinSuccessful)
                        {
                            host.Answer_Question(availableButtons);
                        }
                        i++;
                    }

                    host.Wait_For_URL_Change();
                    // wait until timer runs out or all players submit an answer

                    for (int j = 0; j < host.Bots.Count; j++)
                    {
                        var bot = host.Bots[j];
                        Host.driver.SwitchTo().Window(Host.driver.WindowHandles[j]);
                        if (bot.joinSuccessful)
                        {
                            // attempt to scrape score for bot
                            const string SCORE_XPATH = "/html/body/div/div[1]/div/div/div/div[5]/div[2]";
                            try
                            {
                                var scoreElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SCORE_XPATH)));
                                int score = int.Parse(scoreElement.Text);
                                bot.score = bot.score + score;
                            }
                            catch (WebDriverTimeoutException)
                            {
                                Debug.WriteLine("Failed to scrape score");
                                // do not adjust score for bot
                            }
                        }
                        j++;
                    }
                    Update_Leaderboard();
                    host.Wait_For_URL_Change(); 
                    // wait until game starts next question
                }

                await Task.Delay(5000);
                Host.driver.Quit();
                GC.Collect();
            });
        }

        private bool Scrape_Question_Progress(ref int questionCount)
        {
            var wait = new WebDriverWait(Host.driver, new TimeSpan(0, 0, 3));
            bool scrapeSuccessful = false;
            try
            {
                // scrape number of questions in game and adjust progress bar
                Debug.WriteLine("Scraping questions");
                const string QUESTION_XPATH = "//*[@id='root']/div[1]/div/div/main/div[3]/div/div[1]";
                var questionElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(QUESTION_XPATH)));

                // process string to get maximum number of questions
                string tmp = questionElement.Text.Substring(5);
                int maxQuestions = int.Parse(tmp);
                questionCount = maxQuestions;
                Invoke(new Action(() => progressBar.Maximum = maxQuestions * 10));
                scrapeSuccessful = true;
            }
            catch (WebDriverTimeoutException)
            {
                Invoke(new Action(() => progressBar.Maximum = 0));
                questionCount = 0;
            }

            return scrapeSuccessful;
        }

        private void Update_Status_ListView()
        {
            if (statusListView.Items.Count == 0)
            {
                // populate list view if not initialised yet
                foreach (var bot in host.Bots)
                {
                    string name = bot.Name;
                    string status = bot.Status;
                    var item = new ListViewItem(name);
                    item.SubItems.Add(status);
                    statusListView.Items.Add(item);
                }
            }
            else
            {
                // update list view
                for (int i = 0; i < statusListView.Items.Count; i++)
                {
                    statusListView.Items[i].SubItems[1].Text = host.Bots[i].Status;
                }
            }
           
        }

        private void Update_Leaderboard()
        {
            // references data from status list view to ignore bots that have been kicked
            // sort all bots by their score
            if (leaderboard.Items.Count == 0)
            {
                int placement = 0;
                // initialise leaderboard if empty
                foreach(var bot in host.Bots)
                {
                    placement++;
                    string name = bot.Name;
                    int score = bot.score;
                    var item = new ListViewItem(placement.ToString());
                    item.SubItems.Add(name);
                    item.SubItems.Add(score.ToString());
                    leaderboard.Items.Add(item);
                }
            }
            else
            {
                // update leaderboard and sort by score ascending order using bubble sort
                bool swaps;
                int upperBound = leaderboard.Items.Count - 1;
                do
                {
                    swaps = false;
                    for (int i = 0; i < upperBound; i++)
                    {
                        Debug.WriteLine("Getting scores");
                        int score1 = (int)Invoke(new Func<int, int>(i => int.Parse(leaderboard.Items[i].SubItems[2].Text)));
                        int score2 = (int)Invoke(new Func<int, int>(i => int.Parse(leaderboard.Items[i + 1].SubItems[2].Text)));
                        if (score1 < score2)
                        {
                            // swap
                            Debug.WriteLine("Swapping");
                            string tmp1 = leaderboard.Items[i].SubItems[1].Text;
                            string tmp2 = leaderboard.Items[i].SubItems[2].Text;
                            Debug.WriteLine("Invoking");
                            Invoke(new Action<int>(i =>
                            {
                                leaderboard.Items[i].SubItems[1].Text = leaderboard.Items[i + 1].SubItems[1].Text;
                                leaderboard.Items[i].SubItems[2].Text = leaderboard.Items[i + 1].SubItems[2].Text;
                                leaderboard.Items[i + 1].SubItems[1].Text = tmp1;
                                leaderboard.Items[i + 1].SubItems[2].Text = tmp2;
                            }));
                            swaps = true;
                        }
                        Debug.WriteLine("Continuing");
                    }
                    Debug.WriteLine("Decrementing");
                    upperBound--;
                } while (swaps);
            }
        }
    }
}