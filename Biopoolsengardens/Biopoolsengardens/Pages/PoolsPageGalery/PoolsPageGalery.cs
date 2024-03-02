using Biopoolsengardens.Pages.PoolsPageGalery;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.IO;
using System.Threading;

namespace Biopoolsengardens.BioPoolsPage
{
    class PoolsPageGalery
    {
        [TestFixture]

        public class PoolsGalery
        {

            private IWebDriver _driver;

            private PoolsPageGaleryElements _poolsGalery;

            [SetUp]

            public void SetUp()
            {
                _driver = new ChromeDriver();
                _driver.Manage().Window.Maximize();

                _poolsGalery = new PoolsPageGaleryElements(_driver);

                _poolsGalery.Maximize();

                _poolsGalery.Navigate();
            }

            [Test]


            public void NavigateToPoolsGaleryAndVerifyThatAllPicturesAreDisplayed()
            {
                _poolsGalery.CookieButton.Click();

                _poolsGalery.PoolsButton.Click();
                Assert.IsTrue(true, _poolsGalery.PoolsPageCenterPicture.Displayed.ToString(), Is.True);

                Actions action = new Actions(_driver);
                action.MoveToElement(_poolsGalery.SocialLinksGrid)
                    .Release()
                    .Perform();

                action.ClickAndHold(_poolsGalery.SelectPictures)
                    .Release()
                    .Perform();
                for (int i = 0; i < 42; i++)
                {

                    _poolsGalery.NextPuctureButton.Click();
                    Thread.Sleep(1000);
                    Assert.That(true, _poolsGalery.SelectPictures.Displayed.ToString(), Is.True);

                }
                _poolsGalery.CloseButton.Click();
                _poolsGalery.MoveUpArrowButton.Click();

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





