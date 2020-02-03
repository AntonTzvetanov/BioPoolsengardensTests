using NUnit.Framework;
using OpenQA.Selenium;

namespace Biopoolsengardens.BioPoolsPage
{
    class BioPoolsPageElements : BasePage
    {
        public BioPoolsPageElements(IWebDriver driver) : base(driver)
        {
        }

       
        public void Navigate()
        {

            Driver.Url = "https://www.biopoolsengardens.be/nl";

        }

     

        public IWebElement ArrowButton => Driver.FindElement(By.ClassName("shuttle-Widget"));

        public IWebElement Example => Wait.Until((d) => d.FindElement(By.XPath("//*[@id='grid_9a94f10022']/div[1]")));

        public IWebElement ContactButton => Driver.FindElement(By.Id("element-280"));


    }
}
