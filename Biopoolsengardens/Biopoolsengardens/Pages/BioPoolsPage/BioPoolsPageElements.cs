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

        public IWebElement FirstArrowDown => Driver.FindElement(By.Id("element-289"));

        public IWebElement SecondArrowDown => Driver.FindElement(By.Id("element-573"));
        public IWebElement ThirdArrowDown => Driver.FindElement(By.Id("element-581"));

        public IWebElement ForthArrodDown => Driver.FindElement(By.Id("element-286"));

        public IWebElement LinkToContactPage => Driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div/div/div/div/div/div[2]/div/div/div/div[12]/div/div/div[2]/div/p[10]/a"));

        public IWebElement SugarValeyElement => Driver.FindElement(By.Id("element-589"));
    }
}
