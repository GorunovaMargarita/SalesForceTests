using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Elements
{
    public class Input : BaseElement
    {
        public Input(By locator) : base(locator)
        {
        }

        public Input(string name) : base($"//label[text()='{name}']/following-sibling::div/input")
        {
        }
        public void EnterText(string? text)
        {
            if (text != null)
            {
                WebDriver.FindElement(Locator).SendKeys(text);
                new Actions(WebDriver)
                     .MoveToElement(WebDriver.FindElement(Locator))
                     .SendKeys(Keys.Enter)
                     .Build()
                     .Perform();
            }
        }
    }
}
