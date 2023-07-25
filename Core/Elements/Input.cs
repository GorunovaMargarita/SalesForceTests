using OpenQA.Selenium;
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
                WebDriver.FindElement(locator).SendKeys(text);
            }
        }
    }
}
