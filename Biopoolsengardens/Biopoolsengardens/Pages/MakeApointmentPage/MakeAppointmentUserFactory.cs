namespace Biopoolsengardens.Pages
{
    public partial class MakeAppointmentUserFactory 
    {

        public static UserProperties User()
        {

            return new UserProperties
            {
                UserName = "Anton",

                UserFamilyName = "Tsvetanov",

                UserPhoneNumber = "098781721435465",

                UserEmailAddress = "test@domain.com",

                CommenentBox = "test",

            };

        }

    }
}
