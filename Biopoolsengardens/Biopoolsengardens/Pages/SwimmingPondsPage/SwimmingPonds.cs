using Biopoolsengardens.Pages.SwimmingPondsPage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Threading;

namespace Biopoolsengardens
{

    [TestFixture]
    public class Tests
    {

        private IWebDriver _driver;
        
        private SwimmingPondsMethod _swimmingPonds;

        [SetUp]

        public void TestInit()
        {
          

           //_driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
           // _driver.Manage().Window.Maximize();


             ChromeOptions options = new ChromeOptions(); //- headlesss ChromeDriver

             options.AddArgument("--headless");


             _driver = new ChromeDriver(options);

            _swimmingPonds = new SwimmingPondsMethod(_driver);
        }

        [Test] 
        [Retry(1)]

        public void NavigateToSwimmingPondsPage()
        {

            _swimmingPonds.Navigate();

            _swimmingPonds.Navigate();
            _swimmingPonds.CookieButton.Click();

            _swimmingPonds.Example.Click();
           
            Actions action = new Actions(_driver);
            action.ClickAndHold(_swimmingPonds.Grid).Perform();
            action.Release(_swimmingPonds.Grid).Perform();

            Thread.Sleep(2000);

            _swimmingPonds.MoveUpArrowButton.Click();

            _swimmingPonds.AssertIsDisplayedGratisOfferLink("VRAAG EEN GRATIS OFFERTE!");
            _swimmingPonds.MakeApointmentAssert("Maak een afspraak");
            _swimmingPonds.BioPoolsAssertLink("Biozwembaden");
            _swimmingPonds.SwimmingPondsAssertLink("Zwemvijvers");
            _swimmingPonds.GardenAndNaturalPondsLink("Tuin- en natuurvijvers");
            _swimmingPonds.SwimmingPoolsLink("Zwembaden");
            _swimmingPonds.RealizationLink("Realisaties");
            _swimmingPonds.ContactLink("Contact");

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
