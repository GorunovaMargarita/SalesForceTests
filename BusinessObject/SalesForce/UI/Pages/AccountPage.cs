using Core;
using Core.Configuration;
using Core.Elements;
using Core.Helpers;
using FluentAssertions;
using OpenQA.Selenium;

namespace BusinessObject.SalesForce.UI.Pages
{
    public class AccountPage : ActionsWithEntity
    {
        private string Url = $"https://{Configurator.Browser.Server}/lightning/o/Account/list?filterName=Recent";

        private string optionalTemplateForActionButton = "//a[@data-recordid='{0}']/../../../td//a";

        Button newAccountButton = new(By.XPath("//div[@title='New']"));
        Button accountButton = new(By.XPath("//span[text()='Accounts']"));

        Input searchFieldInput = new(By.XPath("//Input[@name= 'Account-search-input']"));

        /// <summary>
        /// Open account page by link
        /// </summary>
        /// <returns>AccountPage</returns>
        public AccountPage Open()
        {
            Log.Instance.Logger.Info($"Navigate to url: {Url}");
            Browser.Instance.NavigateToUrl(Url);
            return this;
        }

        /// <summary>
        /// Open new account modal
        /// </summary>
        /// <returns>AccountModal page</returns>
        public AccountModal OpenNewAccountModal()
        {
            newAccountButton.GetElement().Click();
            return new AccountModal();
        }

        /// <summary>
        /// Check success message text about creation account
        /// </summary>
        /// <param name="accountName">Account name</param>
        /// <returns>AccountPage</returns>
        public AccountPage CheckCreateSuccessMessage(string accountName)
        {
            string text = GetMessageText(messageElement);
            text.Should().Be(MessageContainer.UI.CreationSuccessMessage("Account", accountName));
            Log.Instance.Logger.Info($"Getted message correct: <{text}>");
            return this;
        }

        /// <summary>
        /// Check success message text about deletion account
        /// </summary>
        /// <param name="accountName">Account name</param>
        /// <returns>AccountPage</returns>
        public AccountPage CheckDeleteSuccessMessage(string accountName)
        {
            string text = GetMessageText(messageElement);
            text.Should().Be(MessageContainer.UI.DeleteSuccessMessage("Account", accountName));
            Log.Instance.Logger.Info($"Getted message correct: <{text}>");
            return this;
        }

        /// <summary>
        /// Reload account page 
        /// </summary>
        /// <returns>AccountPage</returns>
        public AccountPage ReloadAccounts()
        {
            driver.Navigate().Refresh();
            WaitHelper.WaitPageLoaded(driver);
            accountButton.ClickElementViaJs();
            return this;
        }

        /// <summary>
        /// Delete account
        /// </summary>
        /// <param name="propertyValueForSearch">Property value for search</param>
        /// <returns>AccountPage</returns>
        public AccountPage DeleteAccount(string propertyValueForSearch)
        {
            WaitHelper.WaitPageLoaded(driver);
            searchFieldInput.EnterText(propertyValueForSearch);
            WaitHelper.WaitPageLoaded(driver);
            WaitHelper.WaitElementsCountMoreThen(driver, tableRow.Locator, 0);
            Thread.Sleep(10000);
            actionButton.GetElement().Click();
            deleteButton.GetElement().Click();
            confirmDeleteButton.GetElement().Click();
            return this;
        }

        /// <summary>
        /// Init firest account with property value change
        /// </summary>
        /// <param name="propertyValueForSearch">Property value for search</param>
        /// <returns>AccountModal</returns>
        public AccountModal InitAccountChange(string propertyValueForSearch)
        {
            WaitHelper.WaitPageLoaded(driver);
            searchFieldInput.EnterText(propertyValueForSearch);
            WaitHelper.WaitPageLoaded(driver);
            WaitHelper.WaitElementsCountMoreThen(driver, tableRow.Locator, 0);
            Thread.Sleep(10000);
            actionButton.GetElement().Click();
            editButton.GetElement().Click();
            return new AccountModal();
        }

        /// <summary>
        /// Init account change
        /// </summary>
        /// <param name="propertyValueForSearch">Property value for search</param>
        /// <param name="id">Unique account id</param>
        /// <returns>AccountModal</returns>
        public AccountModal InitAccountChange(string propertyValueForSearch, string id)
        {
            WaitHelper.WaitPageLoaded(driver);
            searchFieldInput.EnterText(propertyValueForSearch);
            WaitHelper.WaitPageLoaded(driver);
            WaitHelper.WaitElementsCountMoreThen(driver, tableRow.Locator, 0);
            Thread.Sleep(10000);
            Button actionWithIdButton = new(optionalTemplateForActionButton, id);
            actionWithIdButton.GetElement().Click();
            editButton.GetElement().Click();
            return new AccountModal();
        }

        /// <summary>
        /// Check account exist
        /// </summary>
        /// <param name="propertyValueForSearch">Property value for search</param>
        /// <returns>AccountPage</returns>
        public AccountPage CheckAccountWithAttExist(string propertyValueForSearch)
        {
            Log.Instance.Logger.Info($"Search contact by attribute: {propertyValueForSearch}");
            searchFieldInput.EnterText(propertyValueForSearch);
            driver.FindElements(By.XPath($"//*[text()='{propertyValueForSearch}']")).Count().Should().BeGreaterThan(0);
            Log.Instance.Logger.Info("Account exist");
            return this;
        }
    }
}
