using BusinessObject.SalesForce.Model;
using FluentAssertions;
using NUnit.Allure.Attributes;

namespace Tests.UI
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class ChangeAccountWithUI : TestBaseUI
    {
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("DeleteAccount")]
        public void ChangeAccount_ByName_Ok()
        {
            var accountName = APISteps.accountSteps.GetAndReturnRandomAccount().AccountName;
            var patchedAccount = new Account() { AccountName = Faker.InternetFaker.Email() };
            appHelper.OpenAccountPage()
                     .InitAccountChange(accountName)
                     .EditData(patchedAccount)
                     .ConfirmAccountCreation();
            APISteps.accountSteps.GetAllAccounts().Should().NotContain(x => x.AccountName.Equals(accountName));
        }
    }
}
