using FluentAssertions;
using NUnit.Allure.Attributes;

namespace Tests.UI
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class DeleteAccountWithUI : TestBaseUI
    {
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("DeleteAccount")]
        public void DeleteAccount_ByName_Ok()
        {
            //var accountName = "laura99@hotmail.com";
            var accountName = APISteps.accountSteps.GetAndReturnRandomAccount().AccountName;
            appHelper.OpenAccountPage()
                     .DeleteAccount(accountName)
                     .CheckDeleteSuccessMessage(accountName);
            APISteps.accountSteps.GetAllAccounts().Should().NotContain(x => x.AccountName.Equals(accountName));
        }
    }
}
