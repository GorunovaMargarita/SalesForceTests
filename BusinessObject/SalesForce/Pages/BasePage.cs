using Core;
using OpenQA.Selenium;


namespace BusinessObject.SalesForce.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage()
        {
            driver = Browser.Instance.Driver;
        }

        public abstract BasePage Open();
    }
}
