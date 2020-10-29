using Biopoolsengardens.Pages.PoolsPageGalery;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Biopoolsengardens
{
    class PoolsPageGalery
    {
        [TestFixture]

        public class PoolsGalery
        {

            private IWebDriver _driver;

            private PoolsPageGaleryElements _poolsGalery;

            [SetUp]

            public void SetUp()
            {
                _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                _driver.Manage().Window.Maximize();


                // ChromeOptions options = new ChromeOptions(); //- headlesss ChromeDriver

                // options.AddArgument("--headless");


                // _driver = new ChromeDriver(options);

                _poolsGalery = new PoolsPageGaleryElements(_driver);
            }

            [Test]
            [Retry(1)]

            public void NavigateToPoolsGalery()
            {

                _poolsGalery.Maximize();

                _poolsGalery.Navigate();

                _poolsGalery.CookieButton.Click();

                _poolsGalery.PoolsButton.Click();

                Actions action = new Actions(_driver);
                action.MoveToElement(_poolsGalery.SocialLinksGrid)
                    .Release()
                    .Perform();

                action.ClickAndHold(_poolsGalery.SelectPictures)
                    .Release()
                    .Perform();



                for (int i = 0; i < 40; i++)
                {

                    _poolsGalery.NextPuctureButton.Click();
                    Thread.Sleep(1000);
                }

                _poolsGalery.CloseButton.Click();

                _poolsGalery.MoveUpArrowButton.Click();


                _poolsGalery.AssertIsDisplayedGratisOfferLink("VRAAG EEN GRATIS OFFERTE!");
                _poolsGalery.MakeApointmentAssert("Maak een afspraak");
                _poolsGalery.BioPoolsAssertLink("Biozwembaden");
                _poolsGalery.SwimmingPondsAssertLink("Zwemvijvers");
                _poolsGalery.GardenAndNaturalPondsLink("Tuin- en natuurvijvers");
                _poolsGalery.SwimmingPoolsLink("Zwembaden");
                _poolsGalery.RealizationLink("Realisaties");
                _poolsGalery.ContactLink("Contact");

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





