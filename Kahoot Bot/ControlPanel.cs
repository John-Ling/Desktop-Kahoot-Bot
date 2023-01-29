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

            //Update_Status_ListView();
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
                int questionCount = Scrape_Question_Count();
                Invoke(new Action(() =>
                {
                    progressBar.Minimum = 0;
                    if (questionCount <= 0)
                    {
                        progressBar.Maximum = 0;
                        questionLabel.Text = "Error";
                    }
                    else
                    {
                        progressBar.Maximum = questionCount * 10;
                    }
                    progressBar.Step = 1;
                }));
                
                while (Host.driver.Url != ENDING_URL)
                {
                    question++;
                    if (questionCount > 0)
                    {
                        string currentQuestion = question.ToString() + " of " + questionCount.ToString();
                        Invoke(new Action(() => {
                            questionLabel.Text = currentQuestion;
                            for (int i = 0; i < 10; i++) 
                            {
                                progressBar.PerformStep(); 
                            }
                            }));
                    }
                    else
                    {
                        Invoke(new Action(() => questionLabel.Text = "Error" ));
                    }

                    host.Wait_For_URL_Change();
                    // wait until answer blocks are revealed

                    var availableButtons = new List<string>(host.Remove_Options());

                    for (int i = 0; i < host.bots.Length; i++)
                    {
                        Host.driver.SwitchTo().Window(Host.driver.WindowHandles[i]);
                        if (host.bots[i].joinSuccessful)
                        {
                            host.Answer_Question(availableButtons);
                        }
                    }

                    host.Wait_For_URL_Change();
                    // wait until timer runs out or all players submit an answer
                    string nameTemplate = host.botName;
                    for (int i = 0; i < host.bots.Length; i++)
                    {
                        // update score for each bot
                        string botName = nameTemplate + i; // form name of current bot
                        Host.driver.SwitchTo().Window(Host.driver.WindowHandles[i]); // switch tabs
                        int score = host.Scrape_Score();
                        Debug.WriteLine($"Setting {botName}'s score to {score}");
                        int updateIndex = -1; // location of bot within array

                        // find index of bot
                        for (int j = 0; j < host.bots.Length; j++)
                        {
                            if (host.bots[j].Name == botName)
                            {
                                Debug.WriteLine($"{botName} is found at {j}");
                                updateIndex = j;
                                break;
                            }
                        }

                        if (updateIndex != -1)
                        {
                            host.bots[updateIndex].score = score;
                        }

                    }
                    Update_Leaderboard();
                    host.Wait_For_URL_Change();
                    // wait until game starts next question
                }
                Debug.WriteLine("Game has ended. Thanks for using my software! :)");
                await Task.Delay(3000);
                Host.driver.Quit();
                GC.Collect();
            });
        }

        private int Scrape_Question_Count()
        {
            // scrapes number of questions within kahoot game
            var wait = new WebDriverWait(Host.driver, new TimeSpan(0, 0, 3));
            int count = 0;
            try
            {
                // scrape number of questions in game and adjust progress bar
                Debug.WriteLine("Scraping questions");
                const string QUESTION_CLASS = "hAQMGb";
                var questionElement = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(QUESTION_CLASS)));

                // process string to get maximum number of questions
                count = int.Parse(questionElement.Text.Substring(5));
            }
            catch (WebDriverTimeoutException)
            {
                count = -1;
            }
            return count;
        }

        private void Update_Leaderboard()
        {
            // references data from status list view to ignore bots that have been kicked
            // sort all bots by their score
            if (leaderboard.Items.Count == 0)
            {
                int placement = 0;
                // initialise leaderboard if empty
                foreach(var bot in host.bots)
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
                // sort in ascending order
                // minor bug that puts bots that have equal scores in wrong positions
                // potential solution to check in kahoot which bot is ahead 
                Array.Sort(host.bots, (x, y) => y.score.CompareTo(x.score));
                leaderboard.Invoke((MethodInvoker)delegate
                {
                   for (int i = 0; i < leaderboard.Items.Count; i++)
                    {
                        leaderboard.Items[i].SubItems[1].Text = host.bots[i].Name;
                        leaderboard.Items[i].SubItems[2].Text = host.bots[i].score.ToString();
                    }
                });
                
            }
            foreach (var bot in host.bots)
            {
                Debug.WriteLine(bot.Name + ": " + bot.score);
            }
        }
    }
}