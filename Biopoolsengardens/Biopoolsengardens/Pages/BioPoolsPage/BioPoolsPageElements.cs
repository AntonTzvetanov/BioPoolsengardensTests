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



        public IWebElement ArrowButton => Driver.FindElement(By.Id("element-283"));

        public IWebElement Example => Wait.Until((d) => d.FindElement(By.ClassName("Nav-itemTarget EntityTrigger-772-0-2 custom-style-navigation-item custom-style-navigation-item-active")));

        public IWebElement ContactButton => Driver.FindElement(By.ClassName("Button EntityTrigger-159 custom-style-button"));


    }
}
