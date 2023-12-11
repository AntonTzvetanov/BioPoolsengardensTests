using Biopoolsengardens.BioPoolsPage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.IO;
using System.Reflection;

namespace Biopoolsengardens.Pages
{

    [TestFixture]
    public class TestsPoolsPage
    {

        private IWebDriver _driver;
        private BioPoolsPageElements _poolsPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();

            _poolsPage = new BioPoolsPageElements(_driver);

            _poolsPage.Navigate();

            _poolsPage.Maximize();
        }

        [Test]

        public void NavigatetoPoolsPageAndVerifyThatHeaderTextIsDisplayed()
        {
            _poolsPage.CookieButton.Click();
            _poolsPage.BioPoolsPageButton.Click();
            Assert.That(_poolsPage.BiopoolsInfoTextHeader.Displayed);
            Assert.That(_poolsPage.BiopoolsInfoTextHeader.Text.ToString().Contains("Biozwembaden"));

        }

        [Test]
        public void VerifyBiopoolsInfoIsDisplayed()
        {
            _poolsPage.CookieButton.Click();
            _poolsPage.BioPoolsPageButton.Click();

            Assert.That(_poolsPage.BiopoolsInfoText.Displayed);

            Assert.That(_poolsPage.BioPoolsPageButton.Displayed);

        }

        [Test]

        public void VerifyContactPageLinkFromBiopoolsPage()
        {
            _poolsPage.CookieButton.Click();
            _poolsPage.BioPoolsPageButton.Click();
            Actions action = new Actions(_driver);
            action.ClickAndHold(_poolsPage.ThirdArrowDown).
                Release().
                Perform();
            _poolsPage.LinkToContactPage.Click();
            string URL = _driver.Url;
            Assert.AreEqual(URL, "https://www.biopoolsengardens.be/nl/contact");

        }


        [Test]

        public void VerifyShugarValeyIsDisplayed()
        {
            _poolsPage.CookieButton.Click();
            _poolsPage.BioPoolsPageButton.Click();
            Actions action = new Actions(_driver);
            action.ClickAndHold(_poolsPage.ThirdArrowDown).
                Release().
                Perform();
            Assert.That(_poolsPage.SugarValeyElement.Displayed);

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