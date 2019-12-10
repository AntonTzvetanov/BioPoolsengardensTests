using Biopoolsengardens.Pages.Galery;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Biopoolsengardens
{
    class Galery
    {
        [TestFixture]

        public class NavigateToGalery
        {

            private IWebDriver _driver;
            
            private GaleryMethod _galery;

            [SetUp]

            public void SetUp()
            {

                _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

                _driver.Manage().Window.Maximize();
               
            }


            [Test]
            [Retry(1)]

            public void NavigateGalery()
            {
                _galery = new GaleryMethod(_driver);

                _galery.Navigate();

                _galery.CookieButton.Click();

                _galery.GaleryButton.Click();

                Actions actions = new Actions(_driver);
                actions.ClickAndHold(_galery.Pictures).Release().Perform();

                for (int i = 0; i <= 28; i++)
                {
                    _galery.NextPictureButton.Click();

                    Thread.Sleep(2000);
                }

                _galery.MoveUpArrowButton.Click();
               
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
