using BusinessObject.SalesForce.Model;
using Core;
using Core.Configuration;
using Core.Elements;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;


namespace BusinessObject.SalesForce.Pages
{
    public class LoginPage : BasePage
    {
        //private string url = "https://ooomtsdi-dev-ed.develop.my.salesforce.com/";
        private string url = Configurator.API.BaseUrl;

        private Input userNameInput = new(By.XPath("//input[@name='username']"));
        private Input passwordInput = new(By.XPath("//input[@name='pw']"));
        private Button loginButton = new(By.Id("Login"));

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public override LoginPage Open()
        {
            logger.Info($"Navigate to url: {url}");
            Browser.Instance.NavigateToUrl(url);
            return this;
        }
        [AllureStep]
        public LoginPage Login(User user)
        {
            logger.Info($"Try to login user {user}");
            userNameInput.GetElement().SendKeys(user.Name);
            passwordInput.GetElement().SendKeys(user.Password);
            loginButton.GetElement().Click();

            return this;
        }
    }
}
