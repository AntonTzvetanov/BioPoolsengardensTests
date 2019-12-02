using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biopoolsengardens.Pages.SwimmingPondsPage
{
    class SwimmingPondsMethod : BasePage
    {

        public SwimmingPondsMethod(IWebDriver driver) :base(driver)
        {

        }

        public void Navigate()
        {

            Driver.Url = "https://www.biopoolsengardens.be/nl";

        }

        public void Maximize()
        {

            Driver.Manage().Window.Maximize();

        }


        public void AssertHref(string expected)
        {
            Assert.AreEqual(expected, "");
        }

        public IWebElement Example => Wait.Until((d) => d.FindElement(By.LinkText("Zwemvijvers")));

        public IWebElement Grid => Driver.FindElement(By.Id("element-141"));

    }
}
