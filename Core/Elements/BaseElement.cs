using Core.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core.Elements
{
    public class BaseElement
    {
        protected IWebDriver WebDriver => Browser.Instance.Driver;
        public IWebElement GetElement() => WebDriver.FindElement(locator);
        protected By locator;

        public BaseElement(By locator)
        {
            this.locator = locator;
        }

        public BaseElement(string xpath)
        {
            locator = By.XPath(xpath);
        }

        public object ClickElementViaJs()
        {
            return Browser.Instance.ExecuteScript("arguments[0].click();", GetElement());
        }
        public void ClickWithActions()
        {
            WaitHelper.WaitElement(WebDriver, locator);
            new Actions(WebDriver)
                .MoveToElement(GetElement())
                .Click()
                .Build()
                .Perform();
        }

    }
}
