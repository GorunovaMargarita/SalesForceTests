using Core;
using Core.Elements;
using Core.Helpers;
using FluentAssertions;
using OpenQA.Selenium;
using System;


namespace BusinessObject.SalesForce.UI.Pages
{
    public class AccountPage : BasePage
    {
        private const string Url = "https://ooomtsdi-dev-ed.develop.lightning.force.com/lightning/o/Account/list?filterName=Recent";
        Button newAccountButton = new(By.XPath("//div[@title='New']"));
        Button accountButton = new(By.XPath("//span[text()='Accounts']"));
        Input searchField = new(By.XPath("//Input[@name= 'Account-search-input']"));
        By message = By.XPath("//div[@role='alertdialog']//..//span[contains(@class, 'Message')]");
        Button actionsButton = new("Show 3 more actions");
        static By action = By.XPath("//td//a");
        protected Button actionButton { get; set; } = new(By.XPath("//td//a"));
        protected Button deleteButton { get; set; } = new(By.XPath("//div[@role='menu']//a[@title='Delete']"));
        protected Button editButton { get; set; } = new(By.XPath("//div[@role='menu']//a[@title='Edit']"));
        Button confirmDeleteButton { get; set; } = new(By.XPath("//button[@title='Delete']//span"));

        public override AccountPage Open()
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
            WaitHelper.WaitElement(driver, message);
            WaitHelper.WaitElementDisplayed(driver, message, 100);
            var element = driver.FindElement(message);
            var text = element.Text;
            var expectedText = MessageContainer.UI.CreationSuccessMessage("Account", accountName);
            Log.Instance.Logger.Info($"Getted message: <{text}>, expected message: <{expectedText}>");

            text.Should().Be(expectedText);
            return this;
        }

        public AccountPage CheckDeleteSuccessMessage(string accountName)
        {
            WaitHelper.WaitElement(driver, message);
            var element = driver.FindElement(message);
            var text = element.Text;
            var expectedText = MessageContainer.UI.DeleteSuccessMessage("Account", accountName);
            Log.Instance.Logger.Info($"Getted message: <{text}>, expected message: <{expectedText}>");

            text.Should().Be(expectedText);
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
            searchField.EnterText(accountName);
            WaitHelper.WaitElementDisplayed(driver, action, 100);
            actionButton.GetElement().Click();
            //actionButton.ClickElementViaJs();
            // Action.ClickWithActions();
            deleteButton.GetElement().Click();
            confirmDeleteButton.GetElement().Click();
            return this;
        }

        public NewAccountModal InitAccountChange(string accountName)
        {
            searchField.EnterText(accountName);
            WaitHelper.WaitElementDisplayed(driver, action, 100);
            actionButton.GetElement().Click();
            //Action.ClickWithActions();
            editButton.GetElement().Click();
            return new NewAccountModal();
        }

        public AccountPage CheckAccountWithAttExist(string attribute)
        {
            Log.Instance.Logger.Info($"Search contact by attribute: {attribute}");
            searchField.EnterText(attribute);
            driver.FindElements(By.XPath($"//*[text()='{attribute}']")).Count().Should().BeGreaterThan(0);
            return this;
        }
    }
}
