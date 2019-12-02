using Biopoolsengardens.BioPoolsPage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Reflection;

namespace Biopoolsengardens
{
    class ContactPage
    {
        [TestFixture]



        public class Contact
        {

            private IWebDriver _driver;
            private WebDriverWait _wait;
            private ContactePageMethod _contactPage;

            [SetUp]

            public void SetUp()
            {
                _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
               
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

                _contactPage.ContactField.SendKeys("test");

                _contactPage.Telephone.SendKeys("869675465");

                _contactPage.Email.SendKeys("test@domain.com");

                _contactPage.TextArea.SendKeys("test");

               // _contactPage.Submit.Click();

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
