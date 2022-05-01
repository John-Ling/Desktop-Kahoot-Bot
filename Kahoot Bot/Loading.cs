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
/// Nothing urgent at the moment
/// </summary>

namespace Kahoot_Bot
{
    public partial class Loading : Form
    {
        private Bitmap _fullLogo;
        private bool killBot = false;
        public Loading(string lobbyID, string botName, int botNumber)
        {
            InitializeComponent();
            loadingBar.Visible = true;
            loadingBar.Minimum = 0;
            loadingBar.Maximum = botNumber * 10;
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
            Thread kahootBotThread = new Thread(() => Join_Kahoot_Bot(lobbyID, botName, botNumber));
            kahootBotThread.IsBackground = true;
            kahootBotThread.Start();
        }

        private delegate void Update_Indicator_Label_Delegate(string message);
        private void Update_Indicator_Label(string message)
        {
            // update the indicator label on the main thread
            indicatorLbl.Text = message;
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

        private void Join_Kahoot_Bot(string lobbyID, string botName, int botCount)
        {
            void _Update_Label(string message)
            {
                Invoke(new Update_Indicator_Label_Delegate(Update_Indicator_Label), message);
            }
           
            // this method is placed on a different thread to prevent stuttering
            // invocations update the UI on the main thread to prevent errors
            Host host = new Host(lobbyID, botName);

            if (Host.driver is null)
            { 
                return;
            }

            int finalBotCount = 0;
            int botsJoinedSoFar = 0;
            bool joinSuccessful = false;
            string numberedBotName;
            string joinSuccessfulString;
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
                numberedBotName = botName + i;
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
                Hide();
                //Invoke(new Update_Indicator_Label_Delegate(Update_Indicator_Label), "Game has Started");
            }
            

            /*
            const string ENDING_URL = "https://kahoot.it/v2/ranking";
            while (Host.driver.Url != ENDING_URL)
            {
                host.Wait_For_URL_Change();
                Invoke(new Update_Indicator_Label_Delegate(Update_Indicator_Label), "Answering Question...");
                Thread.Sleep(1000);
                List<string> availableButtons = new List<string>(host.Remove_Options());
                int i = 0;
                foreach (var bot in Host.bots)
                {
                    if (bot.joinSuccessful)
                    {
                        Host.driver.SwitchTo().Window(Host.driver.WindowHandles[i]);
                        host.Answer_Question(availableButtons);
                    }
                    i++;
                }
                Invoke(new Update_Indicator_Label_Delegate(Update_Indicator_Label), "Completed Answering");
                host.Wait_For_URL_Change();
                host.Wait_For_URL_Change();
            }

            Invoke(new Update_Indicator_Label_Delegate(Update_Indicator_Label), "Game has Finished");
            Thread.Sleep(5000);
            Host.driver.Quit();
            GC.Collect();
            */
        }

        private void killButton_Click(object sender, EventArgs e)
        {
            killBot = true;
        }
    }
}
