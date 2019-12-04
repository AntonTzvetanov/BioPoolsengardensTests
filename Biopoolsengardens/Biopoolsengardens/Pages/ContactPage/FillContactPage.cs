namespace Biopoolsengardens.Pages
{
    public partial class ContactePageMethod
    {


        public void FillForm(ContactPageFactory contacts)
        {

            ContactField.SendKeys(contacts.Name);

            Telephone.SendKeys(contacts.RealTelepfoneNumber);

            Email.SendKeys(contacts.RealEmailAddress);

            TextArea.SendKeys(contacts.CommentBox);

        }

    }
}
