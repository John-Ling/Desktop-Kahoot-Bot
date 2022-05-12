using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
//
// Backend for kahoot bot
//

namespace Kahoot_Bot
{
    public struct Bot // single player bot
    {
        public int answersCorrect;
        public int answersWrong;
        public string name;
        public bool joinSuccessful;
        public int score;

        public Bot(string name, int score, bool joinSuccessful)
        {
            this.name = name; 
            this.score = score; 
            this.joinSuccessful = joinSuccessful;
            answersCorrect = 0;
            answersWrong = 0;
        }
    }

    public class Host
    {
        public string ?lobbyID;
        public string ?botName;
        public static IWebDriver ?driver; // webdriver for browser control

        private static List<Bot> bots = new List<Bot>(); // List of all kahoot bots shared across all instances of host
        private static ChromeOptions ?options;
        private static ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();

        public List<Bot> Bots
        {
            get { return bots; }
            set { bots = value; }
        }

        public Host(string ID, string name)
        {
            lobbyID = ID;
            botName = name;
        }

        public void Initialise_Webdriver()
        {
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
            int defaultScore = 0;
            var bot = new Bot(numberedBotName, defaultScore, joinSuccessful);

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
                // refreshing the page to create a brief pause seems to be the quickest way to bypass this
                // however this does bring network speeds into consideration
                int workaroundDelay = 500; // 500 milliseconds
                if (delay == true)
                {
                    driver.Navigate().Refresh();
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
            }
            catch (TimeoutException)
            {
                Console.WriteLine("Program dun goofed");
            }

            bots.Add(bot); // add bot to universial list of bots
            return joinSuccessful;
        }

        public List<string> Remove_Options()
        {
            var buttonsPresent = new List<string> { // these are html ids for the 4 kahoot buttons
                "triangle-button",
                "diamond-button",
                "circle-button",
                "square-button"
            };

            var tmp = new List<string> { // these are html ids for the 4 kahoot buttons
                "triangle-button",
                "diamond-button",
                "circle-button",
                "square-button"
            };

            if (driver is null)
            {
                throw new ArgumentNullException();
            }

            // you cannot remove items from a array whilst enumerating through it so two arrays are needed
            foreach (var buttonID in buttonsPresent)
            {
                try
                {
                    driver.FindElement(By.Id(buttonID));
                }
                catch (NoSuchElementException)
                {
                    tmp.Remove(buttonID);
                }
            }

            buttonsPresent = tmp;
            return buttonsPresent;
        }

        public void Answer_Question(List<string> availableAnswers)
        {
            // get a bot to randomly answer a kahoot question
            var random = new Random();
            int numberOfButtons = availableAnswers.Count;
            int buttonIndex = random.Next(0, numberOfButtons);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1.5));

            try
            {
                // wait until button is available
                var button = wait.Until(e => e.FindElement(By.Id(availableAnswers[buttonIndex])));
                button.Click();
            }
            catch (TimeoutException)
            {
                Console.WriteLine("Failed to answer");
            }
        }

        public void Wait_For_URL_Change()
        {
            // pause until page changes to a new URL
            // example wait until the lobby page changes into the page of the first question 
            if (driver is null)
            {
                throw new ArgumentNullException();
            }
            string currentURL = driver.Url;
            while (currentURL == driver.Url) {}
        }

        public void Shutdown_Host()
        {
            // end host and shutdown chromedriver
            if (driver is null)
            {
                throw new ArgumentNullException();
            }
            driver.Quit();
        }
    }
}
