using NUnit.Framework;
using OpenQA.Selenium;

namespace Biopoolsengardens.Pages
{
    public partial class MakeApointmentElements : BasePage
    {
        public MakeApointmentElements(IWebDriver driver)
            : base(driver)
        {

        }

        public void Navigate()
        {

            Driver.Url = "https://www.biopoolsengardens.be/nl";

        }

        public void AssertHref(string expected) => Assert.AreEqual(expected, "");

        public IWebElement OfferButton => Driver.FindElement(By.Id("element-773"));

        public IWebElement ShuttleElement => Driver.FindElement(By.Id("element-567"));

        public IWebElement Name => Driver.FindElement(By.Id("fields[554]"));

        public IWebElement Family => Driver.FindElement(By.Id("fields[562]"));

        public IWebElement Telephone => Driver.FindElement(By.Id("fields[555]"));

        public IWebElement Options => Driver.FindElement(By.ClassName("Field-checkbox"));

        public IWebElement Email => Driver.FindElement(By.Id("fields[556]"));

        public IWebElement CommentBox => Driver.FindElement(By.Id("fields[557]"));

        public IWebElement Subbmit => Wait.Until((e) => e.FindElement(By.ClassName("Form--vertical")));

        public IWebElement ErrorMessageField => Driver.FindElement(By.Id("parsley-id-5")); 

    }
}
