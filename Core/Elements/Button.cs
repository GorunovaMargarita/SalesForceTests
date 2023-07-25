using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Elements
{
    public class Button : BaseElement
    {
        public Button(By locator) : base(locator)
        {
        }

        public Button(string value) : base($"//button[@name='{value}']")
        {
        }
    }
}
