using Biopoolsengardens.BioPoolsPage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.IO;

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

        private ITakesScreenshot NewMethod()
        {
            return (ITakesScreenshot)_driver;
        }
    }
}