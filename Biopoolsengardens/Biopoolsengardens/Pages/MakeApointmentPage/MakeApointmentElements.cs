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



        public void AssertHref(string expected)
        {
            Assert.AreEqual(expected, "");
        }

        public IWebElement OfferButton => Driver.FindElement(By.Id("element-773"));

        public IWebElement ShuttleElement => Driver.FindElement(By.Id("grid_2f3d0e64e9"));

        public IWebElement Name => Driver.FindElement(By.Id("fields[554]"));

        public IWebElement Family => Driver.FindElement(By.Id("fields[562]"));

        public IWebElement Telephone => Driver.FindElement(By.Id("fields[555]"));

        public IWebElement Options => Driver.FindElement(By.ClassName("Field-checkbox"));

        public IWebElement Email => Driver.FindElement(By.Id("fields[556]"));

        public IWebElement CommentBox => Driver.FindElement(By.Id("fields[557]"));

        public IWebElement Subbmit => Driver.FindElement(By.XPath("//*[@id='grid_48191dcd95']/div[2]/div/div[2]/div/form/div[5]/div/div/button"));
    }
}
