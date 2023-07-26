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

        public NewAccountModal OpenNewAccountModal()
        {
            newAccountButton.GetElement().Click();
            return new NewAccountModal();
        }

        public AccountPage CheckCreateSuccessMessage(string accountName)
        {
            string text = GetMessageText(messageElement);
            text.Should().Be(MessageContainer.UI.CreationSuccessMessage("Account", accountName));
            Log.Instance.Logger.Info($"Getted message correct: <{text}>");
            return this;
        }

        public AccountPage CheckDeleteSuccessMessage(string accountName)
        {
            string text = GetMessageText(messageElement);
            text.Should().Be(MessageContainer.UI.DeleteSuccessMessage("Account", accountName));
            Log.Instance.Logger.Info($"Getted message correct: <{text}>");
            return this;
        }

        public AccountPage ReloadAccounts()
        {
            driver.Navigate().Refresh();
            WaitHelper.WaitPageLoaded(driver);
            accountButton.ClickElementViaJs();
            return this;
        }

        public AccountPage DeleteAccount(string accountName)
        {
            WaitHelper.WaitPageLoaded(driver);
            searchFieldInput.EnterText(accountName);
            WaitHelper.WaitPageLoaded(driver);
            WaitHelper.WaitElementsCountMoreThen(driver, tableRow.Locator, 0);
            Thread.Sleep(10000);
            actionButton.GetElement().Click();
            deleteButton.GetElement().Click();
            confirmDeleteButton.GetElement().Click();
            return this;
        }

        public NewAccountModal InitAccountChange(string accountName)
        {
            WaitHelper.WaitPageLoaded(driver);
            searchFieldInput.EnterText(accountName);
            WaitHelper.WaitPageLoaded(driver);
            WaitHelper.WaitElementsCountMoreThen(driver, tableRow.Locator, 0);
            Thread.Sleep(10000);
            actionButton.GetElement().Click();
            editButton.GetElement().Click();
            return new NewAccountModal();
        }

        public AccountPage CheckAccountWithAttExist(string attribute)
        {
            Log.Instance.Logger.Info($"Search contact by attribute: {attribute}");
            searchFieldInput.EnterText(attribute);
            driver.FindElements(By.XPath($"//*[text()='{attribute}']")).Count().Should().BeGreaterThan(0);
            return this;
        }
    }
}
