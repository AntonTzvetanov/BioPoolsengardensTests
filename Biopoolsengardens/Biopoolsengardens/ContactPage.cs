using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
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

            [SetUp]

            public void SetUp()
            {
                _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                _driver.Navigate().GoToUrl("https://www.biopoolsengardens.be/nl");
                _driver.Manage().Window.Maximize();
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));


            }

            [Test]
            [Repeat(2)]

            public void NavigateToContactPageAndFillTheForm()
            {

                var coockieButton = _driver.FindElement(By.ClassName("cookieButton"));
                coockieButton.Click();

                var contactPageButton = _driver.FindElement(By.LinkText("Contact"));
                contactPageButton.Click();

                var shuttleElement = _driver.FindElement(By.Id("grid_2f3d0e64e9"));
                Actions action = new Actions(_driver);
                action.ClickAndHold(shuttleElement).Perform();

                var contactField = _driver.FindElement(By.Id("fields[538]"));
                contactField.SendKeys("Test Testov");
                var telephoneNumber = _driver.FindElement(By.Id("fields[541]"));
                telephoneNumber.SendKeys("000123456543");
                var email = _driver.FindElement(By.Id("fields[539]"));
                email.SendKeys("test@domain.com");
                var subbmitButton = _driver.FindElement(By.TagName("Versturen"));
                subbmitButton.Click();

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
