using BusinessObject.SalesForce.UI.Steps;
using Core;
using OpenQA.Selenium;
using Tests.API;

namespace Tests.UI
{
    public class TestBaseUI : TestBaseAPI
    {
        protected UiSteps UiSteps = new();

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
