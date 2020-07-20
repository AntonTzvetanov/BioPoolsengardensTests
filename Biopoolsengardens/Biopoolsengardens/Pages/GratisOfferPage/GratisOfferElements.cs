using NUnit.Framework;
using OpenQA.Selenium;

namespace Biopoolsengardens.Pages
{
    public partial class GratisOfferSelectors : BasePage
    {

        public GratisOfferSelectors(IWebDriver driver)
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

        public IWebElement ShuttleButton => Driver.FindElement(By.Id("element-883"));

        public IWebElement Names => Driver.FindElement(By.Id("fields[911]"));

        public IWebElement TelephoneNumber => Driver.FindElement(By.Id("fields[912]"));

        public IWebElement EmailAddress => Driver.FindElement(By.Id("fields[913]"));

        public IWebElement Ongoveer => Driver.FindElement(By.Id("fields[917]"));

        public IWebElement InterestButton => Driver.FindElement(By.Name("fields[916][]"));

        public IWebElement TextBox => Driver.FindElement(By.Id("fields[914]"));

        public IWebElement SubbmitButton => Driver.FindElement(By.XPath("//*[@id='grid_48191dcd95']/div[2]/div/div[2]/div/form/div[5]/div/div/button"));


    }
}
