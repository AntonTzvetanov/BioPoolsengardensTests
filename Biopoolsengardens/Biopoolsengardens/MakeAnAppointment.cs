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
    class MakeAnAppointment
    {

        [TestFixture]
         public class MaakEenAfspraak
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

            public void NavigateAndMakeAppointment()
            {
                var coockieButton = _driver.FindElement(By.ClassName("cookieButton"));
                coockieButton.Click();

                var offerButton = _driver.FindElement(By.Id("element-773"));
                offerButton.Click();
                var shuttleElement = _driver.FindElement(By.Id("grid_2f3d0e64e9"));
                Actions action = new Actions(_driver);
                action.ClickAndHold(shuttleElement).Perform();

                var name = _driver.FindElement(By.Id("fields[554]"));
                name.SendKeys("Test");
                var family = _driver.FindElement(By.Id("fields[562]"));
                family.SendKeys("Test");
                var telephone = _driver.FindElement(By.Id("fields[555]"));
                telephone.SendKeys("000322355444");
                var options = _driver.FindElement(By.ClassName("Field-checkbox"));
                options.Click();
                var email = _driver.FindElement(By.Id("fields[556]"));
                email.SendKeys("test@domain.com");
                var commentBox = _driver.FindElement(By.Id("fields[557]"));
                commentBox.SendKeys("test");
                var subbmitButton = _driver.FindElement(By.ClassName("Row"));
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
