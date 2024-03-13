using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Biopoolsengardens.Pages
{
    public class GratisOfferTest
    {

        [TestFixture]

        public class FreeOffer
        {

            private IWebDriver _driver;

            public GratisOfferSelectors _offer;
            private OffersProperties _fillOffer;

            [SetUp]

            public void SetUp()
            {

                _driver = new ChromeDriver();

                _fillOffer = GratisOffer.FillUser();

                _offer = new GratisOfferSelectors(_driver);

                _offer.Navigate();

                _offer.Maximize();
            }


            [Test]
            [Retry(1)]

            public void SendRequestForFreeOffer()
            {

                _offer.CookieButton.Click();

                _offer.ShuttleButton.Click();

                _offer.FillOfferForm(_fillOffer);

                _offer.InterestButton.Click();

                _offer.SubbmitButton.Click();

            }

            [Test]
            [Retry(1)]

            public void TestFreeOfferWithoutFirstAndLastName()
            {
           

                _offer.CookieButton.Click();

                _offer.ShuttleButton.Click();

                _offer.InterestButton.Click();

                _fillOffer.FirstAndLastName = "";

                _offer.FillOfferForm(_fillOffer);

                _offer.SubbmitButton.Click();



            }


            [Test]
            [Retry(1)]

            public void TestWithoutTelephoneNumber()
            {


                _offer.CookieButton.Click();

                _offer.ShuttleButton.Click();

                _offer.InterestButton.Click();

                _fillOffer.TelephoneNumber = "";

                _offer.FillOfferForm(_fillOffer);

                // _offer.SubbmitButton.Click();

                _offer.ContactLink("Contact");

            }

            [Test]
            [Retry(1)]

            public void TestWithoutEmailAddress()
            {

                _offer.CookieButton.Click();

                _offer.ShuttleButton.Click();

                _offer.InterestButton.Click();

                _fillOffer.EmailAddress = "";

                _offer.FillOfferForm(_fillOffer);

                // _offer.SubbmitButton.Click();

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
