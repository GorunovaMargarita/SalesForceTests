using FluentAssertions;
using Core.Elements;
using Core.Helpers;
using OpenQA.Selenium;
using Core;
using Core.Configuration;

namespace BusinessObject.SalesForce.UI.Pages
{
    public class ContactPage : BasePage
    {
        private string Url = $"https://{Configurator.Browser.Server}/lightning/o/Contact/list?filterName=Recent";

        Button newContactButton = new(By.XPath("//div[@title='New']"));
        Button contactsButton = new(By.XPath("//span[text()='Contacts']"));
        Input searchField = new(By.XPath("//Input[@name= 'Contact-search-input']"));
        By message = By.XPath("//div[@role='alertdialog']//..//span[contains(@class, 'Message')]");

        protected Button Action { get; set; } = new(By.XPath("//td//a"));
        protected Button Delete { get; set; } = new(By.XPath("//div[@role='menu']//a[@title='Delete']"));
        protected Button ConfirmDelete { get; set; } = new(By.XPath("//button[@title='Delete']//span"));

        public override ContactPage Open()
        {
            Log.Instance.Logger.Info($"Navigate to url: {Url}");
            Browser.Instance.NavigateToUrl(Url);
            return this;
        }

        public NewContactModal OpenNewContactModal()
        {
            newContactButton.GetElement().Click();
            return new NewContactModal();
        }

        public ContactPage ReloadContacts()
        {
            driver.Navigate().Refresh();
            WaitHelper.WaitPageLoaded(driver);
            contactsButton.ClickElementViaJs();
            return this;
        }

        public ContactPage DeleteContact(string accountName)
        {
            searchField.EnterText(accountName);
            Action.GetElement().Click();
            //driver.FindElement(By.XPath("//td//a")).Click();
           // Action.ClickWithActions();
            Delete.GetElement().Click();
            ConfirmDelete.GetElement().Click();
            return this;
        }

        public ContactPage CheckContactWithAttExist(string attribute)
        {
            ContactExist(attribute).Should().BeTrue();
            return this;
        }

        public ContactPage CheckContactWithAttNotExist(string attribute)
        {
            ContactExist(attribute).Should().BeFalse();
            return this;
        }

        public bool ContactExist(string attribute)
        {
            Log.Instance.Logger.Info($"Search contact by attribute: {attribute}");
            searchField.EnterText(attribute);
            var elements = driver.FindElements(By.XPath($"//tbody//*[text()='{attribute}']"));
            if (elements.Count() > 0)
                return true;
            else return false;
        }

        public ContactPage CheckDeleteSuccessMessage(string accountName)
        {

            WaitHelper.WaitElement(driver, message);
            var element = driver.FindElement(message);
            var text = element.Text;
            var expectedText = MessageContainer.UI.DeleteSuccessMessage("Contact", accountName);
            Log.Instance.Logger.Info($"Getted message: <{text}>, expected message: <{expectedText}>");

            text.Should().Be(expectedText);
            return this;
        }
    }
}
