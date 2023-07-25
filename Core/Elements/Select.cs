using OpenQA.Selenium;

namespace Core.Elements
{
    internal class Select
    {
        private IWebElement webElement;

        public Select(IWebElement webElement)
        {
            this.webElement = webElement;
        }
    }
}