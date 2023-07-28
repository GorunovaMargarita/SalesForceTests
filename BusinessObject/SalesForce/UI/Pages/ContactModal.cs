using Core.Elements;
using Core.Helpers;
using Core;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using BusinessObject.SalesForce.Model;

namespace BusinessObject.SalesForce.UI.Pages
{
    public class ContactModal : ActionsWithEntity
    {
        Input firstNameInput = new("First Name");
        Input lastNameInput = new("Last Name");
        //Input accountNameInput = new("Account Name");
        Input accountNameInput = new(By.XPath("//label[text()='Account Name']/following-sibling::div//input"));
        Input titleInput = new("Title");
        Input departmentInput = new("Department");
        Input birthdateInput = new("Birthdate");
        Input homePhoneInput = new("Home Phone");
        Input phoneInput = new("Phone");
        Input mobileInput = new("Mobile");
        Input otherPhoneInput = new("Other Phone");
        Input faxInput = new("Fax");
        Input emailInput = new("Email");
        Input assistantInput = new("Assistant");
        Input assistantPhoneInput = new("Asst. Phone");
        //Input mailingStreetInput = new("Mailing Street");
        Input mailingStreetInput = new(By.XPath("//label[text()='Mailing Street']/following-sibling::div/textarea"));
        Input mailingCityInput = new("Mailing City");
        Input mailingStateProvinceInput = new("Mailing State/Province");
        Input mailingCountryInput = new("Mailing Country");
        //Input otherStreetInput = new("Other Street");
        Input otherStreetInput = new(By.XPath("//label[text()='Other Street']/following-sibling::div/textarea"));
        Input otherCityInput = new("Other City");
        Input otherZipPostalCodeInput = new("Other Zip/Postal Code");
        Input otherStateProvinceInput = new("Other State/Province");
        Input otherCountryInput = new("Other Country");
        Input languagesInput = new("Languages");
        Input descriptionInput = new(By.XPath("//label[text()='Description']/following-sibling::div/textarea"));

        DropDown salutationDropDown = new("Salutation");
        DropDown levelDropDown = new("Level");
        DropDown leadSourceDropDown = new(By.XPath("//label[text()='Lead Source']/following-sibling::div//span"));

        Button saveButton = new("SaveEdit");
        Button saveAndNewButton = new("SaveAndNew");
        Button CancelButton = new("CancelEdit");
        Button uploadButton = new(By.XPath("//span[text()='Upload Files']"));

        PartialTextDropDown reportsToDropDown = new("Reports To");


        /// <summary>
        /// Fill new contact form
        /// </summary>
        /// <param name="contact">Contact entity</param>
        /// <returns>ContactModal page</returns>
        [AllureStep]
        public ContactModal FillNewContactForm(Contact contact)
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
            leadSourceDropDown.Select(contact.LeadSource);
            homePhoneInput.EnterText(contact.HomePhone);
            phoneInput.EnterText(contact.Phone);
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
        /// Change account data on edit form
        /// </summary>
        /// <param name="contact">Account entity. Set only changable property values</param>
        /// <returns>ContactModal page</returns>
        [AllureStep]
        public ContactModal EditData(Contact contact)
        {
            ChangeTextValue(contact, "AccountName", accountNameInput);
            ChangeTextValue(contact, "FirstName", firstNameInput);
            ChangeTextValue(contact, "LastName", lastNameInput);
            ChangeTextValue(contact, "Input", titleInput);
            ChangeTextValue(contact, "Fax", faxInput);
            ChangeTextValue(contact, "Departament", departmentInput);
            ChangeTextValue(contact, "Birthdate", birthdateInput);
            ChangeTextValue(contact, "HomePhone", homePhoneInput);
            ChangeTextValue(contact, "Mobile", mobileInput);
            ChangeTextValue(contact, "OtherPhone", otherPhoneInput);
            ChangeTextValue(contact, "Phone", phoneInput);
            ChangeTextValue(contact, "Email", emailInput);
            ChangeTextValue(contact, "Assistant", assistantInput);
            ChangeTextValue(contact, "AssistPhone", assistantPhoneInput);
            ChangeTextValue(contact, "MailingStreet", mailingStreetInput);
            ChangeTextValue(contact, "MailingCity", mailingCityInput);
            ChangeTextValue(contact, "MailingStateProvince", mailingStateProvinceInput);
            ChangeTextValue(contact, "MailingCountry", mailingCountryInput);
            ChangeTextValue(contact, "OtherStreet", otherStreetInput);
            ChangeTextValue(contact, "OtherCity", otherCityInput);
            ChangeTextValue(contact, "OtherZipPostalCode", otherZipPostalCodeInput);
            ChangeTextValue(contact, "OtherStateProvince", otherStateProvinceInput);
            ChangeTextValue(contact, "OtherCountry", otherCountryInput);
            ChangeTextValue(contact, "Languages", languagesInput);
            ChangeTextValue(contact, "Description", descriptionInput);

            ChangeDropDown(contact, "Salutation", salutationDropDown);
            ChangeDropDown(contact, "Level", levelDropDown);

            ChangePartDropDown(contact, "ReportsTo", reportsToDropDown);
            ChangeDropDown(contact, "LeadSource", leadSourceDropDown);

            return this;
        }

        /// <summary>
        /// Confirm contact creation 
        /// </summary>
        /// <returns>ContactPage</returns>
        [AllureStep]
        public ContactPage ConfirmContactCreateOrEdit()
        {
            saveButton.GetElement().Click();
            // WaitHelper.WaitElement(driver, uploadButton.Locator, 100);
            WaitHelper.WaitPageLoaded(driver, 100);
            return new ContactPage();
        }

        /// <summary>
        /// Confirm contact creation and init new contact creation
        /// </summary>
        /// <returns>ContactModal page</returns>
        [AllureStep]
        public ContactModal ConfirmAndNewContactCreation()
        {
            saveAndNewButton.GetElement().Click();
            return this;
        }

        /// <summary>
        /// Cancel contact creation
        /// </summary>
        /// <returns>ContactPage</returns>
        [AllureStep]
        public ContactPage CancelContactCreation()
        {
            CancelButton.GetElement().Click();
            return new ContactPage();
        }
    }
}
