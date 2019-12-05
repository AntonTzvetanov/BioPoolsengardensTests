using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace Biopoolsengardens.Pages
{
    class GratisOfferTest
    {

        [TestFixture] 

        public class FreeOffer
        {

            private IWebDriver _driver;
            
            private GratisOfferMethod _offer;
            private OffersProperties _fillOffer;

            [SetUp] 

            public void SetUp()
            {
                _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                
                _driver.Manage().Window.Maximize();

                _fillOffer = GratisOffer.FillUser();

            }
            

            [Test]
            [Retry(1)]

            public void SendRequestForFreeOffer()
            {

                _offer = new GratisOfferMethod(_driver);

                _offer.Navigate();

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
                _offer = new GratisOfferMethod(_driver);

                _offer.Navigate();

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

                _offer = new GratisOfferMethod(_driver);

                _offer.Navigate();

                _offer.CookieButton.Click();

                _offer.ShuttleButton.Click();

                _offer.InterestButton.Click();

                _fillOffer.TelephoneNumber = "";

                _offer.FillOfferForm(_fillOffer);

                // _offer.SubbmitButton.Click();

            }

            [Test]
            [Retry(1)]

            public void TestWithoutEmailAddress()
            {

                _offer = new GratisOfferMethod(_driver);

                _offer.Navigate();

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
