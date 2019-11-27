using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
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

            public void NavigateToPoolsGalery()
            {

                var coockieButton = _driver.FindElement(By.ClassName("cookieButton"));
                coockieButton.Click();

                var poolsButton = _driver.FindElement(By.LinkText("Zwembaden"));
                poolsButton.Click();

                var socialGrid = _driver.FindElement(By.Id("grid_2f3d0e64e9"));
                
                Actions action = new Actions(_driver);
                action.ClickAndHold(socialGrid).Perform();

                var slidePictures = _driver.FindElement(By.Id("element-758"));
                action.ClickAndHold(slidePictures).Perform();
                action.Release(slidePictures).Perform();

                var arrowNextPicture = _driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/button[2]"));

                for (int i = 0; i < 10; i++)
                {
                    
                    arrowNextPicture.Click();
                    Thread.Sleep(3000);
                }

                var closeButton = _driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div[1]/button[1]"));
                closeButton.Click();

                var moveUpArrow = _wait.Until((e) => e.FindElement(By.ClassName("custom-style-33")));

                moveUpArrow.Click();
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





