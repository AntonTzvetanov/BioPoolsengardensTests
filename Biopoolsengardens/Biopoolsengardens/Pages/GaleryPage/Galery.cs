using Biopoolsengardens.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.IO;
using System.Threading;


namespace Biopoolsengardens.Pages
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
                _driver = new ChromeDriver();
                //to be fixed 
                _driver.Navigate().GoToUrl("https://www.biopoolsengardens.be/nl");
                _driver.Manage().Window.FullScreen();
                _galery = new GaleryElements(_driver);
            }


            [Test]
            [Retry(1)]

            public void NavigateGalery()
            {
              
                _galery.CookieButton.Click();
                _galery.GaleryButton.Click();

                Actions actions = new Actions(_driver);
                actions.ClickAndHold(_galery.Pictures).Release().Perform();
                for (int i = 0; i <= 34; i++)
                {
                    _galery.NextPictureButton.Click();

                    Thread.Sleep(1000);
                    Assert.IsTrue(_galery.Pictures.Displayed);
                }

                _galery.MoveUpArrowButton.Click();

            }

            [TearDown]
            public void TearDown()
            {
                try
                {
                    if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                    {
                        // Capture screenshot
                        var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();

                        // Save screenshot to a file
                        string screenshotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
                        Directory.CreateDirectory(screenshotPath);

                        string screenshotFileName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                        string screenshotFilePath = Path.Combine(screenshotPath, screenshotFileName);

                        // Log the screenshot file path or perform any additional actions
                        Console.WriteLine($"Screenshot saved: {screenshotFilePath}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in TearDown method: {ex.Message}");
                }
                finally
                {
                    // Close the WebDriver instance
                    if (_driver != null)
                    {
                        _driver.Close();
                    }
                }
            }
        }


    }
}
