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
}
