using Core.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
    //public class Browser
    //{
    //    private static Browser? instance = null;
    //    private IWebDriver driver;
    //    public IWebDriver Driver { get { return driver; } }

    //    public static Browser Instance
    //    {
    //        get
    //        {
    //            if (instance == null)
    //            {
    //                instance = new Browser();
    //            }

    //            return instance;
    //        }
    //    }
    //    private Browser()
    //    {
    //        //choose browser
    //        var isHeadless = bool.Parse(GetRunSetting("Headless"));
    //        var wait = int.Parse(GetRunSetting("ImplicityWait"));

    //        switch (GetRunSetting("BrowserType"))
    //        {
    //            case "Chrome":
    //                ChromeOptions options = new ChromeOptions();
    //                options.AddArgument("--start-maximized");
    //                options.AddUserProfilePreference("download.default_directory", TestContext.Parameters.Get("DownloadFolder"));

    //                if (isHeadless)
    //                {
    //                    options.AddArgument("--headless");
    //                }

    //                driver = new ChromeDriver(options);
    //                break;
    //            case "Firefox":
    //                driver = new FirefoxDriver();
    //                break;
    //            default:
    //                driver = new ChromeDriver();
    //                break;
    //        }

    //        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(wait);
    //        driver.Manage().Window.Maximize();
    //    }
    //    public void CloseBrowser()
    //    {
    //        driver?.Dispose();
    //        instance = null;
    //    }

    //    public void NavigateToUrl(string url)
    //    {
    //        driver.Navigate().GoToUrl(url);
    //    }

    //    public void AcceptAllert()
    //    {
    //        driver.SwitchTo().Alert().Accept();
    //    }

    //    public void DismissAlert()
    //    {
    //        driver.SwitchTo().Alert().Dismiss();
    //    }

    //    public void SwitchToFrame(string id)
    //    {
    //        driver.SwitchTo().Frame(id);
    //    }

    //    public void SwitchToDefault()
    //    {
    //        driver.SwitchTo().DefaultContent();
    //    }

    //    public object ExecuteScript(string scipt, object? argument = null)
    //    {
    //        try
    //        {

    //            return ((IJavaScriptExecutor)driver).ExecuteScript(scipt, argument);
    //        }
    //        catch (Exception)
    //        {
    //            return null;
    //        }
    //    }
    //    public static string GetRunSetting(string settingName)
    //    {
    //        return TestContext.Parameters.Get(settingName) ?? throw new InvalidOperationException($"{settingName} not found in runsettings file.");
    //    }
    //}
}
