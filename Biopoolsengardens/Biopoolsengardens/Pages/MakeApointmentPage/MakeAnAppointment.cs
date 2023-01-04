using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Reflection;

namespace Biopoolsengardens.Pages
{
    public class MakeAnAppointment
    {

        [TestFixture]
        public class MaakEenAfspraak
        {
            private IWebDriver _driver;

            private MakeApointmentElements _apointment;

            private UserProperties _makeApointment;


            [SetUp]

            public void SetUp()
            {
                _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                _makeApointment = MakeAppointmentUserFactory.User();
                _apointment = new MakeApointmentElements(_driver);
            }


            [Test]
            [Retry(1)]

            public void NavigateAndMakeAppointment()
            {
                _apointment.Navigate();

                _apointment.Maximize();

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();

                _apointment.FillApointment(_makeApointment);

                _apointment.Options.Click();

                _apointment.Subbmit.Click();

            }

            [Test]
            [Retry (1)]

            public void NavigateAndMakeAppointmentWithoutFirstName()
            {
                _apointment.Navigate();

                _apointment.Maximize();

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();

                _makeApointment.UserName = "";
                _apointment.FillApointment(_makeApointment);

                _apointment.Options.Click();

                _apointment.Subbmit.Click();

            }

            [Test]

            public void NavigateAndMakeAppointmentWithoutLastName()
            {
                _apointment.Navigate();

                _apointment.Maximize();

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();

                _makeApointment.UserFamilyName = "";
                _apointment.FillApointment(_makeApointment);

                _apointment.Options.Click();

                _apointment.Subbmit.Click();

               
            }

            [Test]

            public void NavigateAndMakeAppointmentWithoutPhoneNumber()
            {
                _apointment.Navigate();

                _apointment.Maximize();

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();

                _apointment.FillApointment(_makeApointment);

                _makeApointment.UserPhoneNumber = "";

                _apointment.Options.Click();

                _apointment.Subbmit.Click();

            }

            [Test]

            public void NavigateAndMakeAppointmentWithoutEmailAddress()
            {
                _apointment.Navigate();

                _apointment.Maximize();

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();

                _makeApointment.UserEmailAddress = "";
                _apointment.FillApointment(_makeApointment);

                _apointment.Options.Click();

                _apointment.Subbmit.Click();


            }

            [Test]

            public void NavigateAndMakeAppointmentWithoutFillingTheCommentBox()
            {

                _apointment.Navigate();

                _apointment.Maximize();

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();

                _apointment.FillApointment(_makeApointment);

                _makeApointment.UserName = "";

                _makeApointment.CommenentBox = "";

                _apointment.Options.Click();

                _apointment.Subbmit.Click();


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
                _driver.Close();

            }
        }

    }
}
