using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;


namespace Core.Helpers
{
    public class WaitHelper
    {
        /// <summary>
        /// Wait element
        /// </summary>
        /// <param name="driver">WebDriver</param>
        /// <param name="by">Locator</param>
        /// <param name="time">Time in seconds</param>
        public static void WaitElement(IWebDriver driver, By by, int time = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(element => element.FindElement(by));
        }

        /// <summary>
        /// Wait element displayed
        /// </summary>
        /// <param name="driver">WebDriver</param>
        /// <param name="by">Locator</param>
        /// <param name="time">Time in seconds</param>
        public static void WaitElementDisplayed(IWebDriver driver, By by, int time = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(element => element.FindElement(by).Displayed);
        }

        /// <summary>
        /// Wait element contains text
        /// </summary>
        /// <param name="driver">WebDriver</param>
        /// <param name="by">Locator</param>
        /// <param name="text">Text</param>
        /// <param name="time">Time in seconds</param>
        public static void WaitElementWithTitle(IWebDriver driver, By by, string text, int time = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(element => element.FindElement(by).Text.ToLower() == text.ToLower());
        }

        /// <summary>
        /// Wait element count
        /// </summary>
        /// <param name="driver">WebDriver</param>
        /// <param name="by">Locator</param>
        /// <param name="count">Count of elements</param>
        /// <param name="time">Time in seconds</param>
        public static void WaitElements(IWebDriver driver, By by, int count, int time = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(element => element.FindElements(by).Count == count);
        }

        /// <summary>
        /// Wait element count more then
        /// </summary>
        /// <param name="driver">WebDriver</param>
        /// <param name="by">Locator</param>
        /// <param name="count">Count of elements must be more then this value</param>
        /// <param name="time">Time in seconds</param>
        public static void WaitElementsCountMoreThen(IWebDriver driver, By by, int count, int time = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(element => element.FindElements(by).Count > count);
        }

        /// <summary>
        /// Wait page loaded
        /// </summary>
        /// <param name="driver">WebDriver</param>
        /// <param name="time">Time in seconds</param>
        public static void WaitPageLoaded(IWebDriver driver, int time = 20) 
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }


    }
}
