using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Biopoolsengardens
{

    [TestFixture]
    public class Tests
    {

        private IWebDriver _driver;
        private WebDriverWait _wait;


        [SetUp]

        public void TestInit()
        {

            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl("https://www.biopoolsengardens.be/nl");
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

        }

        [Test] 

        public void NavigateToZvemvijversPage()
        {
           
            var example = _wait.Until((d) => d.FindElement(By.LinkText("Zwemvijvers")));
            example.Click();

            var coockieButton = _driver.FindElement(By.ClassName("cookieButton"));
            coockieButton.Click();

            var grid = _driver.FindElement(By.Id("element-141"));
            Actions action = new Actions(_driver);
            action.ClickAndHold(grid).Perform();
            action.Release(grid).Perform();

            

            Thread.Sleep(2000);
            var moveUpArrow = _wait.Until((e) => e.FindElement(By.ClassName("custom-style-33")));


            moveUpArrow.Click();

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
