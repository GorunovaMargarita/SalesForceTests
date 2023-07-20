using Core;
using Core.Configuration;
using Core.Elements;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce.UI.Pages
{
    public class HomePage : BasePage
    {
        private string Url = $"https://{Configurator.Browser.Server}/lightning/page/home";

        private Button accountButton = new(By.XPath("//a[@title='Accounts']//span"));
        private Button contactButton = new(By.XPath("//a[@title='Contacts']//span"));
        public override HomePage Open()
        {
            Log.Instance.Logger.Info($"Navigate to url: {Url}");
            Browser.Instance.NavigateToUrl(Url);
            return this;
        }

        [AllureStep]
        public AccountPage GoToAccountPage()
        {
            accountButton.ClickElementViaJs();
            return new AccountPage();
        }

        [AllureStep]
        public ContactPage GoToContactPage()
        {
            contactButton.ClickElementViaJs();
            return new ContactPage();
        }
    }
}
