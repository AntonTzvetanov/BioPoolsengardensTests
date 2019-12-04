namespace Biopoolsengardens.Pages
{
    public partial class GratisOfferMethod
    {

        public void FillOfferForm(OffersProperties offer)
        {
            Names.SendKeys(offer.FirstAndLastName);

            TelephoneNumber.SendKeys(offer.TelephoneNumber);

            EmailAddress.SendKeys(offer.EmailAddress);

            TextBox.SendKeys(offer.TextBox);

            Ongoveer.SendKeys(offer.Ongover);

        }

    }
}
