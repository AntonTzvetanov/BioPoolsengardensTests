using NUnit.Framework;
using OpenQA.Selenium;

namespace Biopoolsengardens.BioPoolsPage
{
    class BioPoolsPageMethod : BasePage
    {
        public BioPoolsPageMethod(IWebDriver driver) : base(driver)
        {
        }

       
        public void Navigate()
        {

            Driver.Url = "https://www.biopoolsengardens.be/nl";

        }

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


        public IWebElement ArrowButton => Driver.FindElement(By.ClassName("shuttle-Widget"));

        public IWebElement Example => Wait.Until((d) => d.FindElement(By.XPath("//*[@id='grid_9a94f10022']/div[1]")));

        public IWebElement ContactButton => Driver.FindElement(By.Id("element-280"));

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
