using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace Biopoolsengardens.Pages
{
    public class GratisOfferTest
    {

        [TestFixture]

        public class FreeOffer
        {

            private IWebDriver _driver;

            public GratisOfferSelectors _offer;
            private OffersProperties _fillOffer;

            [SetUp]

            public void SetUp()
            {
              
                _driver = new ChromeDriver();
                
                _fillOffer = GratisOffer.FillUser();

                _offer = new GratisOfferSelectors(_driver);

                _offer.Navigate();

                _offer.Maximize();
            }


            [Test]
            [Retry(1)]

            public void SendRequestForFreeOffer()
            {

                _offer.CookieButton.Click();

                _offer.ShuttleButton.Click();

                _offer.FillOfferForm(_fillOffer);

                _offer.InterestButton.Click();

                _offer.SubbmitButton.Click();
                
            }

            [Test]
            [Retry(1)]

            public void TestFreeOfferWithoutFirstAndLastName()
            {
                _offer.Navigate();

                _offer.Maximize();

                _offer.CookieButton.Click();

                _offer.ShuttleButton.Click();

                _offer.InterestButton.Click();

                _fillOffer.FirstAndLastName = "";

                _offer.FillOfferForm(_fillOffer);

                // _offer.SubbmitButton.Click();



            }


            [Test]
            [Retry(1)]

            public void TestWithoutTelephoneNumber()
            {

                _offer.Navigate();

                _offer.Maximize();

                _offer.CookieButton.Click();

                _offer.ShuttleButton.Click();

                _offer.InterestButton.Click();

                _fillOffer.TelephoneNumber = "";

                _offer.FillOfferForm(_fillOffer);

                // _offer.SubbmitButton.Click();

                _offer.ContactLink("Contact");

            }

            [Test]
            [Retry(1)]

            public void TestWithoutEmailAddress()
            {

                _offer.Navigate();

                _offer.Maximize();

                _offer.CookieButton.Click();

                _offer.ShuttleButton.Click();

                _offer.InterestButton.Click();

                _fillOffer.EmailAddress = "";

                _offer.FillOfferForm(_fillOffer);

                // _offer.SubbmitButton.Click();

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
