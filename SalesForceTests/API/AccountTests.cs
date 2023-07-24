using BusinessObject.SalesForce.API.Steps;
using BusinessObject.SalesForce.Model;
using BusinessObject.SalesForce;
using NUnit.Allure.Attributes;
using FluentAssertions;
using Core;
using Newtonsoft.Json.Linq;

namespace Tests.API
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class AccountTests : TestBaseAPI
    {
        #region Create
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Create accounts: positive")]
        public void Post_CreateAccount_OnlyRequiredAttributes_Created()
        {
            var accountForCreation = AccountBuilder.WithOnlyRequiredProperties();
            var response = ApiSteps.accountSteps.CreateAccount<CreateResponse>(accountForCreation);
            response.Success.Should().BeTrue();
            response.Errors.Should().BeEmpty();

            var createdAccount = ApiSteps.accountSteps.GetAccountById<Account>(response.Id);
            createdAccount.Should().BeEquivalentTo(accountForCreation, options => options.Excluding(o => o.Id));
            createdAccount.Id.Should().NotBeEmpty();
            Log.Instance.Logger.Info($"Account with Id: {createdAccount.Id} was created");
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Create accounts: positive")]
        public void Post_CreateAccount_WithBillingAddress_Created()
        {
            var accountForCreation = AccountBuilder.WithBillingAddress();
            var response = ApiSteps.accountSteps.CreateAccount<CreateResponse>(accountForCreation);
            response.Success.Should().BeTrue();
            response.Errors.Should().BeEmpty();

            var createdAccount = ApiSteps.accountSteps.GetAccountById<Account>(response.Id);
            createdAccount.Should().BeEquivalentTo(accountForCreation, options => options.Excluding(o => o.Id)
                                                                                         .Excluding(o => o.BillingAddress));
            createdAccount.Id.Should().NotBeEmpty();

            var billingAddressMustBe = new BillingAddress
            {
                City = accountForCreation.BillingCity,
                Country = accountForCreation.BillingCountry,
                Street = accountForCreation.BillingStreet,
                PostalCode = accountForCreation.BillingZipPostalCode,
                State = accountForCreation.BillingStateProvince
            };

            createdAccount.BillingAddress.Should().BeEquivalentTo(billingAddressMustBe);

            Log.Instance.Logger.Info($"Account with Id: {createdAccount.Id} was created");
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Create accounts: negative")]
        public void Post_CreateAccount_RequiredPropertyEmpty_BadRequest()
        {
            var accountForCreation = AccountBuilder.WithEmptyRequiredProperty();
            var errors = ApiSteps.accountSteps.CreateAccount<ICollection<Error>>(accountForCreation);

            errors.First().Should().BeEquivalentTo(MessageContainer.API.ErrorRequiredFieldMissing("Name"));
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Create accounts: negative")]
        public void Post_CreateAccount_RequiredPropertyMiss_BadRequest()
        {
            var accountForCreation = AccountBuilder.WithoutRequiredProperty();
            var errors = ApiSteps.accountSteps.CreateAccount<ICollection<Error>>(accountForCreation);

            errors.First().Should().BeEquivalentTo(MessageContainer.API.ErrorRequiredFieldMissing("Name"));
        }
        #endregion

        #region Get
        Account controlAccount = AccountBuilder.DefaultAcccount();

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("GET accounts")]
        public void Get_AllAccounts_OK()
        {
            var accounts = ApiSteps.accountSteps.GetAllAccounts();
            accounts.Should().Contain(x => x.AccountName.Equals(controlAccount.AccountName));
            Log.Instance.Logger.Info($"Account collection contains account {controlAccount.AccountName}");
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("GET accounts")]
        public void Get_ById_OK()
        {
            var account = ApiSteps.accountSteps.GetAccountById<Account>(controlAccount.Id);
            account.Should().BeEquivalentTo(controlAccount);
            Log.Instance.Logger.Info($"Getted default account:\r\n{account}");
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("GET accounts")]
        public void Get_ById_UnknownAccount_OK()
        {
            var unknownAccountId = "Unknown";
            var errors = ApiSteps.accountSteps.GetAccountById<ICollection<Error>>(unknownAccountId);

            errors.First().Should().BeEquivalentTo(MessageContainer.API.ErrorEntityNotFoundOrNotAccessible(unknownAccountId));
        }
        #endregion

        #region Change
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Change accounts: positive")]
        public void Patch_ChangeAccount_LastName_NoContent()
        {
            var account = ApiSteps.accountSteps.GetAndReturnRandomAccount();
            var pathedAccount = new Account() { AccountName = Faker.InternetFaker.Email() };

            var response = ApiSteps.accountSteps.ChangeAccount<string>(account.Id, JObject.FromObject(pathedAccount));

            response.Should().BeNull();

            var resultAccount = ApiSteps.accountSteps.GetAccountById<Account>(account.Id);

            account.AccountName = pathedAccount.AccountName;
            resultAccount.Should().BeEquivalentTo(account);
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Change accounts: positive")]
        public void Patch_ChangeAccount_Phone_NoContent()
        {
            var account = ApiSteps.accountSteps.GetAndReturnRandomAccount();
            var pathedAccount = new Account() { Phone = Faker.PhoneFaker.Phone() };

            var response = ApiSteps.accountSteps.ChangeAccount<string>(account.Id, JObject.FromObject(pathedAccount));

            response.Should().BeNull();

            var resultAccount = ApiSteps.accountSteps.GetAccountById<Account>(account.Id);

            account.Phone = pathedAccount.Phone;
            resultAccount.Should().BeEquivalentTo(account);
        }

        [Test]
        [AllureTag("Additional")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Change accounts: negative")]
        public void Patch_ChangeAccount_InvalidField_BadRequest()
        {
            var account = ApiSteps.accountSteps.GetAndReturnRandomAccount();
            var pathedAccount = JObject.FromObject(new { LastName = Faker.NameFaker.LastName() }); ;

            var response = ApiSteps.accountSteps.ChangeAccount<ICollection<Error>>(account.Id, pathedAccount);

            response.Should().NotBeNull();

            response.First().Should().BeEquivalentTo(MessageContainer.API.ErrorInvalidField("LastName", "Account"));
        }
        #endregion

        #region Delete
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Delete account")]
        public void Delete_RandomAccount_OK()
        {
            var account = ApiSteps.accountSteps.GetAndReturnRandomAccount();

            var deleteResponse = ApiSteps.accountSteps.DeleteAccount<string>(account.Id);
            deleteResponse.Should().BeNull();

            var errors = ApiSteps.accountSteps.GetAccountById<ICollection<Error>>(account.Id);
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
            var errors = ApiSteps.accountSteps.DeleteAccount<ICollection<Error>>(unknownAccountId);

            errors.First().Should().BeEquivalentTo(MessageContainer.API.ErrorEntityNotFoundOrNotAccessible(unknownAccountId));
        }
        #endregion
    }
}
