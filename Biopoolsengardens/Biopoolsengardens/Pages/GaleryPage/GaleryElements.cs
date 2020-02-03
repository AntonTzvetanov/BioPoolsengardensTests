using OpenQA.Selenium;

namespace Biopoolsengardens.Pages.Galery
{
    public partial class GaleryElements : BasePage
    {

        public GaleryElements(IWebDriver driver)
            :base(driver)
        {

        }


        public void Navigate()
        {

            Driver.Url = "https://www.biopoolsengardens.be/nl";

        }

        public IWebElement GaleryButton => Driver.FindElement(By.LinkText("Realisaties"));

        public IWebElement Pictures => Driver.FindElement(By.Id("element-497"));

        public IWebElement NextPictureButton => Driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/button[2]"));

       


    }
}
