using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Reflection;

namespace Biopoolsengardens.Pages
{
    class MakeAnAppointment 
    {

        [TestFixture]
         public class MaakEenAfspraak
        {
            private IWebDriver _driver;
            
            private MakeApointmentMethod _apointment;

            private UserProperties _makeApointment;


            [SetUp]

            public void SetUp()
            {
                _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                
                _driver.Manage().Window.Maximize();
                
                _makeApointment = MakeAppointmentUserFactory.User();

            }


            [Test]
            [Retry(1)]

            public void NavigateAndMakeAppointment()
            {
                _apointment = new MakeApointmentMethod(_driver);

                _apointment.Navigate();

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();

                _apointment.FillApointment(_makeApointment);

                _apointment.Options.Click();

                // _apointment.Subbmit.Click();


                _apointment.AssertIsDisplayedGratisOfferLink("VRAAG EEN GRATIS OFFERTE!");
                _apointment.MakeApointmentAssert("Maak een afspraak");
                _apointment.BioPoolsAssertLink("Biozwembaden");
                _apointment.SwimmingPondsAssertLink("Zwemvijvers");
                _apointment.GardenAndNaturalPondsLink("Tuin- en natuurvijvers");
                _apointment.SwimmingPoolsLink("Zwembaden");
                _apointment.RealizationLink("Realisaties");
                _apointment.ContactLink("Contact");

            }

            [Test]

            public void NavigateAndMakeAppointmentWithoutFirstName()
            {
                _apointment = new MakeApointmentMethod(_driver);

                _apointment.Navigate();

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();

                _apointment.FillApointment(_makeApointment);

                _makeApointment.UserName = "";

                _apointment.Options.Click();

                // _apointment.Subbmit.Click();


                _apointment.AssertIsDisplayedGratisOfferLink("VRAAG EEN GRATIS OFFERTE!");
                _apointment.MakeApointmentAssert("Maak een afspraak");
                _apointment.BioPoolsAssertLink("Biozwembaden");
                _apointment.SwimmingPondsAssertLink("Zwemvijvers");
                _apointment.GardenAndNaturalPondsLink("Tuin- en natuurvijvers");
                _apointment.SwimmingPoolsLink("Zwembaden");
                _apointment.RealizationLink("Realisaties");
                _apointment.ContactLink("Contact");


            }

            [Test]

            public void NavigateAndMakeAppointmentWithoutLastName()
            {
                _apointment = new MakeApointmentMethod(_driver);

                _apointment.Navigate();

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();

                _apointment.FillApointment(_makeApointment);

                _makeApointment.UserFamilyName = "";

                _apointment.Options.Click();

                // _apointment.Subbmit.Click();


                _apointment.AssertIsDisplayedGratisOfferLink("VRAAG EEN GRATIS OFFERTE!");
                _apointment.MakeApointmentAssert("Maak een afspraak");
                _apointment.BioPoolsAssertLink("Biozwembaden");
                _apointment.SwimmingPondsAssertLink("Zwemvijvers");
                _apointment.GardenAndNaturalPondsLink("Tuin- en natuurvijvers");
                _apointment.SwimmingPoolsLink("Zwembaden");
                _apointment.RealizationLink("Realisaties");
                _apointment.ContactLink("Contact");


            }

            [Test]

            public void NavigateAndMakeAppointmentWithoutPhoneNumber()
            {

                _apointment = new MakeApointmentMethod(_driver);

                _apointment.Navigate();

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();

                _apointment.FillApointment(_makeApointment);

                _makeApointment.UserPhoneNumber = "";

                _apointment.Options.Click();

                // _apointment.Subbmit.Click();


                _apointment.AssertIsDisplayedGratisOfferLink("VRAAG EEN GRATIS OFFERTE!");
                _apointment.MakeApointmentAssert("Maak een afspraak");
                _apointment.BioPoolsAssertLink("Biozwembaden");
                _apointment.SwimmingPondsAssertLink("Zwemvijvers");
                _apointment.GardenAndNaturalPondsLink("Tuin- en natuurvijvers");
                _apointment.SwimmingPoolsLink("Zwembaden");
                _apointment.RealizationLink("Realisaties");
                _apointment.ContactLink("Contact");


            }

            [Test]

            public void NavigateAndMakeAppointmentWithoutEmailAddress()
            {
                _apointment = new MakeApointmentMethod(_driver);

                _apointment.Navigate();

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();

                _apointment.FillApointment(_makeApointment);

                _makeApointment.UserEmailAddress = "";

                _apointment.Options.Click();

                // _apointment.Subbmit.Click();


                _apointment.AssertIsDisplayedGratisOfferLink("VRAAG EEN GRATIS OFFERTE!");
                _apointment.MakeApointmentAssert("Maak een afspraak");
                _apointment.BioPoolsAssertLink("Biozwembaden");
                _apointment.SwimmingPondsAssertLink("Zwemvijvers");
                _apointment.GardenAndNaturalPondsLink("Tuin- en natuurvijvers");
                _apointment.SwimmingPoolsLink("Zwembaden");
                _apointment.RealizationLink("Realisaties");
                _apointment.ContactLink("Contact");


            }

            [Test]

            public void NavigateAndMakeAppointmentWithoutFillingTheCommentBox()
            {
                _apointment = new MakeApointmentMethod(_driver);

                _apointment.Navigate();

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();

                _apointment.FillApointment(_makeApointment);

                _makeApointment.CommenentBox = "";

                _apointment.Options.Click();

                // _apointment.Subbmit.Click();


                _apointment.AssertIsDisplayedGratisOfferLink("VRAAG EEN GRATIS OFFERTE!");
                _apointment.MakeApointmentAssert("Maak een afspraak");
                _apointment.BioPoolsAssertLink("Biozwembaden");
                _apointment.SwimmingPondsAssertLink("Zwemvijvers");
                _apointment.GardenAndNaturalPondsLink("Tuin- en natuurvijvers");
                _apointment.SwimmingPoolsLink("Zwembaden");
                _apointment.RealizationLink("Realisaties");
                _apointment.ContactLink("Contact");




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
