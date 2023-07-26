using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace Core.Elements
{
    public class DropDown : BaseElement
    {
        public DropDown(By locator) : base(locator)
        {
        }

        public DropDown(string locator) : base($"//label[text()='{locator}']/following-sibling::div//button")
        {
        }

        public void Select(string? option)
        {
            if(option != null)
            {
                WebDriver.FindElement(Locator).SendKeys(option);
                var action = new Actions(WebDriver);
                var element = WebDriver.FindElement(By.XPath($"//*[@title='{option}']"));
                action.MoveToElement(element)
                      .Click()
                      .Perform();
            }
        }
    }
}
