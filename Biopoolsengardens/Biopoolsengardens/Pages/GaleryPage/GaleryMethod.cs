using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biopoolsengardens.Pages.Galery
{
   public partial class GaleryMethod : BasePage
    {

        public GaleryMethod(IWebDriver driver)
            :base(driver)
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

        public IWebElement GaleryButton => Driver.FindElement(By.LinkText("Realisaties"));

        public IWebElement Pictures => Driver.FindElement(By.Id("element-497"));

        public IWebElement NextPictureButton => Driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/button[2]"));

       


    }
}
