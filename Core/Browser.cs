using Core.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core
{
    public class Browser
    {
        private static readonly ThreadLocal<Browser> BrowserInstances = new();
        public static Browser Instance => GetBrowser();
        private IWebDriver driver;
        public IWebDriver? Driver { get { return driver; } }

        private static Browser GetBrowser()
        {
            return BrowserInstances.Value ?? (BrowserInstances.Value = new Browser());
        }

        private Browser()
        {
            driver = Configurator.Browser.Type.ToLower() switch
            {
                "chrome" => DriverFactory.GetChromeDriver(),
                "firefox" => DriverFactory.GetFirefoxDriver(),
                _ => DriverFactory.GetChromeDriver()
            };

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Configurator.Browser.TimeOut);
            driver.Manage().Window.Maximize();
        }

        public void CloseBrowser()
        {
            driver?.Dispose();
            BrowserInstances.Value = null;
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void AcceptAllert()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void DismissAlert()
        {
            driver.SwitchTo().Alert().Dismiss();
        }

        public void SwitchToFrame(string id)
        {
            driver.SwitchTo().Frame(id);
        }

        public void SwitchToDefault()
        {
            driver.SwitchTo().DefaultContent();
        }

        public void ContextClickToElement(IWebElement element)
        {
            new Actions(driver)
                .ContextClick(element)
                .Build()
                .Perform();
        }

        public object ExecuteScript(string scipt, object argument = null)
        {
            try
            {
                return ((IJavaScriptExecutor)driver).ExecuteScript(scipt, argument);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
