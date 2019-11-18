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
    public class TestsPoolsPage
    {

        private IWebDriver _driver;
        private WebDriverWait _wait;


        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl("https://www.biopoolsengardens.be/nl");
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

        }

        [Test]
        public void NavigatetoPoolsPage()
        {
            var arrowButton = _driver.FindElement(By.ClassName("shuttle-Widget"));
            arrowButton.Click();
            Thread.Sleep(2000);

            var coockieButton = _driver.FindElement(By.ClassName("cookieButton"));
            coockieButton.Click();

            var example = _wait.Until((d) => d.FindElement(By.XPath("//*[@id='grid_9a94f10022']/div[1]")));
            example.Click();

            var contactButton = _driver.FindElement(By.Id("element-280"));
            Actions actions = new Actions(_driver);

            actions.MoveToElement(contactButton).Perform();


            var moveUpArrow = _wait.Until((e) => e.FindElement(By.ClassName("custom-style-33")));

            moveUpArrow.Click();

        }

        
            [TearDown]
        public void TearDown()
        {
            var name = TestContext.CurrentContext.Test.Name;
            var result = TestContext.CurrentContext.Result.Outcome;

            if (result == ResultState.Success)
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