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
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
        }

        public void Maximize()
        {

            Driver.Manage().Window.Maximize();

        }


        public IWebDriver Driver => _driver;

        public WebDriverWait Wait => _wait;

        public IWebElement CookieButton => Driver.FindElement(By.ClassName("cookieButton"));

        public IWebElement MoveUpArrowButton => Wait.Until((e) => e.FindElement(By.ClassName("custom-style-33")));


        public void Navigate(string url)
        {
            Driver.Url = url;
        }

    

    }


   
}
