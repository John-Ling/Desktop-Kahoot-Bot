using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

//
// Backend for kahoot bot
//

namespace Kahoot_Bot
{
    public class Host
    {
        public string ?lobbyID;
        public string botName;
        public static IWebDriver ?driver; // webdriver for browser control

        internal Bot[] bots; // array of all bots in game
        private static ChromeOptions ?options;
        private static ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
        public Host(string ID, string name, int botCount)
        {
            lobbyID = ID;
            botName = name;
            bots = new Bot[botCount];
        }

        public void Initialise_Webdriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            options = new ChromeOptions();
            options.AddArgument("headless");
            driverService.HideCommandPromptWindow = true;
            try
            {
                driver = new ChromeDriver(driverService, options);
            }
            catch (NoSuchElementException)
            {
                throw new NoSuchElementException("Web driver failed. Try adding chromedriver to path");
            }
        }

        public bool Join_Game(int botNumber, bool delay)
        {
            // send a single player bot into a kahoot lobby
            const string GAME_URL = "https://kahoot.it/";
            string numberedBotName = botName + botNumber; // bot name with individual number
            bool joinSuccessful = false;
            var bot = new Bot();
            bot.Status = "Failed";

            if (driver is null)
            {
                Console.WriteLine("Webdriver is null");
                return false;
            }

            driver.Navigate().GoToUrl(GAME_URL);

            try
            {
                // delay workaround since kahoot blocks bots
                // the block seems to be timer based
                int workaroundDelay = 0; // 500 milliseconds
                if (delay == true)
                {
                    Thread.Sleep(workaroundDelay);
                }
                // while this workaround does prevent most bots from being blocked
                // the rate of bot joining reduces slightly and
                // on average 2 bots will fail to join since the join cooldown time appears to fluctuate

                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 3));
                // enter lobby id
                var gamePinTextBox = wait.Until(e => e.FindElement(By.Id("game-input")));
                gamePinTextBox.SendKeys(lobbyID + Keys.Enter);

                // enter name
                var nicknameTextBox = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nickname")));
                nicknameTextBox.SendKeys(numberedBotName + Keys.Enter);

                joinSuccessful = true;
                bot.joinSuccessful = true;
                bot.Status = "Success";
                bot.Name = numberedBotName;
            }
            catch (TimeoutException)
            {
                Console.WriteLine("Program dun goofed");
                bot.Status = "Timeout";
            }

            bots[botNumber] = bot; // add bot to universial list of bots
            return joinSuccessful;
        }

        public List<string> Remove_Options()
        {
            // remove options that are not present when answering (for example a True/False questions wouldn't have the green or yellow button)
            var buttonClasses = new List<string> { "fFONXg", "hZGSQg", "cckBYR", "epOaBR" }; // html classes of the 4 kahoot buttons
            var tmp = new List<string> { "fFONXg", "hZGSQg", "cckBYR", "epOaBR" };

            if (driver is null)
            {
                throw new NullReferenceException();
            }
            // you cannot remove items from a array whilst enumerating through it so two arrays are needed

            foreach (var className in  buttonClasses)
            {
                try
                {
                    driver.FindElement(By.ClassName(className));
                }
                catch (NoSuchElementException)
                {
                    tmp.Remove(className);
                }
            }

            buttonClasses = tmp;
            return buttonClasses;
        }

        public void Answer_Question(List<string> availableAnswers)
        {
            // get a bot to randomly answer a kahoot question
            var random = new Random();
            int numberOfButtons = availableAnswers.Count;
            int index = random.Next(0, numberOfButtons);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            try
            {
                // wait until button is available
                var button = wait.Until(e => e.FindElement(By.ClassName(availableAnswers[index])));
                button.Click();
            }
            catch (TimeoutException)
            {
                Debug.WriteLine("Failed to answer");
            }
        }

        public int Scrape_Score()
        {
            // get current score for a single bot
            var wait = new WebDriverWait(Host.driver, new TimeSpan(0, 0, 3));
            int score = 0;
            try
            {
                const string SCORE_CLASS = "hycjox";
                var scoreElement = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(SCORE_CLASS)));
                score = int.Parse(scoreElement.Text);

            }
            catch (WebDriverTimeoutException)
            {
                Debug.WriteLine("Failed to scrape score");
            }
            return score;
        }

        public void Wait_For_URL_Change()
        {
            // pause until page changes to a new URL
            // example wait until the lobby page changes into the page of the first question 
            if (driver is null)
            {
                throw new NullReferenceException();
            }
            string currentURL = driver.Url;
            while (currentURL == driver.Url) {}
        }

        public void Shutdown_Host()
        {
            // end host and shutdown chromedriver
            if (driver is null)
            {
                throw new NullReferenceException();
            }
            driver.Quit();
        }
    }
}