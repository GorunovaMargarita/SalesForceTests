using Core.Elements;
using Core.Helpers;
using Core;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using BusinessObject.SalesForce.Model;

namespace BusinessObject.SalesForce.UI.Pages
{
    public class NewContactModal
    {
        DropDown salutationDropDown = new("Salutation");
        Input firstNameInput = new("First Name");
        Input lastNameInput = new("Last Name");
        Input accountNameInput = new("Account Name");
        Input titleInput = new("Title");
        Input departmentInput = new("Department");
        Input birthdateInput = new("Birthdate");
        PartialTextDropDown reportsToDropDown = new("Reports To");
        PartialTextDropDown leadSourceDropDown = new("Lead Source");
        Input homePhoneInput = new("Home Phone");
        Input mobileInput = new("Mobile");
        Input otherPhoneInput = new("Other Phone");
        Input faxInput = new("Fax");
        Input emailInput = new("Email");
        Input assistantInput = new("Assistant");
        Input assistantPhoneInput = new("Asst. Phone");
        Input mailingStreetInput = new("Mailing Street");
        Input mailingCityInput = new("Mailing City");
        Input mailingStateProvinceInput = new("Mailing State/Province");
        Input mailingCountryInput = new("Mailing Country");
        Input otherStreetInput = new("Other Street");
        Input otherCityInput = new("Other City");
        Input otherZipPostalCodeInput = new("Other Zip/Postal Code");
        Input otherStateProvinceInput = new("Other State/Province");
        Input otherCountryInput = new("Other Country");
        Input languagesInput = new("Languages");
        DropDown levelDropDown = new("Level");
        Input descriptionInput = new("Description");

        Button saveButton = new("SaveEdit");
        Button saveAndNewButton = new("SaveAndNew");
        Button CancelButton = new("CancelEdit");

        /// <summary>
        /// Fill new contact form
        /// </summary>
        /// <param name="contact">Contact entity</param>
        /// <returns></returns>
        [AllureStep]
        public NewContactModal FillNewContactForm(Contact contact)
        {
            Log.Instance.Logger.Info($"Contact model:\r\n{contact.ToString()}");

            salutationDropDown.Select(contact.Salutation);
            firstNameInput.EnterText(contact.FirstName);
            lastNameInput.EnterText(contact.LastName);
            accountNameInput.EnterText(contact.AccountName);
            titleInput.EnterText(contact.Title);
            departmentInput.EnterText(contact.Departament);
            birthdateInput.EnterText(contact.Birthdate);
            reportsToDropDown.SelectByPartText(contact.ReportsTo);
            leadSourceDropDown.SelectByPartText(contact.LeadSource);
            homePhoneInput.EnterText(contact.HomePhone);
            mobileInput.EnterText(contact.Mobile);
            otherPhoneInput.EnterText(contact.OtherPhone);
            faxInput.EnterText(contact.Fax);
            emailInput.EnterText(contact.Email);
            assistantInput.EnterText(contact.Assistant);
            assistantPhoneInput.EnterText(contact.AssistPhone);
            mailingStreetInput.EnterText(contact.MailingStreet);
            mailingCityInput.EnterText(contact.MailingCity);
            mailingStateProvinceInput.EnterText(contact.MailingStateProvince);
            mailingCountryInput.EnterText(contact.MailingCountry);
            otherStreetInput.EnterText(contact.OtherStreet);
            otherCityInput.EnterText(contact.OtherCity);
            otherZipPostalCodeInput.EnterText(contact.OtherZipPostalCode);
            otherStateProvinceInput.EnterText(contact.OtherStateProvince);
            otherCountryInput.EnterText(contact.OtherCountry);
            languagesInput.EnterText(contact.Languages);
            levelDropDown.Select(contact.Level);
            descriptionInput.EnterText(contact.Description);

            return this;
        }

