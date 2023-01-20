using OpenQA.Selenium;

namespace Biopoolsengardens.BioPoolsPage
{
    class BioPoolsPageElements : BasePage
    {
        public BioPoolsPageElements(IWebDriver driver) 
        : base(driver)
        {
        }


        public void Navigate()
        {
            Driver.Url = "https://www.biopoolsengardens.be/nl";
        }

        public IWebElement ArrowButton => Driver.FindElement(By.Id("element-283"));

        public IWebElement BioPoolsPageButton => Driver.FindElement(By.XPath("/html/body/div[1]/div/section[1]/div/div/div[2]/div/div/div/div[3]/div[1]/ul/li[2]/a"));

        public IWebElement BiopoolsInfoTextHeader => Driver.FindElement(By.Id("element-170"));

        public IWebElement BiopoolsInfoText => Driver.FindElement(By.Id("element-171"));
    }
}
