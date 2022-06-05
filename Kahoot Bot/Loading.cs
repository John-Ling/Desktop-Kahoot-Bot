using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

/// <summary>
/// </summary>

namespace Kahoot_Bot
{
    public partial class Loading : Form
    {
        private Bitmap fullLogo;
        private bool kickBot = false;
        private int botCount;
        private Host host;

        public Loading(string lobbyID, string botName, int botCount)
        {
            InitializeComponent();
            this.botCount = botCount;
            host = new Host(lobbyID, botName, botCount);

            loadingBar.Visible = true;
            loadingBar.Minimum = 0;
            loadingBar.Maximum = botCount * 10;
            loadingBar.Step = 1;

            if (fullLogo is not null)
            {
                fullLogo.Dispose();
            }
            logoFull.SizeMode = PictureBoxSizeMode.StretchImage;
            fullLogo = new Bitmap(@"C:\Users\John\Source\Repos\Kahoot-Bot\Kahoot Bot\logo_full.png");
            logoFull.Image = fullLogo; 
            indicatorLbl.Visible = true;
            indicatorLbl.Text = "";
        }

        private void Loading_Shown(object sender, EventArgs e)
        {
            // start separate task to join host into game
            var joinGameTask = Loading_Shown_Async(sender, e);
        }

        private async Task Loading_Shown_Async(object sender, EventArgs e)
        {
            // wait until the game begins
            await Join_Game(host, botCount);
            Hide();
            var controlPanel = new ControlPanel(host);
            controlPanel.Show();
        }

        private async Task Join_Game(Host host, int botCount)
        {
            void Update_Label(string message)
            {
                Invoke(new Action(() => indicatorLbl.Text = message));
            }

            int finalBotCount = 0;
            int botsJoinedSoFar = 0;
            bool joinSuccessful = false;
            string numberedBotName;
            string statusString;

            await Task.Run(async () =>
            {
                host.Initialise_Webdriver();
                bool completed = false;

                if (Host.driver is null)
                {
                    throw new NullReferenceException("Driver is null");
                }
                Debug.WriteLine(Host.driver.Url);
                Update_Label("Loading...");
                Debug.WriteLine("Loading...");
                for (int i = 0; i < botCount; i++)
                {
                    statusString = "Success";
                    if (kickBot)
                    {
                        break;
                    }
                    if (i != 0)
                    {
                        Debug.WriteLine("Opening new tab");
                        ((IJavaScriptExecutor)Host.driver).ExecuteScript("window.open();"); // execute javascript command to open new tab
                        Host.driver.SwitchTo().Window(Host.driver.WindowHandles[i]);
                    }
                    Debug.WriteLine("Joining game");
                    if (i < 6)
                    {
                        joinSuccessful = host.Join_Game(botNumber: i, delay: false);
                    }
                    else
                    {
                        Debug.WriteLine("Applying delay");
                        joinSuccessful = host.Join_Game(botNumber: i, delay: true);
                    }

                    if (!joinSuccessful)
                    {
                        statusString = "Failed";
                    }
                    Debug.WriteLine(statusString);
                    numberedBotName = host.botName + i;
                    Invoke(new Action(() => // update list view with bot name and status
                    {
                        var item = new ListViewItem(numberedBotName);
                        item.SubItems.Add(statusString);
                        botsJoinedList.Items.Add(item);
                    }));
                    Invoke(new Action(() => // move progress bar
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            loadingBar.PerformStep();
                        }
                    }));
                    botsJoinedSoFar++;
                }
                
                if (kickBot)
                {
                    host.Shutdown_Host();
                    Invoke(new Action(() => Application.Exit()));
                }
                else
                {
                    if (Host.driver.Url == "https://kahoot.it/start")
                    {
                        // end immediately and load control panel
                    }
                    else
                    {
                        await Task.Delay(1000);
                        finalBotCount = botCount;
                        Update_Label("Waiting for game to start...");
                        Debug.WriteLine("Waiting for game to begin");
                        // wait for game to begin
                        host.Wait_For_URL_Change();
                        Update_Label("Loading control panel...");
                    }
                }
            });
        }

        private void kickButton_Click(object sender, EventArgs e)
        {
            kickBot = true;
        }
    }
}
