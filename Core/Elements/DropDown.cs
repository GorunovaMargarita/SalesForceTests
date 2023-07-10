using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
                WebDriver.FindElement(locator).SendKeys(option);
                var action = new Actions(WebDriver);
                var element = WebDriver.FindElement(By.XPath($"//*[@title='{option}']"));
                action.MoveToElement(element)
                      .Click()
                      .Perform();
                //WebDriver.FindElement(By.XPath($"//*[@title='{option}']")).Click();
            }
        }
    }
}
