using NUnit.Framework;
using OpenQA.Selenium;

namespace Biopoolsengardens.Pages.PoolsPageGalery
{
    class PoolsPageGaleryElements : BasePage
    {
        public PoolsPageGaleryElements(IWebDriver driver)
            : base(driver)
        {

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

        public IWebElement SocialLinksGrid => Driver.FindElement(By.Id("element-151"));

        public IWebElement SelectPictures => Driver.FindElement(By.Id("element-758"));

        public IWebElement NextPuctureButton => Driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/button[2]"));

        public IWebElement CloseButton => Driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div[1]/button[1]"));

        public IWebElement PoolsPageCenterPicture => Driver.FindElement(By.ClassName("FlexEmbed-content"));
        public IWebElement InPictureShareButton => Wait.Until((d) => d.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div[1]/button[2]")));
        public IWebElement DownloadImage => Driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div[2]/div/a[4]"));
        public IWebElement PictureForDownload => Driver.FindElement(By.XPath("/html/body/img"));

    }
}
