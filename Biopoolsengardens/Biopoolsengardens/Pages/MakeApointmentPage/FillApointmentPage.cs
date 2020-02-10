namespace Biopoolsengardens.Pages
{
    public partial class MakeApointmentElements
    {
        public void FillApointment(UserProperties user)
        {

            Name.SendKeys(user.UserName);

            Family.SendKeys(user.UserFamilyName);

            Telephone.SendKeys(user.UserPhoneNumber);

            CommentBox.SendKeys(user.CommenentBox);

            Email.SendKeys(user.UserEmailAddress);

                   
        }

    }
}
