using OpenQA.Selenium;

namespace Biopoolsengardens.Pages
{
    public partial class ContactePageMethod : BasePage
    {
        public ContactePageMethod(IWebDriver driver) 
            : base(driver)
        {
            
        }

        public void Navigate()
        {

            Driver.Url = "https://www.biopoolsengardens.be/nl";

        }

        public IWebElement ContactPageButton => Driver.FindElement(By.LinkText("Contact"));

        public IWebElement ShuttleElement => Driver.FindElement(By.Id("grid_6eae61039e"));

        public IWebElement ContactField => Driver.FindElement(By.Id("fields[538]"));

        public IWebElement Telephone => Driver.FindElement(By.Id("fields[541]"));

        public IWebElement Email => Driver.FindElement(By.Id("fields[539]"));

        public IWebElement TextArea => Driver.FindElement(By.Id("fields[540]"));


        public IWebElement Submit => Wait.Until((e) => e.FindElement(By.ClassName("Form-controls")));

       
        public IWebElement SocialMediaButton => Driver.FindElement(By.Id("element-151"));

        public IWebElement NivekoLinkToWebsite => Driver.FindElement(By.ClassName("FlexEmbed"));

        public IWebElement ErrorMessageForMissingEmailAddress => Driver.FindElement(By.Id("parsley-id-9"));

        public IWebElement ErrorMessageForCommentBox => Driver.FindElement(By.Id("parsley-id-15"));
    }
}
