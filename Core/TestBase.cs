using Allure.Commons;
using NUnit.Allure.Core;
using NUnit.Framework;


namespace Core
{
    [AllureNUnit]
    public class TestBase
    {
        protected AllureLifecycle allure;

        [OneTimeSetUp]
        public void Setup()
        {
            allure = AllureLifecycle.Instance;
        }
    }
}
