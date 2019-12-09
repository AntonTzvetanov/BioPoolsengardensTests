namespace Biopoolsengardens.Pages
{
    public  class ContactPageFill
    {

        public static ContactPageFactory FillUser()
        {
            return new ContactPageFactory
            {

                Name = "TonyCvetanov",

                RealTelepfoneNumber = "922012431",

                RealEmailAddress = "test@domain.com",

                CommentBox = "test"

            };

        }
    }
}