        /// <summary>
        /// Change contact data
        /// </summary>
        /// <param name="contact">Contact entity. Set only changable property values</param>
        /// <returns></returns>
        [AllureStep]
        public NewContactModal EditData(Contact contact)
        {
            if (!contact.AccountName.Equals(accountNameInput.GetElement().Text) && !(contact.AccountName == null))
            {
                accountNameInput.GetElement().Clear();
                accountNameInput.EnterText(contact.AccountName);
            }
            if (!contact.FirstName.Equals(firstNameInput.GetElement().Text) && !(contact.FirstName == null))
            {
                firstNameInput.GetElement().Clear();
                firstNameInput.EnterText(contact.FirstName);
            }
            if (!contact.LastName.Equals(lastNameInput.GetElement().Text) && !(contact.LastName == null))
            {
                lastNameInput.GetElement().Clear();
                lastNameInput.EnterText(contact.LastName);
            }
            if (!contact.Title.Equals(titleInput.GetElement().Text) && !(contact.Title == null))
            {
                titleInput.GetElement().Clear();
                titleInput.EnterText(contact.Title);
            }
            if (!contact.Salutation.Equals(salutationDropDown.GetElement().Text) && !(contact.Salutation == null))
            {
                salutationDropDown.GetElement().Clear();
                salutationDropDown.Select(contact.Salutation);
            }
            if (!contact.HomePhone.Equals(homePhoneInput.GetElement().Text) && !(contact.HomePhone == null))
            {
                homePhoneInput.GetElement().Clear();
                homePhoneInput.EnterText(contact.HomePhone);
            }
            if (!contact.Mobile.Equals(mobileInput.GetElement().Text) && !(contact.Mobile == null))
            {
                mobileInput.GetElement().Clear();
                mobileInput.EnterText(contact.Mobile);
            }
            if (!contact.OtherPhone.Equals(otherPhoneInput.GetElement().Text) && !(contact.OtherPhone == null))
            {
                otherPhoneInput.GetElement().Clear();
                otherPhoneInput.EnterText(contact.OtherPhone);
            }
            if (!contact.Fax.Equals(faxInput.GetElement().Text) && !(contact.Fax == null))
            {
                faxInput.GetElement().Clear();
                faxInput.EnterText(contact.Fax);
            }
            if (!contact.Email.Equals(emailInput.GetElement().Text) && !(contact.Email == null))
            {
                emailInput.GetElement().Clear();
                emailInput.EnterText(contact.Email);
            }
            /*
            departmentInput.EnterText(contact.Departament);
            birthdateInput.EnterText(contact.Birthdate);
            reportsToDropDown.SelectByPartText(contact.ReportsTo);
            leadSourceDropDown.SelectByPartText(contact.LeadSource);
            assistantInput.EnterText(contact.Assistant);
            assistantPhoneInput.EnterText(contact.AssistPhone);
            mailingStreetInput.EnterText(contact.MailingStreet);
            mailingCityInput.EnterText(contact.MailingCity);
            mailingStateProvinceInput.EnterText(contact.MailingStateProvince);
            mailingCountryInput.EnterText(contact.MailingCountry);
            otherStreetInput.EnterText(contact.OtherStreet);
            otherCityInput.EnterText(contact.OtherCity);
            otherZipPostalCodeInput.EnterText(contact.OtherZipPostalCode);
            otherStateProvinceInput.EnterText(contact.OtherStateProvince);
            otherCountryInput.EnterText(contact.OtherCountry);
            languagesInput.EnterText(contact.Languages);
            levelDropDown.Select(contact.Level);
            descriptionInput.EnterText(contact.Description);*/

            return this;
        }

        [AllureStep]
        public ContactPage ConfirmContactCreation()
        {
            saveButton.GetElement().Click();
            WaitHelper.WaitElement(Browser.Instance.Driver, By.CssSelector("span[title=Follow]"));
            return new ContactPage();
        }

        [AllureStep]
        public NewContactModal ConfirmAndNewContractCreation()
        {
            saveAndNewButton.GetElement().Click();
            return this;
        }

        [AllureStep]
        public ContactPage CancelContractCreation()
        {
            CancelButton.GetElement().Click();
            return new ContactPage();
        }
    }
}
