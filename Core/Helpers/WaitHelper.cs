using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;


namespace Core.Helpers
{
    public class WaitHelper
    {
        public static void WaitElement(IWebDriver driver, By by, int time = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(element => element.FindElement(by));
        }

        public static void WaitElementWithTitle(IWebDriver driver, By by, string text, int time = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(element => element.FindElement(by).Text.ToLower() == text.ToLower());
        }

        public static void WaitElements(IWebDriver driver, By by, int count, int time = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(element => element.FindElements(by).Count == count);
        }

        public static void WaitPageLoaded(IWebDriver driver, int time = 20) 
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
