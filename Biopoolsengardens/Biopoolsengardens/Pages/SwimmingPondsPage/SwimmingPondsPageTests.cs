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
        [Obsolete]
        public void TearDown()
        {
            try
            {
                // Check if the test has failed
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var message = TestContext.CurrentContext.Result.Message;

                if (status == TestStatus.Failed)
                {
                    // Capture screenshot
                    var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();

                    // Save screenshot to a file
                    string screenshotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
                    Directory.CreateDirectory(screenshotPath);

                    string screenshotFileName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                    string screenshotFilePath = Path.Combine(screenshotPath, screenshotFileName);

                    // Save the screenshot
                    screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);

                    // Log the screenshot file path or perform any additional actions
                    Console.WriteLine($"Screenshot saved: {screenshotFilePath}");
                }

                // Get the solution directory
                string solutionDirectory = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));

                // Specify the folder path within the solution to save the reports
                string reportsFolder = Path.Combine(solutionDirectory, "TestReports");

                // Create the folder if it doesn't exist
                if (!Directory.Exists(reportsFolder))
                {
                    Directory.CreateDirectory(reportsFolder);
                }

                // Generate XML report
                string fileName = Path.Combine(reportsFolder, $"FailedTest_{TestContext.CurrentContext.Test.Name}.xml");
                var xmlDoc = new System.Xml.XmlDocument();

                // Create the root element
                var root = xmlDoc.CreateElement("TestResult");
                xmlDoc.AppendChild(root);

                // Add test details
                var testNameElement = xmlDoc.CreateElement("TestName");
                testNameElement.InnerText = TestContext.CurrentContext.Test.FullName;
                root.AppendChild(testNameElement);

                var errorMessageElement = xmlDoc.CreateElement("ErrorMessage");
                errorMessageElement.InnerText = message;
                root.AppendChild(errorMessageElement);

                // Save the XML file
                xmlDoc.Save(fileName);

                // Visualize the XML report (open in default XML viewer)
                System.Diagnostics.Process.Start(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in TeardownTest method: {ex.Message}");
            }
            finally
            {
                // Close the WebDriver instance
                if (_driver != null)
                {
                    _driver.Quit();
                }
            }
        }
    }

}
