using Biopoolsengardens.Pages.MakeApointment;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
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
            private WebDriverWait _wait;
            private MakeApointmentMethod _apointment;

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
            [Retry(2)]

            public void NavigateAndMakeAppointment()
            {
                _apointment = new MakeApointmentMethod(_driver);

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();

                
                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();

                //fill all fields 

                _apointment.Name.SendKeys("test");
                _apointment.Family.SendKeys("test");
                _apointment.Telephone.SendKeys("002234124");
                _apointment.Options.Click();
                _apointment.Email.SendKeys("test@domain.com");
                _apointment.CommentBox.SendKeys("test");
               // _apointment.Subbmit.Click();

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
