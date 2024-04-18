using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.IO;
using System.Threading;

namespace Biopoolsengardens.Pages
{
    class ContactPage
    {
        [TestFixture]

        public class Contact
        {

            private IWebDriver _driver;
            private ContactPageFactory _user;

            private ContactePageMethod _contactPage;

            [SetUp]

            public void TestInit()
            {

                _driver = new ChromeDriver();
                _user = ContactPageFill.FillUser();
                _contactPage = new ContactePageMethod(_driver);
                _contactPage.Navigate();
                _contactPage.Maximize();

            }

            [Test]


            public void NavigateToContactPageAndFillTheForm()
            {
                _contactPage.CookieButton.Click();
                _contactPage.ContactPageButton.Click();
                Actions action = new Actions(_driver);
                action.ClickAndHold(_contactPage.ShuttleElement).Perform();

                _contactPage.FillForm(_user);

                _contactPage.Submit.Click();

            }

            [Test]

            public void FillFormWithoutEmailAddress()
            {
                _contactPage.Navigate();
                _contactPage.CookieButton.Click();

                _contactPage.ContactPageButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_contactPage.ShuttleElement).Perform();

                _user.RealEmailAddress = "";
                _user.Name = "";

                _contactPage.FillForm(_user);

                _contactPage.Submit.Click();

                Assert.IsTrue(true, _contactPage.ErrorMessageForMissingEmailAddress.Text);
                Assert.IsTrue(_contactPage.ErrorMessageForMissingEmailAddress.Displayed);

            }



            [Test]

            public void FillFormWithoutPhoneNumber()
            {

                _contactPage.Navigate();

                _contactPage.Maximize();

                _contactPage.CookieButton.Click();

                _contactPage.ContactPageButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_contactPage.ShuttleElement).Perform();

                _user.RealTelepfoneNumber = "";

                _contactPage.FillForm(_user);

                // _contactPage.Submit.Click();

                Assert.IsEmpty(_user.RealTelepfoneNumber);

            }

            [Test]

            public void FillFormWithoutFirstAndLastName()
            {
                _contactPage.Navigate();

                _contactPage.Maximize();

                _contactPage.CookieButton.Click();

                _contactPage.ContactPageButton.Click();

                Actions action = new Actions(_driver);
                action.ClickAndHold(_contactPage.ShuttleElement).Perform();

                _user.Name = "";

                _contactPage.FillForm(_user);
                _contactPage.Submit.Click();

                Assert.IsEmpty(_user.Name);

            }

            [Test]

            public void CheckSocialMedialLink()
            {
                _contactPage.Navigate();
                _contactPage.Maximize();
                _contactPage.CookieButton.Click();
                _contactPage.ContactPageButton.Click();

                Actions action = new Actions(_driver);
                action.MoveToElement(_contactPage.ShuttleElement).Perform();

                _contactPage.SocialMediaButton.Click();

                Thread.Sleep(1000);

                var tabs = _driver.WindowHandles;

                if (tabs.Count > 1)
                {
                    _driver.SwitchTo().Window(tabs[1]);
                    _driver.Close();
                    _driver.SwitchTo().Window(tabs[0]);
                }


                Assert.IsTrue(_driver.FindElement(By.TagName("h1")).Displayed);

            }

            [Test]
            public void ValidateErrorMessageWhenSkippingTheCommentBox()
            {
                _contactPage.Navigate();
                _contactPage.Maximize();
                _contactPage.CookieButton.Click();
                _contactPage.ContactPageButton.Click();
               
                Actions action = new Actions(_driver);
                action.MoveToElement(_contactPage.ShuttleElement).Perform();

                _user.CommentBox = "";

                _contactPage.FillForm(_user);
                _contactPage.Submit.Click();

                Assert.AreEqual(_contactPage.ErrorMessageForCommentBox.Text, "Dit veld is verplicht.");
                Assert.IsTrue(_contactPage.ErrorMessageForCommentBox.Displayed);

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
