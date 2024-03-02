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

    [TestFixture]
    public class Tests
    {

        private IWebDriver _driver;

        private SwimmingPondsMethod _swimmingPonds;

        [SetUp]

        public void TestInit()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _swimmingPonds = new SwimmingPondsMethod(_driver);
        }

        [Test]


        public void NavigateToSwimmingPondsPage()
        {
            _swimmingPonds.Navigate();
            _swimmingPonds.CookieButton.Click();
            _swimmingPonds.Example.Click();
            Actions action = new Actions(_driver);
            action.ClickAndHold(_swimmingPonds.Grid).
                Perform();
            action.Release(_swimmingPonds.Grid)
                .Perform();
            Thread.Sleep(2000);
            _swimmingPonds.MoveUpArrowButton.Click();
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
