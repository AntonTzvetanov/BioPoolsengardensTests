using Biopoolsengardens.Pages.SwimmingPondsPage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
        private SwimmingPondsMethod _swimmingPonds;

        [SetUp]

        public void TestInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            
            _driver.Manage().Window.Maximize();
          
        }

        [Test] 
        [Retry(1)]

        public void NavigateToSwimmingPondsPage()
        {

            _swimmingPonds = new SwimmingPondsMethod(_driver);

            _swimmingPonds.Navigate();
            _swimmingPonds.CookieButton.Click();

            _swimmingPonds.Example.Click();
           
            Actions action = new Actions(_driver);
            action.ClickAndHold(_swimmingPonds.Grid).Perform();
            action.Release(_swimmingPonds.Grid).Perform();

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
