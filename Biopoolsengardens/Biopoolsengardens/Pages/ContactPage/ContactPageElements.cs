using NUnit.Framework;
using OpenQA.Selenium;

namespace Biopoolsengardens.Pages
{
   public partial class ContactePageMethod : BasePage
    {
        public ContactePageMethod(IWebDriver driver) : base(driver)
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

            Assert.AreEqual(expected,"");

        }

        public IWebElement ContactPageButton => Driver.FindElement(By.LinkText("Contact"));

        public IWebElement ShuttleElement => Driver.FindElement(By.Id("grid_2f3d0e64e9"));

        public IWebElement ContactField => Driver.FindElement(By.Id("fields[538]"));

        public IWebElement Telephone => Driver.FindElement(By.Id("fields[541]"));

        public IWebElement Email => Driver.FindElement(By.Id("fields[539]"));

        public IWebElement TextArea => Driver.FindElement(By.Id("fields[540]"));

        public IWebElement Submit => Driver.FindElement(By.XPath("//*[@id='grid_48191dcd95']/div[2]/div/div[2]/div/form/div[5]/div/div/button"));


    }
}
