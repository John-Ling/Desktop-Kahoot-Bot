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
    internal class Host
    {
        private string lobbyID;
        private string botName;
        public IWebDriver driver; // webdriver for browser control
        public List<Bot> bots = new List<Bot>(); // List of objects 
        public ChromeOptions options;
        public ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();

        // constructor class
        public Host(string ID, string name)
        {
            lobbyID = ID;
            botName = name;
            options = new ChromeOptions();
            options.AddArgument("headless");
            driverService.HideCommandPromptWindow = true;
            try // initialise webdriver
            {
                driver = new ChromeDriver(driverService, options);
            }
            catch
            {
                Console.WriteLine("Add chromedriver to path");
                throw new NoSuchElementException();
            }
        }

        public bool Join_Game(int botNumber, bool delay)
        {
            // send a single player bot into a kahoot lobby
            const string GAME_URL = "https://kahoot.it/";
            string numberedBotName = botName + botNumber; // bot name with individual number
            var joinSuccessful = false;
            var bot = new Bot(numberedBotName, joinSuccessful);

            driver.Navigate().GoToUrl(GAME_URL);

            try
            {
                // delay workaround since kahoot blocks bots
                // the block seems to be timer based
                // refreshing the page to create a brief pause seems to be the quickest way to bypass this
                // however this does bring network speeds into consideration
                var workaroundDelay = 500; // 500 milliseconds
                if (delay == true)
                {
                    driver.Navigate().Refresh();
                    Thread.Sleep(workaroundDelay);
                }
                // while this workaround does prevent most bots from being blocked
                // the rate of bot joining reduces slightly and on average 2 bots will fail to join since the join cooldown time appears to fluctuate

                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 3));
                // enter lobby id
                IWebElement gamePinTextBox = wait.Until(e => e.FindElement(By.Id("game-input")));
                gamePinTextBox.SendKeys(lobbyID + Keys.Enter);

                // enter name
                IWebElement nicknameTextBox = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nickname")));
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
            var numberOfButtons = availableAnswers.Count;
            int buttonIndex = random.Next(0, numberOfButtons);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1.5));

            try
            {
                // wait until buton is available
                IWebElement button = wait.Until(e => e.FindElement(By.Id(availableAnswers[buttonIndex])));
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
            var currentURL = driver.Url;
            while (currentURL == driver.Url) { }
        }
    }
}
