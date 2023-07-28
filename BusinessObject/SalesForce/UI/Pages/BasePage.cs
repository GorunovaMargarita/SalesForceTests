using Core;
using OpenQA.Selenium;


namespace BusinessObject.SalesForce.UI.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage() => driver = Browser.Instance.Driver;

    }
}
