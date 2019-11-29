using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace Biopoolsengardens
{
    class Galery
    {
        [TestFixture]

        public class NavigateToGalery
        {

            private IWebDriver _driver;
            private WebDriverWait _wait;

            [SetUp]

            public void SetUp()
            {

                _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                _driver.Navigate().GoToUrl("https://www.biopoolsengardens.be/nl");
                _driver.Manage().Window.Maximize();
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));


            }


            [Test]
            [Retry(2)]

            public void NavigateGalery()
            {
                var coockieButton = _driver.FindElement(By.ClassName("cookieButton"));
                coockieButton.Click();

                var galeryButton = _driver.FindElement(By.LinkText("Realisaties"));
                galeryButton.Click();

                var firstPicture = _driver.FindElement(By.Id("element-497"));
                firstPicture.Click();

                Actions actions = new Actions(_driver);
                actions.ClickAndHold(firstPicture).Perform();

                var buttonArrowRight = _driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/button[2]"));
                buttonArrowRight.Click();

                for (int i = 0; i <= 15; i++)
                {
                    buttonArrowRight.Click();
                }

                var moveUpArrow = _wait.Until((e) => e.FindElement(By.ClassName("custom-style-33")));

            }

            [TearDown]
            public void TearDown()
            {
                var name = TestContext.CurrentContext.Test.Name;
                var result = TestContext.CurrentContext.Result.Outcome;

                if (result != ResultState.Success)
                {
                    var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                    var directory = Directory.GetCurrentDirectory();

                    var fullPath = Path.GetFullPath("..\\..\\..\\Screenshots");

                    screenshot.SaveAsFile(fullPath + name + ".png", ScreenshotImageFormat.Png);

                }
                _driver.Quit();


            }

        }


    }
}
