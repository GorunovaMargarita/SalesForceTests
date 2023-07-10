using FluentAssertions;
using Core.Elements;
using Core.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace BusinessObject.SalesForce.Pages
{
    public class ContactPage : BasePage
    {
        private const string Url = "https://ooomtsdi-dev-ed.develop.lightning.force.com/lightning/o/Contact/list?filterName=Recent";
        Button newContactButton = new(By.XPath("//div[@title='New']"));
        Button contactsButton = new(By.XPath("//span[text()='Contacts']"));
        Input searchField = new(By.XPath("//Input[@name= 'Contact-search-input']"));

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
    }
}
