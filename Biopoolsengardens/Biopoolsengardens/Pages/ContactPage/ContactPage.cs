using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Reflection;
using System.Threading;

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

                _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
               
                _user = ContactPageFill.FillUser();
                _contactPage = new ContactePageMethod(_driver);
                
            }

            [Test]
            

            public void NavigateToContactPageAndFillTheForm()
            {
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

                _contactPage.Maximize();

                _contactPage.CookieButton.Click();

                _contactPage.ContactPageButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_contactPage.ShuttleElement).Perform();

                _user.RealEmailAddress = "";
                _user.Name = "";

                _contactPage.FillForm(_user);

                _contactPage.Submit.Click();

                Assert.IsTrue(true, _contactPage.ErrorMessageForMissingEmailAddress.Text);
                Assert.IsTrue(_contactPage.ErrorMessageForMissingEmailAddress.Displayed);

            }



            [Test]

            public void FillFormWithoutPhoneNumber()
            {

                _contactPage.Navigate();

                _contactPage.Maximize();

                _contactPage.CookieButton.Click();

                _contactPage.ContactPageButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_contactPage.ShuttleElement).Perform();

                _user.RealTelepfoneNumber = "";

                _contactPage.FillForm(_user);

                _contactPage.Submit.Click();

                Assert.IsEmpty(_user.RealTelepfoneNumber);

            }

            [Test]

            public void FillFormWithoutFirstAndLastName()
            {
                _contactPage.Navigate();

                _contactPage.Maximize();

                _contactPage.CookieButton.Click();

                _contactPage.ContactPageButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_contactPage.ShuttleElement).Perform();

                _user.Name = "";

                _contactPage.FillForm(_user);
                _contactPage.Submit.Click();

                Assert.IsEmpty(_user.Name);

            }

            [Test]

            public void CheckSocialMedialLink()
            {
                _contactPage.Navigate();
                _contactPage.Maximize();
                _contactPage.CookieButton.Click();
                _contactPage.ContactPageButton.Click();

                Actions action = new Actions(_driver);
                action.MoveToElement(_contactPage.ShuttleElement).Perform();

                _contactPage.SocialMediaButton.Click();

                Thread.Sleep(1000);

                var tabs = _driver.WindowHandles;

                if (tabs.Count > 1)
                {
                     
                    _driver.SwitchTo().Window(tabs[1]);
                    _driver.Close();
                    _driver.SwitchTo().Window(tabs[0]);

                }

                
                Assert.IsTrue(_driver.FindElement(By.TagName("h1")).Displayed);

            }

            [Test]
            public void ValidateErrorMessageWhenSkippingTheCommentBox()
            {
                _contactPage.Navigate();
                _contactPage.Maximize();
                _contactPage.CookieButton.Click();
                _contactPage.ContactPageButton.Click();

                Actions action = new Actions(_driver);
                action.MoveToElement(_contactPage.ShuttleElement).Perform();

                _user.CommentBox = "";

                _contactPage.FillForm(_user);
                _contactPage.Submit.Click();

                Assert.AreEqual(_contactPage.ErrorMessageForCommentBox.Text, "Dit veld is verplicht.");
                Assert.IsTrue(_contactPage.ErrorMessageForCommentBox.Displayed);

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
