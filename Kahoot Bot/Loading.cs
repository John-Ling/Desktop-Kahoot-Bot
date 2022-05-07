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

/// <summary>
/// TODO
/// Connect Loading.cs to ControlPanel.cs when game begins
/// </summary>

namespace Kahoot_Bot
{
    public partial class Loading : Form
    {
        private Bitmap _fullLogo;
        private bool killBot = false;
        private int botCount;
        private Host host;

        public Loading(string lobbyID, string botName, int botCount)
        {
            InitializeComponent();
            this.botCount = botCount;
            host = new Host(lobbyID, botName);

            loadingBar.Visible = true;
            loadingBar.Minimum = 0;
            loadingBar.Maximum = botCount * 10;
            loadingBar.Step = 1;

            if (_fullLogo is not null)
            {
                _fullLogo.Dispose();
            }
            logoFull.SizeMode = PictureBoxSizeMode.StretchImage;
            _fullLogo = new Bitmap(@"C:\Users\John\Source\Repos\Kahoot-Bot\Kahoot Bot\logo_full.png");
            logoFull.Image = _fullLogo; 
            indicatorLbl.Visible = true;
            indicatorLbl.Text = "";
        }

        private void Shown_Event(object sender, EventArgs e)
        {
            // start separate task to join host into game
            Task joinGameTask = Shown_Event_Async(sender, e);
        }

        private async Task Shown_Event_Async(object sender, EventArgs e)
        {
            // wait until the game begins
            await Join_Game(host, botCount);
        }

        private delegate void Update_Progress_Bar_Delegate();
        private void Update_Progress_Bar()
        {
            for (int i = 0; i < 10; i++)
            {
                loadingBar.PerformStep();
            }
        }

        private delegate void Update_List_View_Delegate(string botName, string message);
        private void Update_List_View(string botName, string message)
        {
            var item = new ListViewItem(botName);
            item.SubItems.Add(message);
            botsJoinedList.Items.Add(item);
        }

        private async Task Join_Game(Host host, int botCount)
        {
            void _Update_Label(string message)
            {
                Invoke(new Action(() => indicatorLbl.Text = message));
            }
            int finalBotCount = 0;
            int botsJoinedSoFar = 0;
            bool joinSuccessful = false;
            string numberedBotName;
            string joinSuccessfulString;
            await Task.Run(() =>
            {
                host.Initialise_Webdriver();

                if (Host.driver is null)
                {
                    throw new ArgumentNullException("Driver is null");
                }

                _Update_Label("Loading...");
                for (int i = 0; i < botCount; i++)
                {
                    joinSuccessfulString = "Success";
                    if (killBot)
                    {
                        break;
                    }
                    if (i != 0)
                    {
                        ((IJavaScriptExecutor)Host.driver).ExecuteScript("window.open();"); // execute javascript command to open new tab
                        Host.driver.SwitchTo().Window(Host.driver.WindowHandles[i]);
                    }
                    if (i < 6)
                    {
                        joinSuccessful = host.Join_Game(botNumber: i, delay: false);
                    }
                    else
                    {
                        joinSuccessful = host.Join_Game(botNumber: i, delay: true);
                    }

                    if (!joinSuccessful)
                    {
                        joinSuccessfulString = "Failed";
                        botCount--;
                    }
                    numberedBotName = Host.botName + i;
                    Invoke(new Update_List_View_Delegate(Update_List_View), numberedBotName, joinSuccessfulString);
                    Invoke(new Update_Progress_Bar_Delegate(Update_Progress_Bar));
                    botsJoinedSoFar++;
                }
                if (killBot)
                {
                    host.Shutdown_Host();
                    Invoke(new Action(() => Application.Exit()));
                }
                else
                {
                    Thread.Sleep(1000);
                    finalBotCount = botCount;
                    _Update_Label("Waiting for game to start...");
                    // wait for game to begin
                    host.Wait_For_URL_Change();
                    //Invoke(new Update_Indicator_Label_Delegate(Update_Indicator_Label), "Game has Started");
                }
            });
        }

        private void killButton_Click(object sender, EventArgs e)
        {
            killBot = true;
        }

        
    }
}
