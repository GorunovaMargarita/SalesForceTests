using OpenQA.Selenium;

namespace Core.Elements
{
    public class PartialTextDropDown : BaseElement
    {

        string optionTemplate = "//li//*[@title='{0}']";
        string optionByPartTemplate = "//li//*[contains(@title,'{0}')]";

        private Button ClearSectionCross = new(By.XPath("//span[text()='Clear Selection']"));

        public PartialTextDropDown(By locator) : base(locator)
        {
        }

        public PartialTextDropDown(string locator) : base($"//label[text()='{locator}']/following-sibling::div//input")
        {
        }

        public void Select(string option)
        {
            if (option != null)
            {
                var optionLocator = string.Format(optionTemplate, option);
                BaseSelect(option, By.XPath(optionLocator));
            }
        }

        public void SelectByPartText(string option)
        {
            if (option != null)
            {
                var optionLocator = string.Format(optionByPartTemplate, option);
                BaseSelect(option, By.XPath(optionLocator));
            }
        }

        public void BaseSelect(string option, By by)
        {
            WebDriver.FindElement(Locator).Click();
            WebDriver.FindElement(Locator).SendKeys(option);
            WebDriver.FindElement(by).Click();
        }

        public void Clear()
        {
            ClearSectionCross.ClickElementViaJs();
        }
    }
}
