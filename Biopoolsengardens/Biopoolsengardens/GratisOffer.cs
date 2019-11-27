using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
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

            public void TestFreeOffer()
            {
                var coockieButton = _driver.FindElement(By.ClassName("cookieButton"));
                coockieButton.Click();

                var shuttelButton = _driver.FindElement(By.Id("element-883"));
                shuttelButton.Click();

                var fillFirstAndLastName = _driver.FindElement(By.Id("fields[911]"));
                fillFirstAndLastName.SendKeys("Anton Tsvetanov");
                var telephoneNumber = _driver.FindElement(By.Id("fields[912]"));
                telephoneNumber.SendKeys("003345959123");
                var emailAddress = _driver.FindElement(By.Id("fields[913]"));
                emailAddress.SendKeys("test@domain.com");
                var ongoveer = _driver.FindElement(By.Id("fields[917]"));
                ongoveer.SendKeys("test");
                var interestButton = _driver.FindElement(By.Name("fields[916][]"));
                interestButton.Click();
                var textBox = _driver.FindElement(By.Id("fields[914]"));
                textBox.SendKeys("test");
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
