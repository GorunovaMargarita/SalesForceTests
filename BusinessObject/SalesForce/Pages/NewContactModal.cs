using Core.Elements;
using Core.Helpers;
using Core;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using BusinessObject.SalesForce.Model;

namespace BusinessObject.SalesForce.Pages
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

        [AllureStep]
        public NewContactModal FillNewContactForm(Contact contact)
        {
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
