using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
                _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

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
