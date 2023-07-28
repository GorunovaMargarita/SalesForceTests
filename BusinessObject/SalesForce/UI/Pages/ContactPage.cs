using FluentAssertions;
using Core.Elements;
using Core.Helpers;
using OpenQA.Selenium;
using Core;
using Core.Configuration;

namespace BusinessObject.SalesForce.UI.Pages
{
    public class ContactPage : ActionsWithEntity
    {
        private string Url = $"https://{Configurator.Browser.Server}/lightning/o/Contact/list?filterName=Recent";
        private string optionalTemplateForActionButton = "//a[@data-recordid='{0}']/../../../td//a";

        Button newContactButton = new(By.XPath("//div[@title='New']"));
        Button contactsButton = new(By.XPath("//span[text()='Contacts']"));

        Input searchFieldInput = new(By.XPath("//Input[@name= 'Contact-search-input']"));

        /// <summary>
        /// Open contact page by link
        /// </summary>
        /// <returns>ContactPage</returns>
        public ContactPage Open()
        {
            Log.Instance.Logger.Info($"Navigate to url: {Url}");
            Browser.Instance.NavigateToUrl(Url);
            return this;
        }

        /// <summary>
        /// Open new contact form
        /// </summary>
        /// <returns>ContactModal page</returns>
        public ContactModal OpenContactModal()
        {
            newContactButton.GetElement().Click();
            return new ContactModal();
        }

        /// <summary>
        /// Reload contact page
        /// </summary>
        /// <returns>ContactPage</returns>
        public ContactPage ReloadContacts()
        {
            driver.Navigate().Refresh();
            WaitHelper.WaitPageLoaded(driver);
            contactsButton.ClickElementViaJs();
            return this;
        }

        /// <summary>
        /// Reload contact page after create new account
        /// </summary>
        /// <returns>ContactPage</returns>
        public ContactPage ReloadContactsAfterCreation()
        {
            driver.Navigate().Refresh();
            Browser.Instance.AcceptAllert();
            WaitHelper.WaitPageLoaded(driver);
            contactsButton.ClickElementViaJs();
            return this;
        }

        /// <summary>
        /// Delete first contact with account name
        /// </summary>
        /// <param name="accountName">Account name</param>
        /// <returns>ContactPage</returns>
        public ContactPage DeleteContact(string accountName)
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

        /// <summary>
        /// Delete contact by some property value and id
        /// </summary>
        /// <param name="propertyForSearch">Property value for contact search</param>
        /// <param name="id">Unique contact Id</param>
        /// <returns>ContactPage</returns>
        public ContactPage DeleteContactById(string propertyForSearch, string id)
        {
            WaitHelper.WaitPageLoaded(driver);
            searchFieldInput.EnterText(propertyForSearch);
            WaitHelper.WaitPageLoaded(driver);
            WaitHelper.WaitElementsCountMoreThen(driver, tableRow.Locator, 0);
            Thread.Sleep(10000);

            Button actionWithIdButton = new(optionalTemplateForActionButton, id);
            actionWithIdButton.GetElement().Click();
            deleteButton.GetElement().Click();
            confirmDeleteButton.GetElement().Click();
            return this;
        }

        /// <summary>
        /// Check contact exist
        /// </summary>
        /// <param name="attribute">Any attribute value for search</param>
        /// <returns>ContactPage</returns>
        public ContactPage CheckContactWithAttExist(string attribute)
        {
            ContactExist(attribute).Should().BeTrue();
            Log.Instance.Logger.Info("Contact exist");
            return this;
        }

        /// <summary>
        /// Check contact not exist
        /// </summary>
        /// <param name="attribute">Any attribute value for search</param>
        /// <returns>ContactPage</returns>
        public ContactPage CheckContactWithAttNotExist(string attribute)
        {
            ContactExist(attribute).Should().BeFalse();
            Log.Instance.Logger.Info("Contact not exist");
            return this;
        }

        public bool ContactExist(string attribute)
        {
            Log.Instance.Logger.Info($"Search contact by attribute: {attribute}");
            searchFieldInput.EnterText(attribute);
            var elements = driver.FindElements(By.XPath($"//tbody//*[text()='{attribute}']"));
            if (elements.Count() > 0)
                return true;
            else return false;
        }

        /// <summary>
        /// Check message about contact deletion
        /// </summary>
        /// <param name="accountName">Account name</param>
        /// <returns>ContactPage</returns>
        public ContactPage CheckDeleteSuccessMessage(string accountName)
        {
            string text = GetMessageText(messageElement);
            text.Should().Be(MessageContainer.UI.DeleteSuccessMessage("Contact", accountName));
            Log.Instance.Logger.Info($"Getted message correct: <{text}>");
            return this;
        }

        /// <summary>
        /// Init first contact with property value change
        /// </summary>
        /// <param name="propertyValueForSearch">Property value for search</param>
        /// <returns>ContactPage</returns>
        public ContactModal InitContactChange(string propertyValueForSearch)
        {
            WaitHelper.WaitPageLoaded(driver);
            searchFieldInput.EnterText(propertyValueForSearch);
            Log.Instance.Logger.Info($"Search by value: {propertyValueForSearch}");
            WaitHelper.WaitPageLoaded(driver);
            WaitHelper.WaitElementsCountMoreThen(driver, tableRow.Locator, 0);
            Thread.Sleep(10000);
            actionButton.GetElement().Click();
            editButton.GetElement().Click();
            return new ContactModal();
        }

        /// <summary>
        /// Init contact change by property value and id
        /// </summary>
        /// <param name="propertyValueForSearch">Property value for search</param>
        /// <param name="id">Unique contact id</param>
        /// <returns>ContactModal</returns>
        public ContactModal InitContactChange(string propertyValueForSearch, string id)
        {
            WaitHelper.WaitPageLoaded(driver);
            searchFieldInput.EnterText(propertyValueForSearch);
            Log.Instance.Logger.Info($"Search by value: {propertyValueForSearch}");
            WaitHelper.WaitPageLoaded(driver);
            WaitHelper.WaitElementsCountMoreThen(driver, tableRow.Locator, 0);
            Thread.Sleep(10000);
            Button actionWithIdButton = new(optionalTemplateForActionButton, id);
            actionWithIdButton.GetElement().Click();
            editButton.GetElement().Click();
            return new ContactModal();
        }
    }
}
