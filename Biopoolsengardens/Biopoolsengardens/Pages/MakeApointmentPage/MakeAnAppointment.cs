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
                Assert.Fail();
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
}
