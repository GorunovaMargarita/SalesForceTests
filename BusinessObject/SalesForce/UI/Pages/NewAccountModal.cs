using BusinessObject.SalesForce.Model;
using Core;
using Core.Elements;
using Core.Helpers;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace BusinessObject.SalesForce.UI.Pages
{
    public class NewAccountModal : ActionsWithEntity
    {
        Input accountNameInput = new("Account Name");
        Input accountNumberInput = new("Account Number");
        Input accountSiteInput = new("Account Site");
        Input annualRevenueInput = new("Annual Revenue");
        Input phoneInput = new("Phone");
        Input faxInput = new("Fax");
        Input websiteInput = new("Website");
        Input tickerSymbolInput = new("Ticker Symbol");
        Input employeesInput = new("Employees");
        Input sicCodeInput = new("SIC Code");
        Input billingStreetInput = new(By.XPath("//label[text()='Billing Street']/following-sibling::div/textarea"));
        Input billingCityInput = new("Billing City");
        Input billingStateProvinceInput = new("Billing State/Province");
        Input billingCountryInput = new("Billing Country");
        Input shippingStreetInput = new(By.XPath("//label[text()='Shipping Street']/following-sibling::div/textarea"));
        Input shippingCityInput = new("Shipping City");
        Input shippingZipPostalCodeInput = new("Shipping Zip/Postal Code");
        Input shippingStateProvinceInput = new("Shipping State/Province");
        Input shippingCountryInput = new("Shipping Country");
        Input slaExpirationDateInput = new("SLA Expiration Date");
        Input numberOfLocationsInput = new("Number of Locations");
        Input slaSerialNumberInput = new("SLA Serial Number");
        Input descriptionInput = new(By.XPath("//label[text()='Description']/following-sibling::div/textarea"));

        DropDown typeDropDown = new("Type");
        DropDown industryDropDown = new("Industry");
        DropDown ratingDropDown = new("Rating");
        DropDown ownershipDropDown = new("Ownership");
        DropDown customerPriorityDropDown = new("Customer Priority");
        DropDown activeDropDown = new("Active");
        DropDown slaDropDown = new("SLA");
        DropDown upsellOpportunityDropDown = new("Upsell Opportunity");

        Button saveButton = new("SaveEdit");
        Button saveAndNewButton = new("SaveAndNew");
        Button cancelButton = new("Cancel");

        PartialTextDropDown parentAccountDropDown = new("Parent Account");

        /// <summary>
        /// Fill new account form
        /// </summary>
        /// <param name="account">Account entity</param>
        /// <returns>NewAccountModal page</returns>
        [AllureStep]
        public NewAccountModal FillNewAccountForm(Account account)
        {
            Log.Instance.Logger.Info($"Account model:\r\n{account.ToString()}");

            accountNameInput.EnterText(account.AccountName);
            parentAccountDropDown.Select(account.ParentAccount);
            accountNumberInput.EnterText(account.AccountNumber);
            accountSiteInput.EnterText(account.AccountSite);
            typeDropDown.Select(account.Type);
            industryDropDown.Select(account.Industry);
            annualRevenueInput.EnterText(account.AnnualRevenue);
            ratingDropDown.Select(account.Rating);
            phoneInput.EnterText(account.Phone);
            faxInput.EnterText(account.Fax);
            websiteInput.EnterText(account.Website);
            tickerSymbolInput.EnterText(account.TickerSymbol);
            ownershipDropDown.Select(account.Ownership);
            employeesInput.EnterText(account.Employees);
            sicCodeInput.EnterText(account.SICCode);
            billingStreetInput.EnterText(account.BillingStreet);
            billingCityInput.EnterText(account.BillingCity);
            billingStateProvinceInput.EnterText(account.BillingStateProvince);
            billingCountryInput.EnterText(account.BillingCountry);
            shippingStreetInput.EnterText(account.ShippingStreet);
            shippingCityInput.EnterText(account.ShippingCity);
            shippingZipPostalCodeInput.EnterText(account.ShippingZipPostalCode);
            shippingStateProvinceInput.EnterText(account.ShippingStateProvince);
            shippingCountryInput.EnterText(account.ShippingCountry);
            customerPriorityDropDown.Select(account.CustomerPriority);
            slaExpirationDateInput.EnterText(account.SLAExpirationDate);
            numberOfLocationsInput.EnterText(account.NumberOfLocations);
            activeDropDown.Select(account.Active);
            slaDropDown.Select(account.SLA);
            slaSerialNumberInput.EnterText(account.SLASerialNumber);
            upsellOpportunityDropDown.Select(account.UpsellOpportunity);
            descriptionInput.EnterText(account.Description);

            return this;
        }

        /// <summary>
        /// Change account data on edit form
        /// </summary>
        /// <param name="account">Account entity. Set only changable property values</param>
        /// <returns>NewAccountModal page</returns>
        [AllureStep]
        public NewAccountModal EditData(Account account)
        {
            ChangeTextValue(account, "AccountName", accountNameInput);
            ChangeTextValue(account, "AccountNumber", accountNumberInput);
            ChangeTextValue(account, "AccountSite", accountSiteInput);
            ChangeTextValue(account, "Phone", phoneInput);
            ChangeTextValue(account, "Fax", faxInput);
            ChangeTextValue(account, "Website", websiteInput);
            ChangeTextValue(account, "AnnualRevenue", annualRevenueInput);
            ChangeTextValue(account, "TickerSymbol", tickerSymbolInput);
            ChangeTextValue(account, "Employees", employeesInput);
            ChangeTextValue(account, "SICCode", sicCodeInput);
            ChangeTextValue(account, "BillingStreet", billingStreetInput);
            ChangeTextValue(account, "BillingCity", billingCityInput);
            ChangeTextValue(account, "BillingStateProvince", billingStateProvinceInput);
            ChangeTextValue(account, "BillingCountry", billingCountryInput);
            ChangeTextValue(account, "ShippingStreet", shippingStreetInput);
            ChangeTextValue(account, "ShippingCity", shippingCityInput);
            ChangeTextValue(account, "ShippingZipPostalCode", shippingZipPostalCodeInput);
            ChangeTextValue(account, "ShippingStateProvince", shippingStateProvinceInput);
            ChangeTextValue(account, "ShippingCountry", shippingCountryInput);
            ChangeTextValue(account, "SLAExpirationDate", slaExpirationDateInput);
            ChangeTextValue(account, "NumberOfLocations", numberOfLocationsInput);
            ChangeTextValue(account, "SLASerialNumber", slaSerialNumberInput);
            ChangeTextValue(account, "Description", descriptionInput);

            ChangeDropDown(account, "Type", typeDropDown);
            ChangePartDropDown(account, "ParentAccount", parentAccountDropDown);
            ChangeDropDown(account, "Rating", ratingDropDown);
            ChangeDropDown(account, "Ownership", ownershipDropDown);
            ChangeDropDown(account, "CustomerPriority", customerPriorityDropDown);
            ChangeDropDown(account, "Active", activeDropDown);
            ChangeDropDown(account, "SLA", slaDropDown);
            ChangeDropDown(account, "UpsellOpportunity", upsellOpportunityDropDown);

            return this;
        }

        /// <summary>
        /// Confirm account creation or edit
        /// </summary>
        /// <returns>AccountPage</returns>
        [AllureStep]
        public AccountPage ConfirmAccountCreateOrEdit()
        {
            saveButton.GetElement().Click();
            return new AccountPage();
        }

        /// <summary>
        /// Confirm account creation and init new account creation
        /// </summary>
        /// <returns>NewAccountModal page</returns>
        [AllureStep]
        public NewAccountModal ConfirmAndNewAccountCreation()
        {
            saveAndNewButton.GetElement().Click();
            return this;
        }

        /// <summary>
        /// Cancel account creation
        /// </summary>
        /// <returns>AccountPage</returns>
        [AllureStep]
        public AccountPage CancelAccountCreation()
        {
            cancelButton.GetElement().Click();
            return new AccountPage();
        }
    }
}
