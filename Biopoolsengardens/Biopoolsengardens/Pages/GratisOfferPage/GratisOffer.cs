using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using System;

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
                _offer.Navigate();

                _offer.Maximize();

                _offer.CookieButton.Click();

                _offer.ShuttleButton.Click();

                _offer.InterestButton.Click();

                _fillOffer.FirstAndLastName = "";

                _offer.FillOfferForm(_fillOffer);

                // _offer.SubbmitButton.Click();



            }


            [Test]
            [Retry(1)]

            public void TestWithoutTelephoneNumber()
            {

                _offer.Navigate();

                _offer.Maximize();

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

                _offer.Navigate();

                _offer.Maximize();

                _offer.CookieButton.Click();

                _offer.ShuttleButton.Click();

                _offer.InterestButton.Click();

                _fillOffer.EmailAddress = "";

                _offer.FillOfferForm(_fillOffer);

                // _offer.SubbmitButton.Click();

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
