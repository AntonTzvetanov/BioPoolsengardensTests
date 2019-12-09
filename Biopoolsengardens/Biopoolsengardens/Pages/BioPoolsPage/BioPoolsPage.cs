using Biopoolsengardens.BioPoolsPage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Reflection;

namespace Biopoolsengardens.Pages
{

    [TestFixture]
    public class TestsPoolsPage 
    {

        private IWebDriver _driver;
        private BioPoolsPageMethod _poolsPage;
        

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
           
            _poolsPage = new BioPoolsPageMethod(_driver); 
        }

        [Test]
        [Retry(1)]
        public void NavigatetoPoolsPage()
        {

            _poolsPage.Navigate();

            _poolsPage.Maximize();

            _poolsPage.ArrowButton.Click();

            _poolsPage.CookieButton.Click();

            _poolsPage.Example.Click();


            Actions actions = new Actions(_driver);

            actions.MoveToElement(_poolsPage.ContactButton).Perform();

            _poolsPage.MoveUpArrowButton.Click();

            _poolsPage.AssertIsDisplayedGratisOfferLink("VRAAG EEN GRATIS OFFERTE!");
            _poolsPage.MakeApointmentAssert("Maak een afspraak");
            _poolsPage.BioPoolsAssertLink("Biozwembaden");
            _poolsPage.SwimmingPondsAssertLink("Zwemvijvers");
            _poolsPage.GardenAndNaturalPondsLink("Tuin- en natuurvijvers");
            _poolsPage.SwimmingPoolsLink("Zwembaden");
            _poolsPage.RealizationLink("Realisaties");
            _poolsPage.ContactLink("Contact");
            
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