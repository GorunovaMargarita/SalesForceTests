using BusinessObject.SalesForce;
using BusinessObject.SalesForce.Model;
using Core;
using FluentAssertions;
using NUnit.Allure.Attributes;


namespace Tests.API
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class GetAccounts : TestBaseAPI
    {
        Account controlAccount = AccountBuilder.DefaultAcccount();

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("GET accounts")]
        public void GET_AllAccounts_OK()
        {
            var accounts = APISteps.accountSteps.GetAllAccounts();
            accounts.Should().Contain(x => x.AccountName.Equals(controlAccount.AccountName));
            Log.Instance.Logger.Info($"Account collection contains account {controlAccount.AccountName}");
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("GET accounts")]
        public void GET_ById_OK()
        {
            var account = (Account)APISteps.accountSteps.GetAccountById(controlAccount.Id);
            account.Should().BeEquivalentTo(controlAccount);
            Log.Instance.Logger.Info($"Getted default account:\r\n{account}");
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("GET accounts")]
        public void GET_ById_UnknownAccount_OK()
        {
            var unknownAccountId = "Unknown";
            var errors = (ICollection<Error>)APISteps.accountSteps.GetAccountById(unknownAccountId);

            errors.First().Should().BeEquivalentTo(MessageContainer.API.ErrorEntityNotFoundOrNotAccessible(unknownAccountId));
        }
    }
}
