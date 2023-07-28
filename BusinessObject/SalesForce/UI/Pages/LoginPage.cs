using BusinessObject.SalesForce.Model;
using Core;
using Core.Configuration;
using Core.Elements;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;


namespace BusinessObject.SalesForce.UI.Pages
{
    public class LoginPage : BasePage
    {
        private string Url = $"https://{Configurator.Browser.Server}/lightning/page/home";

        private Button loginButton = new(By.Id("Login"));

        private Input userNameInput = new(By.XPath("//input[@name='username']"));
        private Input passwordInput = new(By.XPath("//input[@name='pw']"));

        /// <summary>
        /// Open login page by link
        /// </summary>
        /// <returns>LoginPage</returns>
        public LoginPage Open()
        {
            Log.Instance.Logger.Info($"Navigate to url: {Url}");
            Browser.Instance.NavigateToUrl(Url);
            return this;
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="user">SalesForce user</param>
        /// <returns>HomePage</returns>
        [AllureStep]
        public HomePage Login(User user)
        {
            FillCredentials(user);
            loginButton.GetElement().Click();
            return new HomePage();
        }

        /// <summary>
        /// Try to login
        /// </summary>
        /// <param name="user">SalesForce user</param>
        /// <returns>LoginPage</returns>
        [AllureStep]
        public LoginPage TryToLogin(User user)
        {
            FillCredentials(user);
            loginButton.GetElement().Click();
            return this;
        }

        /// <summary>
        /// Fill credentials on login page
        /// </summary>
        /// <param name="user">SalesForce user</param>
        private void FillCredentials(User user)
        {
            Log.Instance.Logger.Info($"Credentials: {user}");
            userNameInput.GetElement().SendKeys(user.Name);
            passwordInput.GetElement().SendKeys(user.Password);
        }
    }
}
