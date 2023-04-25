using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Biopoolsengardens.Pages
{

    [TestFixture]
    public class Tests
    {

        private IWebDriver _driver;

        private SwimmingPondsMethod _swimmingPonds;

        [SetUp]

        public void TestInit()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _swimmingPonds = new SwimmingPondsMethod(_driver);
        }

        [Test]


        public void NavigateToSwimmingPondsPage()
        {

            _swimmingPonds.Navigate();
            _swimmingPonds.CookieButton.Click();

            _swimmingPonds.Example.Click();

            Actions action = new Actions(_driver);
            action.ClickAndHold(_swimmingPonds.Grid).
                Perform();
            action.
                Release(_swimmingPonds.Grid)
                .Perform();

            Thread.Sleep(2000);

            _swimmingPonds.MoveUpArrowButton.Click();

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
