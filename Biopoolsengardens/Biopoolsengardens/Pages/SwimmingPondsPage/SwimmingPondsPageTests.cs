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
    public class TestsPoundPage
    {

        private IWebDriver _driver;

        private SwimmingPondsElements _swimmingPonds;


        [SetUp]

        public void TestInitialize()
        {
            _driver = new ChromeDriver();
            _swimmingPonds = new SwimmingPondsElements(_driver);
            _swimmingPonds.Navigate();
            _swimmingPonds.Maximize();
        }

        [Test]


        public void NavigateToSwimmingPondsPage()
        {

            _swimmingPonds.CookieButton.Click();
            _swimmingPonds.Example.Click();

            Actions action = new Actions(_driver);
            action.ClickAndHold(_swimmingPonds.Grid).Perform();
            action.Release(_swimmingPonds.Grid).Perform();

            Thread.Sleep(2000);
            Assert.That(_swimmingPonds.MoveUpArrowButton.Displayed, Is.True);
            Assert.That(_swimmingPonds.MoveUpArrowButton.Enabled, Is.True);
            _swimmingPonds.MoveUpArrowButton.Click();

        }

        [Test]
        public void VerifyVideoPlayerIsDisplayed()
        {

            _swimmingPonds.CookieButton.Click();

            _swimmingPonds.Example.Click();

            Actions action = new Actions(_driver);
            action.ClickAndHold(_swimmingPonds.Grid).Perform();
            action.Release(_swimmingPonds.Grid).Perform();

            _swimmingPonds.VideoPlayer.Click();
            Assert.That(_swimmingPonds.VideoPlayer.Displayed);
            Thread.Sleep(2000);
            _swimmingPonds.VideoPlayer.Click();

        }

        [Test]
        public void VerifyLakeDataGridHeaderText()
        {

            _swimmingPonds.CookieButton.Click();
            _swimmingPonds.Example.Click();
            Actions action = new Actions(_driver);
            action.ClickAndHold(_swimmingPonds.LakeDataGrid).Perform();
            action.Release(_swimmingPonds.LakeDataGrid).Perform();
            Assert.That(_swimmingPonds.LakeDataGrid.Displayed);
            Assert.AreEqual(_swimmingPonds.LakeDataGrid.Text, "Voordelen Zwemvijver");
        }

        [Test]
        public void VerifyFootherTextAndLinkToAppointmentPage()
        {

            _swimmingPonds.CookieButton.Click();
            _swimmingPonds.Example.Click();
            Actions action = new Actions(_driver);
            action.ClickAndHold(_swimmingPonds.ShuttleFooter).Perform();
            action.Release(_swimmingPonds.ShuttleFooter).Perform();
            Assert.That(_swimmingPonds.AppointmentPageLink.Displayed);
            Assert.AreEqual(_swimmingPonds.AppointmentPageLink.Text, "Afspraak maken");
            Assert.IsTrue(_swimmingPonds.AppointmentPageLink.Enabled);
            _swimmingPonds.AppointmentPageLink.Click();
            _driver.Navigate().Back();
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
