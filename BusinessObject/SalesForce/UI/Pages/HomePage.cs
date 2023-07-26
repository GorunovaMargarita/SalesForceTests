using Core;
using Core.Configuration;
using Core.Elements;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace BusinessObject.SalesForce.UI.Pages
{
    public class HomePage : BasePage
    {
        private string Url = $"https://{Configurator.Browser.Server}/lightning/page/home";

        private Button accountButton = new(By.XPath("//a[@title='Accounts']//span"));
        private Button contactButton = new(By.XPath("//a[@title='Contacts']//span"));

        /// <summary>
        /// Open home page by ling
        /// </summary>
        /// <returns>HomePage</returns>
        public HomePage Open()
        {
            Log.Instance.Logger.Info($"Navigate to url: {Url}");
            Browser.Instance.NavigateToUrl(Url);
            return this;
        }

        /// <summary>
        /// Open account page
        /// </summary>
        /// <returns>AccountPage</returns>
        [AllureStep]
        public AccountPage GoToAccountPage()
        {
            accountButton.ClickElementViaJs();
            return new AccountPage();
        }

        /// <summary>
        /// Open contact page 
        /// </summary>
        /// <returns>ContactPage</returns>
        [AllureStep]
        public ContactPage GoToContactPage()
        {
            contactButton.ClickElementViaJs();
            return new ContactPage();
        }
    }
}
