using Biopoolsengardens.Pages.PoolsPageGalery;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Reflection;
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

            [SetUp]

            public void SetUp()
            {
                _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                _driver.Manage().Window.Maximize();

                _poolsGalery = new PoolsPageGaleryElements(_driver);

                _poolsGalery.Maximize();

                _poolsGalery.Navigate();
            }

            [Test]


            public void NavigateToPoolsGaleryAndVerifyThatAllPicturesAreDisplayed()
            {
                _poolsGalery.CookieButton.Click();

                _poolsGalery.PoolsButton.Click();
                Assert.IsTrue(true, _poolsGalery.PoolsPageCenterPicture.Enabled.ToString(), Is.True);

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
                    Assert.That(true, _poolsGalery.SelectPictures.Selected.ToString(), Is.Ordered);
                }

                Assert.That(true, _poolsGalery.SelectPictures.Selected.ToString(), Is.All);
                _poolsGalery.CloseButton.Click();
                _poolsGalery.MoveUpArrowButton.Click();
                
            }

            [Test]
            public void TestSomething()
            {



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
                _driver.Close();
            }

        }


    }

}





