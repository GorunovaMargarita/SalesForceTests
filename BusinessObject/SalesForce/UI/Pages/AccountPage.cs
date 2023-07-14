using Core;
using Core.Elements;
using Core.Helpers;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce.UI.Pages
{
    public class AccountPage : BasePage
    {
        private const string Url = "https://ooomtsdi-dev-ed.develop.lightning.force.com/lightning/o/Account/list?filterName=Recent";
        Button newAccountButton = new(By.XPath("//div[@title='New']"));
        Button accountButton = new(By.XPath("//span[text()='Accounts']"));
        Input searchField = new(By.XPath("//Input[@name= 'Account-search-input']"));
        By successMessage = By.XPath("//div[@role='alertdialog']//..//span[contains(@class, 'Message')]");

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

        public AccountPage CheckSuccessMessage(string accountName)
        {
            WaitHelper.WaitElement(driver, successMessage);
            var element = driver.FindElement(successMessage);
            var text = element.Text;
            var expectedText = MessageContainer.AccountPage.CreationSuccessMessage(accountName);
            Log.Instance.Logger.Info($"Getted message: <{text}>, expected message: <{expectedText}>");

            text.Should().Be(expectedText);
            return new AccountPage();
        }

        public AccountPage ReloadAccounts()
        {
            driver.Navigate().Refresh();
            WaitHelper.WaitPageLoaded(driver);
            accountButton.ClickElementViaJs();
            return this;
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
