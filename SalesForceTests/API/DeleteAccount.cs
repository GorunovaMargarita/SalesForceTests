using BusinessObject.SalesForce;
using BusinessObject.SalesForce.Model;
using FluentAssertions;
using NUnit.Allure.Attributes;


namespace Tests.API
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class DeleteAccount : TestBaseAPI
    {
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Delete account")]
        public void Delete_RandomAccount_OK()
        {
            var account = APISteps.accountSteps.GetAndReturnRandomAccount();
            APISteps.accountSteps.GetAccountById(account.Id);
            var response = APISteps.accountSteps.DeleteAccount(account.Id);
            response.Should().BeNull();

            var errors = (ICollection<Error>)APISteps.accountSteps.GetAccountById(account.Id);
            errors.First().Should().BeEquivalentTo(MessageContainer.API.ErrorEntityNotExist());
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Delete account")]
        public void Delete_NotExistingAccount_NotFound()
        {
            var unknownAccountId = "Unknown";
            var errors = (ICollection<Error>)APISteps.accountSteps.DeleteAccount(unknownAccountId);

            errors.First().Should().BeEquivalentTo(MessageContainer.API.ErrorEntityNotFoundOrNotAccessible(unknownAccountId));
        }
    }
}
