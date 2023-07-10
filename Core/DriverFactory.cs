using Core.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;


namespace Core
{
    public class DriverFactory
    {
        public static IWebDriver GetChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();

            if (Configurator.Browser.Headless) options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--start-maximized");

            return new ChromeDriver(options);
        }

        public static IWebDriver GetFirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--headless");

            return new FirefoxDriver(options);
        }
    }
}
