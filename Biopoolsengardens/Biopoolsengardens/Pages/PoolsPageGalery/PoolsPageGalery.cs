using Biopoolsengardens.Pages.PoolsPageGalery;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Biopoolsengardens
{
    class PoolsPageGalery
    {
        [TestFixture]

        public class PoolsGalery
        {

            private IWebDriver _driver;
           
            private PoolsPageGaleryMethod _poolsGalery;

            [SetUp]

            public void SetUp()
            {
                _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                
            }

            [Test]
            [Retry(1)]

            public void NavigateToPoolsGalery()
            {

                _poolsGalery = new PoolsPageGaleryMethod(_driver); 

                _poolsGalery.Maximize();

                _poolsGalery.Navigate();

                _poolsGalery.CookieButton.Click();

                _poolsGalery.PoolsButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_poolsGalery.SocialLinksGrid)
                    .Release()
                    .Perform();

                action.ClickAndHold(_poolsGalery.SelectPictures)
                    .Release()
                    .Perform();
              
                

                for (int i = 0; i < 40; i++)
                {

                    _poolsGalery.NextPuctureButton.Click();
                    Thread.Sleep(2000);
                }

                _poolsGalery.CloseButton.Click();

                _poolsGalery.MoveUpArrowButton.Click();

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





