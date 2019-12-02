using Biopoolsengardens.Pages.GratisOfferPage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Reflection;

namespace Biopoolsengardens
{
    class GratisOffer
    {

        [TestFixture] 

        public class FreeOffer
        {

            private IWebDriver _driver;
            private WebDriverWait _wait;
            private GratisOfferMethod _offer;

            [SetUp] 

            public void SetUp()
            {
                _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                
                _driver.Manage().Window.Maximize();
          
            }
            

            [Test]
            [Retry(2)]

            public void SendRequestForFreeOffer()
            {

                _offer = new GratisOfferMethod(_driver);

                _offer.Navigate();

                _offer.CookieButton.Click();

                _offer.ShuttleButton.Click();

                _offer.FirstAndLastName.SendKeys("test test");

                _offer.TelephoneNumber.SendKeys("0092143546543");

                _offer.EmailAddress.SendKeys("test@domain.com");

                _offer.Ongoveer.SendKeys("test");

                _offer.InterestButton.Click();

                _offer.TextBox.SendKeys("test");

                //_offer.SubbmitButton.Click();
               
            }

            [Test]

            public void TestFreeOfferWithoutFirstAndLastName()
            {
                _offer = new GratisOfferMethod(_driver);

                _offer.Navigate();

                _offer.CookieButton.Click();

                _offer.ShuttleButton.Click();

                _offer.FirstAndLastName.SendKeys("");

                _offer.TelephoneNumber.SendKeys("0092143546543");

                _offer.EmailAddress.SendKeys("test@domain.com");

                _offer.Ongoveer.SendKeys("test");

                _offer.InterestButton.Click();

                _offer.TextBox.SendKeys("test");

               // _offer.SubbmitButton.Click();


            }


            [Test]

            public void TestWithoutTelephoneNumber()
            {

                _offer = new GratisOfferMethod(_driver);

                _offer.Navigate();

                _offer.CookieButton.Click();

                _offer.ShuttleButton.Click();

                _offer.FirstAndLastName.SendKeys("test test");

                _offer.TelephoneNumber.SendKeys("");

                _offer.EmailAddress.SendKeys("test@domain.com");

                _offer.Ongoveer.SendKeys("test");

                _offer.InterestButton.Click();

                _offer.TextBox.SendKeys("test");

               // _offer.SubbmitButton.Click();


            }

            [Test]

            public void TestWithoutEmailAddress()
            {


                _offer = new GratisOfferMethod(_driver);

                _offer.Navigate();

                _offer.CookieButton.Click();

                _offer.ShuttleButton.Click();

                _offer.FirstAndLastName.SendKeys("test test");

                _offer.TelephoneNumber.SendKeys("0092143546543");

                _offer.EmailAddress.SendKeys("");

                _offer.Ongoveer.SendKeys("test");

                _offer.InterestButton.Click();

                _offer.TextBox.SendKeys("test");

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
