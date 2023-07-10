using BusinessObject.SalesForce.Model;
using Core.Elements;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace BusinessObject.SalesForce.Pages
{
    public class NewAccountModal
    {
        Input accountNameInput = new("Account Name");
        PartialTextDropDown parentAccountDropDown = new("Parent Account");
        Input accountNumberInput = new("Account Number");
        Input accountSite = new("Account Site");
        DropDown typeDropDown = new("Type");
        DropDown industryDropDown = new("Industry");
        Input annualRevenueInput = new("Annual Revenue");
        DropDown ratingDropDown = new("Rating");
        Input phoneInput = new("Phone");
        Input faxInput = new("Fax");
        Input websiteInput = new("Website");
        Input tickerSymbolInput = new("Ticker Symbol");
        DropDown ownershipDropDown = new("Ownership");
        Input employeesInput = new("Employees");
        Input sicCodeInput = new("SIC Code");
        Input billingStreetInput = new("Billing Street");
        Input billingCityInput = new("Billing City");
        Input billingStateProvinceInput = new("Billing State/Province");
        Input billingCountryInput = new("Billing Country");
        Input shippingStreetInput = new("Shipping Street");
        Input shippingCityInput = new("Shipping City");
        Input shippingZipPostalCodeInput = new("Shipping Zip/Postal Code");
        Input shippingStateProvinceInput = new("Shipping State/Province");
        Input shippingCountryInput = new("Shipping Country");
        DropDown customerPriorityDropDown = new("Customer Priority");
        Input slaExpirationDateInput = new("SLA Expiration Date");
        Input numberOfLocationsInput = new("Number of Locations");
        DropDown activeDropDown = new("Active");
        DropDown slaDropDown = new("SLA");
        Input slaSerialNumberInput = new("SLA Serial Number");
        Input upsellOpportunityInput = new("Upsell Opportunity");
        Input descriptionInput = new("Description");

        Button saveButton = new("SaveEdit");
        Button saveAndNewButton = new("SaveAndNew");
        Button CancelButton = new("Cancel");

        public void CreateAccount(string name, string listOption)
        {
            accountNameInput.GetElement().SendKeys(name);
            typeDropDown.Select("Prospect");
            saveButton.GetElement().Click();
        }
        [AllureStep]
        public NewAccountModal FillNewAccountForm(Account account)
        {
            accountNameInput.EnterText(account.AccountName);
            parentAccountDropDown.Select(account.ParentAccount);
            accountNumberInput.EnterText(account.AccountNumber);
            accountSite.EnterText(account.AccountSite);
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
            upsellOpportunityInput.EnterText(account.UpsellOpportunity);
            descriptionInput.EnterText(account.Description);

            return this;
        }
        [AllureStep]
        public AccountPage ConfirmAccountCreation()
        {
            saveButton.GetElement().Click();
            //uncomment if we have a problem with pop up
            //WaitHelper.WaitElement(Browser.Instance.Driver, By.CssSelector("span[title=Follow]"));
            return new AccountPage();
        }
        [AllureStep]
        public NewAccountModal ConfirmAndNewAccountCreation()
        {
            saveAndNewButton.GetElement().Click();
            return this;
        }
        [AllureStep]
        public void CancelAccountCreation()
        {
            CancelButton.GetElement().Click();
        }
    }
}
