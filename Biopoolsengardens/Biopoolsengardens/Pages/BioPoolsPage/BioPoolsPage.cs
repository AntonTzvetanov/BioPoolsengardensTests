using Biopoolsengardens.BioPoolsPage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Reflection;

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
        public void TearDown()
        {
            var name = TestContext.CurrentContext.Test.Name;
            var result = TestContext.CurrentContext.Result.Outcome;

            if (result != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                var directory = Directory.GetCurrentDirectory();

                var fullPath = Path.GetFullPath("..\\..\\..\\Screenshots");

                screenshot.SaveAsFile(fullPath + name + ".png", ScreenshotImageFormat.Png);

            }
            _driver.Quit();


        }
    }
}