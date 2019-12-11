using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Reflection;

namespace Biopoolsengardens.Pages
{
    class ContactPage
    {
        [TestFixture]



        public class Contact
        {

            private IWebDriver _driver;
            private ContactPageFactory _user;

            private ContactePageMethod _contactPage;

            [SetUp]

            public void TestInit()
            {
                //_driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                // _driver.Manage().Window.Maximize();


                ChromeOptions options = new ChromeOptions(); //- headlesss ChromeDriver

                options.AddArgument("--headless");


                _driver = new ChromeDriver(options);


                _user = ContactPageFill.FillUser();

                _driver.Manage().Window.Maximize();

            }

            [Test]
            [Retry(1)]

            public void NavigateToContactPageAndFillTheForm()
            {

                _contactPage = new ContactePageMethod(_driver);

                _contactPage.Navigate();

                _contactPage.CookieButton.Click();

                _contactPage.ContactPageButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_contactPage.ShuttleElement).Perform();

                _contactPage.FillForm(_user);

                // _contactPage.Submit.Click();

                _contactPage.AssertIsDisplayedGratisOfferLink("VRAAG EEN GRATIS OFFERTE!");
                _contactPage.MakeApointmentAssert("Maak een afspraak");
                _contactPage.BioPoolsAssertLink("Biozwembaden");
                _contactPage.SwimmingPondsAssertLink("Zwemvijvers");
                _contactPage.GardenAndNaturalPondsLink("Tuin- en natuurvijvers");
                _contactPage.SwimmingPoolsLink("Zwembaden");
                _contactPage.RealizationLink("Realisaties");
                _contactPage.ContactLink("Contact");


            }

            [Test]

            public void FillFormWithoutEmailAddress()
            {
                _contactPage.Navigate();

                _contactPage.CookieButton.Click();

                _contactPage.ContactPageButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_contactPage.ShuttleElement).Perform();

                _user.RealEmailAddress = "";

                _contactPage.FillForm(_user);

                _contactPage.Submit.Click();

                _contactPage.AssertIsDisplayedGratisOfferLink("VRAAG EEN GRATIS OFFERTE!");
                _contactPage.MakeApointmentAssert("Maak een afspraak");
                _contactPage.BioPoolsAssertLink("Biozwembaden");
                _contactPage.SwimmingPondsAssertLink("Zwemvijvers");
                _contactPage.GardenAndNaturalPondsLink("Tuin- en natuurvijvers");
                _contactPage.SwimmingPoolsLink("Zwembaden");
                _contactPage.RealizationLink("Realisaties");
                _contactPage.ContactLink("Contact");

            }



            [Test]

            public void FillFormWithoutPhoneNumber()
            {
                _contactPage.Navigate();

                _contactPage.CookieButton.Click();

                _contactPage.ContactPageButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_contactPage.ShuttleElement).Perform();

                _user.RealTelepfoneNumber = "";

                _contactPage.FillForm(_user);

                _contactPage.Submit.Click();

                _contactPage.AssertIsDisplayedGratisOfferLink("VRAAG EEN GRATIS OFFERTE!");
                _contactPage.MakeApointmentAssert("Maak een afspraak");
                _contactPage.BioPoolsAssertLink("Biozwembaden");
                _contactPage.SwimmingPondsAssertLink("Zwemvijvers");
                _contactPage.GardenAndNaturalPondsLink("Tuin- en natuurvijvers");
                _contactPage.SwimmingPoolsLink("Zwembaden");
                _contactPage.RealizationLink("Realisaties");
                _contactPage.ContactLink("Contact");


            }

            [Test] 

            public void FillFormWithoutFirstAndLastName()
            {
                _contactPage.Navigate();

                _contactPage.CookieButton.Click();

                _contactPage.ContactPageButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_contactPage.ShuttleElement).Perform();

                _user.Name = "";

                _contactPage.FillForm(_user);

                _contactPage.Submit.Click();

                _contactPage.AssertIsDisplayedGratisOfferLink("VRAAG EEN GRATIS OFFERTE!");
                _contactPage.MakeApointmentAssert("Maak een afspraak");
                _contactPage.BioPoolsAssertLink("Biozwembaden");
                _contactPage.SwimmingPondsAssertLink("Zwemvijvers");
                _contactPage.GardenAndNaturalPondsLink("Tuin- en natuurvijvers");
                _contactPage.SwimmingPoolsLink("Zwembaden");
                _contactPage.RealizationLink("Realisaties");
                _contactPage.ContactLink("Contact");


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
