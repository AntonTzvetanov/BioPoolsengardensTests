using NUnit.Framework;
using OpenQA.Selenium;

namespace Biopoolsengardens.BioPoolsPage
{
    class BioPoolsPageMethod : BasePage
    {
        public BioPoolsPageMethod(IWebDriver driver) : base(driver)
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

            Assert.AreEqual(expected,AssertLink.Text);

        }

        public IWebElement ArrowButton => Driver.FindElement(By.ClassName("shuttle-Widget"));

        public IWebElement Example => Wait.Until((d) => d.FindElement(By.XPath("//*[@id='grid_9a94f10022']/div[1]")));

        public IWebElement ContactButton => Driver.FindElement(By.Id("element-280"));

        public IWebElement AssertLink => Driver.FindElement(By.XPath("//*[@id='element - 694']/h2"));


    }
}
