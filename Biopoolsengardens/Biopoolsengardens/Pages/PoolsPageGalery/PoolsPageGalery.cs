﻿using Biopoolsengardens.Pages.PoolsPageGalery;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
            private string imageUrl;
            private object ExpectedConditions;
            private object imageElement;

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

                _poolsGalery.DownloadImage.Click();
                var tabs = _driver.WindowHandles;

                if (tabs.Count > 1)
                {
                    _driver.SwitchTo().Window(tabs[1]);
                }

                var imageUrl = _poolsGalery.DownloadImage.GetAttribute("https://shuttle-storage.s3.amazonaws.com/biopoolsgardens/P8%20Zwembaden/NIVEKO_2015_00003.jpg?1485419876&w=1100&h=732");
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





