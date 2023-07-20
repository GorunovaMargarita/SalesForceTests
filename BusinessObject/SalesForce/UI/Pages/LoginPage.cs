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

        private Input userNameInput = new(By.XPath("//input[@name='username']"));
        private Input passwordInput = new(By.XPath("//input[@name='pw']"));
        private Button loginButton = new(By.Id("Login"));

        public override LoginPage Open()
        {
            Log.Instance.Logger.Info($"Navigate to url: {Url}");
            Browser.Instance.NavigateToUrl(Url);
            return this;
        }

        [AllureStep]
        public HomePage Login(User user)
        {
            FillCredentials(user);
            loginButton.GetElement().Click();
            return new HomePage();
        }

        [AllureStep]
        public LoginPage TryToLogin(User user)
        {
            FillCredentials(user);
            loginButton.GetElement().Click();

            return this;
        }

        private void FillCredentials(User user)
        {
            Log.Instance.Logger.Info($"Credentials: {user}");
            userNameInput.GetElement().SendKeys(user.Name);
            passwordInput.GetElement().SendKeys(user.Password);
        }
    }
}
