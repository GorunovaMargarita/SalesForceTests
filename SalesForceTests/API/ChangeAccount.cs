using BusinessObject.SalesForce;
using BusinessObject.SalesForce.API.Steps;
using BusinessObject.SalesForce.Model;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using NUnit.Allure.Attributes;

namespace Tests.API
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class ChangeAccount : TestBaseAPI
    {
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Change accounts: positive")]
        public void PATCHChangeAccount_LastName_NoContent()
        {
            var account = APISteps.accountSteps.GetAndReturnRandomAccount();
            var pathedAccount = new Account() { AccountName = Faker.InternetFaker.Email() };

            var response = APISteps.accountSteps.ChangeAccount(account.Id, JObject.FromObject(pathedAccount));

            response.Should().BeNull();

            var resultAccount = (Account)APISteps.accountSteps.GetAccountById(account.Id);

            account.AccountName = pathedAccount.AccountName;
            resultAccount.Should().BeEquivalentTo(account);
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Change accounts: positive")]
        public void PATCHChangeAccount_Phone_NoContent()
        {
            var account = APISteps.accountSteps.GetAndReturnRandomAccount();
            var pathedAccount = new Account() { Phone = Faker.PhoneFaker.Phone() };

            var response = APISteps.accountSteps.ChangeAccount(account.Id, JObject.FromObject(pathedAccount));

            response.Should().BeNull();

            var resultAccount = (Account)APISteps.accountSteps.GetAccountById(account.Id);

            account.Phone = pathedAccount.Phone;
            resultAccount.Should().BeEquivalentTo(account);
        }

        [Test]
        [AllureTag("Additional")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Change accounts: negative")]
        public void PATCHChangeAccount_InvalidField_BadRequest()
        {
            var account = APISteps.accountSteps.GetAndReturnRandomAccount();
            var pathedAccount = JObject.FromObject(new { LastName = Faker.NameFaker.LastName() }); ;

            var response = (ICollection<Error>)APISteps.accountSteps.ChangeAccount(account.Id, pathedAccount);

            response.Should().NotBeNull();

            response.First().Should().BeEquivalentTo(MessageContainer.API.ErrorInvalidField("LastName", "Account"));
        }
    }
}
