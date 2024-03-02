using NUnit.Framework;
using OpenQA.Selenium;

namespace Biopoolsengardens.Pages
{
    class SwimmingPondsElements : BasePage
    {

        public SwimmingPondsElements(IWebDriver driver)
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

        public IWebElement Example => Wait.Until((d) => d.FindElement(By.LinkText("Zwemvijvers")));

        public IWebElement Grid => Driver.FindElement(By.Id("element-141"));

        public IWebElement VideoPlayer => Driver.FindElement(By.Id("element-651"));
        public IWebElement LakeDataGrid => Driver.FindElement(By.Id("element-416"));

    }
}
