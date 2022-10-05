using Biopoolsengardens.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Biopoolsengardens
{
    class Galery
    {
        [TestFixture]

        public class NavigateToGalery
        {

            private IWebDriver _driver;

            private GaleryElements _galery;

            [SetUp]

            public void SetUp()
            {

                new DriverManager().SetUpDriver(new ChromeConfig());
                 _driver = new ChromeDriver();

               // ChromeOptions options = new ChromeOptions(); //- headlesss ChromeDriver

               // options.AddArgument("--headless");

                _driver = new ChromeDriver();

            }


            [Test]
            [Retry(1)]

            public void NavigateGalery()
            {
                _galery = new GaleryElements(_driver);

                _galery.Navigate();
                _galery.Maximize();

                _galery.CookieButton.Click();

                _galery.GaleryButton.Click();

                Actions actions = new Actions(_driver);
                actions.ClickAndHold(_galery.Pictures)
                    .Release()
                    .Perform();

                for (int i = 0; i <= 28; i++)
                {
                    _galery.NextPictureButton.Click();

                    Thread.Sleep(1000);
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
