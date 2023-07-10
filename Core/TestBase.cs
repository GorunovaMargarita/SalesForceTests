using Allure.Commons;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Core
{
    [AllureNUnit]
    public class TestBase
    {
        private AllureLifecycle allure;
        protected IWebDriver driver = Browser.Instance.Driver;
        [OneTimeSetUp]
        public void Setup()
        {
            allure = AllureLifecycle.Instance;
        }
        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed) 
            { 
                Screenshot screenshot = ((ITakesScreenshot)Browser.Instance.Driver).GetScreenshot();
                byte[] bytes = screenshot.AsByteArray;
                allure.AddAttachment("Screenshot", "image/png", bytes);
            }
            Browser.Instance.CloseBrowser();
        }
    }
}
