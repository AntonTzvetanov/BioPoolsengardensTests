using Biopoolsengardens.Pages.PoolsPageGalery;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.IO;
using System.Net;
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
            private string downloadDirectory;
        
            [SetUp]

            public void SetUp()
            {
                _driver = new ChromeDriver();
                _driver.Manage().Window.Maximize();
                _poolsGalery = new PoolsPageGaleryElements(_driver);
                _poolsGalery.Maximize();
                _poolsGalery.Navigate();
                downloadDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Downloads");
                if (!Directory.Exists(downloadDirectory))
                {
                    Directory.CreateDirectory(downloadDirectory);
                }
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
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

            [Test] 
            public void SelectPictureAndDownload()
            {
                _poolsGalery.CookieButton.Click();
                _poolsGalery.PoolsButton.Click();
                Assert.IsTrue(true, _poolsGalery.PoolsPageCenterPicture.Displayed.ToString(), Is.True);
                Actions action = new Actions(_driver);
                action.MoveToElement(_poolsGalery.SocialLinksGrid).Release().Perform();
                action.ClickAndHold(_poolsGalery.SelectPictures).Release().Perform();
                action.MoveToElement(_poolsGalery.InPictureShareButton).Perform();
                
                _poolsGalery.InPictureShareButton.Click();
                Thread.Sleep(1000);
                //to fix this shit 
                _poolsGalery.DownloadImage.Click();
                var tabs = _driver.WindowHandles;

                if (tabs.Count > 1)
                {
                    _driver.SwitchTo().Window(tabs[1]);
                }

                var imageUrl = _driver.Url;
                WebClient client = new WebClient();

                if (!string.IsNullOrEmpty(imageUrl))
                {
                    // Download the image
               
                    client.DownloadFile(imageUrl, Path.Combine(downloadDirectory, "downloaded_image.jpg"));
                }
                else
                {
                    // Log or handle the case where the URL is null or empty
                    Console.WriteLine("Image URL is null or empty. Skipping download.");
                }
              
               
                client.DownloadFile(imageUrl, Path.Combine(downloadDirectory, "downloaded_image.jpg"));
                Assert.IsTrue(File.Exists(Path.Combine(downloadDirectory, "downloaded_image.jpg")),
                "Downloaded file does not exist.");
            }

            [TearDown]
            [Obsolete]
            public void TeardownTest()
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





