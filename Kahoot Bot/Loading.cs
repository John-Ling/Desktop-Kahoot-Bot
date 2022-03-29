using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;

// TODO add Control Panel functionality


namespace Kahoot_Bot
{
    public partial class Loading : Form
    {
        public Loading(string lobbyID, string botName, uint botNumber)
        {
            InitializeComponent();
            loadingBar.Visible = true;
            loadingBar.Minimum = 0;
            loadingBar.Maximum = (int)botNumber * 10;
            loadingBar.Step = 1;

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

        private void Join_Kahoot_Bot(string lobbyID, string botName, uint botNumber)
        {
            void _Update_Label(string message)
            {
                Invoke(new Update_Indicator_Label_Delegate(Update_Indicator_Label), message);
            }

            void _Update_Bar()
            {
                Invoke(new Update_Progress_Bar_Delegate(Update_Progress_Bar));
            }

            // this method is placed on a different thread to prevent stuttering
            // invocations update the UI on the main thread to prevent errors
            Host host = new Host(lobbyID, botName);

            var updatedBotNumber = botNumber;
            var joinSuccessful = false;

            for (int i = 0; i < botNumber; i++)
            {
                _Update_Label($"Sending bot {i}...");
                if (i != 0)
                {
                    ((IJavaScriptExecutor)host.driver).ExecuteScript("window.open();"); // execute javascript command to open new tab
                    host.driver.SwitchTo().Window(host.driver.WindowHandles[i]);
                }
                if (i < 6)
                {
                    joinSuccessful = host.Join_Game(botNumber: i, delay: false);
                }
                else
                {
                    // apply delay
                    joinSuccessful = host.Join_Game(botNumber: i, delay: true);
                }

                if (joinSuccessful) 
                {
                    _Update_Label("Join successful");
                }
                else
                {
                    _Update_Label("Join failed");
                    updatedBotNumber--;
                }
                _Update_Bar();
            }

            botNumber = updatedBotNumber;
            Thread.Sleep(1000);
            _Update_Label("Waiting for game to start...");
            // wait for game to begin
            host.Wait_For_URL_Change();
            Invoke(new Update_Indicator_Label_Delegate(Update_Indicator_Label), "Game has Started");
            host.Wait_For_URL_Change();

            // answer questions until game ends
            const string ENDING_URL = "https://kahoot.it/v2/ranking";
            while (host.driver.Url != ENDING_URL)
            {
                host.Wait_For_URL_Change();
                Invoke(new Update_Indicator_Label_Delegate(Update_Indicator_Label), "Answering Question...");
                Thread.Sleep(1000);
                List<string> availableButtons = new List<string>(host.Remove_Options());
                int i = 0;
                foreach (var bot in host.bots)
                {
                    if (bot.joinSuccessful)
                    {
                        host.driver.SwitchTo().Window(host.driver.WindowHandles[i]);
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
            host.driver.Quit();
            GC.Collect();
        }
    }
}
