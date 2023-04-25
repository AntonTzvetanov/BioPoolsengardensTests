using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Biopoolsengardens
{
    public abstract class BasePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        public void Maximize()
        {

            Driver.Manage().Window.Maximize();

        }


        public IWebDriver Driver => _driver;

        public WebDriverWait Wait => _wait;

        public IWebElement CookieButton => Driver.FindElement(By.ClassName("cookieButton"));

        public IWebElement MoveUpArrowButton => Wait.Until((e) => e.FindElement(By.ClassName("custom-style-33")));


        public void AssertIsDisplayedGratisOfferLink(string expected)
        {

            Assert.AreEqual(expected, AssertLink.Text);

        }


        public void MakeApointmentAssert(string expected)
        {

            Assert.AreEqual(expected, AssertLink2.Text);

        }

        public void BioPoolsAssertLink(string expected)
        {

            Assert.AreEqual(expected, AssertBioPoolsLink.Text);

        }

        public void SwimmingPondsAssertLink(string expected)
        {

            Assert.AreEqual(expected, AssertSwimmingPondsLink.Text);

        }

        public void GardenAndNaturalPondsLink(string expected)
        {

            Assert.AreEqual(expected, AssertGardenAndNaturalPondsLink.Text);

        }

        public void SwimmingPoolsLink(string expected)
        {

            Assert.AreEqual(expected, AssertSwimmingPoolsLink.Text);

        }

        public void RealizationLink(string expected)
        {

            Assert.AreEqual(expected, AssertRealizationLink.Text);

        }

        public void ContactLink(string expected)
        {

            Assert.AreEqual(expected, AssertContactLink.Text);

        }


        public IWebElement AssertLink => Driver.FindElement(By.Id("element-883"));

        public IWebElement AssertLink2 => Driver.FindElement(By.Id("element-773"));

        public IWebElement AssertBioPoolsLink => Driver.FindElement(By.LinkText("Biozwembaden"));

        public IWebElement AssertSwimmingPondsLink => Driver.FindElement(By.LinkText("Zwemvijvers"));

        public IWebElement AssertGardenAndNaturalPondsLink => Driver.FindElement(By.LinkText("Tuin- en natuurvijvers"));

        public IWebElement AssertSwimmingPoolsLink => Driver.FindElement(By.LinkText("Zwembaden"));

        public IWebElement AssertRealizationLink => Driver.FindElement(By.LinkText("Realisaties"));

        public IWebElement AssertContactLink => Driver.FindElement(By.LinkText("Contact"));

        


    }


}
