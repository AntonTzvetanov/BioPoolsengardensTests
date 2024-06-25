using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.IO;

namespace Biopoolsengardens.Pages
{
    public class MakeAnAppointment
    {

        [TestFixture]
        public class MaakEenAfspraak
        {
            private IWebDriver _driver;

            private MakeApointmentElements _apointment;

            private UserProperties _makeApointment;


            [SetUp]

            public void SetUp()
            {
                _driver = new ChromeDriver();
                _makeApointment = MakeAppointmentUserFactory.User();
                _apointment = new MakeApointmentElements(_driver);
            }


            [Test]
            public void NavigateAndMakeAppointment()
            {
                _apointment.Navigate();

                _apointment.Maximize();

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();

                _apointment.FillApointment(_makeApointment);

                _apointment.Options.Click();

                _apointment.Subbmit.Click();

            }

            [Test]
            public void NavigateAndMakeAppointmentWithoutFirstName()
            {
                _apointment.Navigate();

                _apointment.Maximize();

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();

                _makeApointment.UserName = "";
                _apointment.FillApointment(_makeApointment);

                _apointment.Options.Click();

                _apointment.Subbmit.Click();

                Assert.That(_makeApointment.UserName, Is.Empty);

            }

            [Test]

            public void NavigateAndMakeAppointmentWithoutLastName()
            {
                _apointment.Navigate();

                _apointment.Maximize();

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();

                _makeApointment.UserFamilyName = "";
                _apointment.FillApointment(_makeApointment);

                _apointment.Options.Click();

                _apointment.Subbmit.Click();


            }

            [Test]

            public void NavigateAndMakeAppointmentWithoutPhoneNumber()
            {
                _apointment.Navigate();

                _apointment.Maximize();

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();

                _apointment.FillApointment(_makeApointment);

                _makeApointment.UserPhoneNumber = "";

                _apointment.Options.Click();

                _apointment.Subbmit.Click();

            }

            [Test]

            public void VerifyErrorMessageForMissingEmail()
            {
                _apointment.Navigate();

                _apointment.Maximize();

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();

                _makeApointment.UserEmailAddress = "";
                _apointment.FillApointment(_makeApointment);

                _apointment.Options.Click();

                _apointment.Subbmit.Click();


            }

            [Test]

            public void NavigateAndMakeAppointmentWithoutFillingTheCommentBox()
            {

                _apointment.Navigate();

                _apointment.Maximize();

                _apointment.CookieButton.Click();

                _apointment.OfferButton.Click();
                Actions action = new Actions(_driver);
                action.ClickAndHold(_apointment.ShuttleElement).Perform();
                _apointment.FillApointment(_makeApointment);
                _makeApointment.UserName = "";
                _makeApointment.CommenentBox = "";
                _makeApointment.UserPhoneNumber = "12345";
                _apointment.Options.Click();
                _apointment.Subbmit.Click();
                // need to find the correct web element to be properly displayed the error message
                Assert.That(_apointment.ErrorMessageField.Displayed); 
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
