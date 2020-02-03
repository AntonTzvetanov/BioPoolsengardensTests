using NUnit.Framework;
using OpenQA.Selenium;

namespace Biopoolsengardens.Pages.PoolsPageGalery
{
    class PoolsPageGaleryElements : BasePage
    {
        public PoolsPageGaleryElements(IWebDriver driver)
            :base(driver)
        {

        }

        public void Maximize()
        {
            Driver.Manage().Window.Maximize();
        }

        public void Navigate()
        {
            Driver.Url = "https://www.biopoolsengardens.be/nl";
        }

        public void AssertHref(string expected)
        {
            Assert.AreEqual(expected, "");
        }

        public IWebElement PoolsButton => Driver.FindElement(By.LinkText("Zwembaden"));

        public IWebElement SocialLinksGrid => Driver.FindElement(By.Id("grid_2f3d0e64e9"));

        public IWebElement SelectPictures => Driver.FindElement(By.Id("element-758"));

        public IWebElement NextPuctureButton => Driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/button[2]"));

        public IWebElement CloseButton => Driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div[1]/button[1]"));

    }
}
