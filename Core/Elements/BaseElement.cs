using Core.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core.Elements
{
    public class BaseElement
    {
        protected IWebDriver WebDriver => Browser.Instance.Driver;
        public IWebElement GetElement() => WebDriver.FindElement(Locator);
        public By Locator { get; }

        public BaseElement(By locator)
        {
            Locator = locator;
        }

        public BaseElement(string xpath)
        {
            Locator = By.XPath(xpath);
        }

        public object ClickElementViaJs()
        {
            return Browser.Instance.ExecuteScript("arguments[0].click();", GetElement());
        }
        public void ClickWithActions()
        {
            WaitHelper.WaitElement(WebDriver, Locator);
            new Actions(WebDriver)
                .MoveToElement(GetElement())
                .Click()
                .Build()
                .Perform();
        }

    }
}
