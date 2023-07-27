using BusinessObject.SalesForce.API.Steps;
using BusinessObject.SalesForce.Model;
using BusinessObject.SalesForce;
using NUnit.Allure.Attributes;
using FluentAssertions;
using Core;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Collections.ObjectModel;

namespace Tests.API
{
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("API")]
    [TestFixture]
    public class AccountTests : TestBaseAPI
    {
        #region Create
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Account")]
        public void Post_CreateAccount_OnlyRequiredAttributes_Created()
        {
            var accountForCreation = AccountBuilder.WithOnlyRequiredProperties();
            var response = ApiSteps.AccountSteps.CreateAccount(accountForCreation);

            response.StatusCode.Should().Be(HttpStatusCode.Created.ToString());
            response.Errors.Should().BeNull();
            response.Data.Success.Should().BeTrue();
            response.Data.Id.Should().NotBeNull();

            var createdAccount = ApiSteps.AccountSteps.GetAccountById(response.Data.Id).Data;
            createdAccount.Should().BeEquivalentTo(accountForCreation, options => options.Excluding(o => o.Id));
            createdAccount.Id.Should().Be(response.Data.Id);
            Log.Instance.Logger.Info($"Account with Id: {createdAccount.Id} was created");
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Account")]
        public void Post_CreateAccount_WithBillingAddress_Created()
        {
            var accountForCreation = AccountBuilder.WithBillingAddress();
            var response = ApiSteps.AccountSteps.CreateAccount(accountForCreation);

            response.StatusCode.Should().Be(HttpStatusCode.Created.ToString());
            response.Errors.Should().BeNull();
            response.Data.Success.Should().BeTrue();
            response.Data.Id.Should().NotBeNull();

            var createdAccount = ApiSteps.AccountSteps.GetAccountById(response.Data.Id).Data;
            createdAccount.Should().BeEquivalentTo(accountForCreation, options => options.Excluding(o => o.Id)
                                                                                         .Excluding(o => o.BillingAddress));
            createdAccount.Id.Should().Be(response.Data.Id);

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
        [AllureSubSuite("Account")]
        public void Post_CreateAccount_RequiredPropertyEmpty_BadRequest()
        {
            var response = ApiSteps.AccountSteps.CreateAccount(AccountBuilder.WithEmptyRequiredProperty());

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest.ToString());
            response.Data.Should().BeNull();
            response.Errors.Should().BeEquivalentTo(new Collection<Error>() { MessageContainer.API.ErrorRequiredFieldMissing("Name") });
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Account")]
        public void Post_CreateAccount_RequiredPropertyMiss_BadRequest()
        {
            var response = ApiSteps.AccountSteps.CreateAccount(AccountBuilder.WithoutRequiredProperty());

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest.ToString());
            response.Data.Should().BeNull();
            response.Errors.Should().BeEquivalentTo(new Collection<Error>() { MessageContainer.API.ErrorRequiredFieldMissing("Name") });
        }
        #endregion

        #region Get
        Account controlAccount = AccountBuilder.DefaultAcccount();

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Account")]
        public void Get_AllAccounts_OK()
        {
            var response = ApiSteps.AccountSteps.GetAllAccounts();

            response.StatusCode.Should().Be(HttpStatusCode.OK.ToString());
            response.Errors.Should().BeNull();
            response.Data.Should().Contain(x => x.AccountName.Equals(controlAccount.AccountName));
            Log.Instance.Logger.Info($"Account collection contains account {controlAccount.AccountName}");
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Account")]
        public void Get_AccountById_OK()
        {
            var response = ApiSteps.AccountSteps.GetAccountById(controlAccount.Id);

            response.StatusCode.Should().Be(HttpStatusCode.OK.ToString());
            response.Data.Should().BeEquivalentTo(controlAccount);
            response.Errors.Should().BeNull();
            Log.Instance.Logger.Info($"Getted default account:\r\n{response.Data}");
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Account")]
        public void Get_AccountById_UnknownAccount_OK()
        {
            var unknownAccountId = "Unknown";
            var response = ApiSteps.AccountSteps.GetAccountById(unknownAccountId);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound.ToString());
            response.Data.Should().BeNull();
            response.Errors.Should().BeEquivalentTo(new Collection<Error>() { MessageContainer.API.ErrorEntityNotFoundOrNotAccessible(unknownAccountId) });
        }
        #endregion

        #region Change
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Account")]
        public void Patch_ChangeAccount_LastName_NoContent()
        {
            var account = ApiSteps.AccountSteps.GetAndReturnRandomAccount();
            var pathedAccount = new Account() { AccountName = Faker.InternetFaker.Email() };

            var response = ApiSteps.AccountSteps.ChangeAccount(account.Id, JObject.FromObject(pathedAccount));

            response.StatusCode.Should().Be(HttpStatusCode.NoContent.ToString());
            response.Data.Should().BeNull();
            response.Errors.Should().BeNull();

            var resultAccount = ApiSteps.AccountSteps.GetAccountById(account.Id).Data;

            account.AccountName = pathedAccount.AccountName;
            resultAccount.Should().BeEquivalentTo(account);
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Account")]
        public void Patch_ChangeAccount_Phone_NoContent()
        {
            var account = ApiSteps.AccountSteps.GetAndReturnRandomAccount();
            var pathedAccount = new Account() { Phone = Faker.PhoneFaker.Phone() };

            var response = ApiSteps.AccountSteps.ChangeAccount(account.Id, JObject.FromObject(pathedAccount));

            response.StatusCode.Should().Be(HttpStatusCode.NoContent.ToString());
            response.Data.Should().BeNull();
            response.Errors.Should().BeNull();

            var resultAccount = ApiSteps.AccountSteps.GetAccountById(account.Id).Data;

            account.Phone = pathedAccount.Phone;
            resultAccount.Should().BeEquivalentTo(account);
        }

        [Test]
        [AllureTag("Additional")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Account")]
        public void Patch_ChangeAccount_InvalidField_BadRequest()
        {
            var account = ApiSteps.AccountSteps.GetAndReturnRandomAccount();
            var pathedAccount = JObject.FromObject(new { LastName = Faker.NameFaker.LastName() }); ;

            var response = ApiSteps.AccountSteps.ChangeAccount(account.Id, pathedAccount);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest.ToString());
            response.Data.Should().BeNull();
            response.Errors.Should().BeEquivalentTo(new Collection<Error>() { MessageContainer.API.ErrorInvalidField("LastName", "Account") });
        }
        #endregion

        #region Delete
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Account")]
        public void Delete_RandomAccount_OK()
        {
            var account = ApiSteps.AccountSteps.GetAndReturnRandomAccount();

            var response = ApiSteps.AccountSteps.DeleteAccount(account.Id);

            response.StatusCode.Should().Be(HttpStatusCode.NoContent.ToString());
            response.Data.Should().BeNull();
            response.Errors.Should().BeNull();

            var getResponse = ApiSteps.AccountSteps.GetAccountById(account.Id);

            getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound.ToString());
            getResponse.Data.Should().BeNull();
            getResponse.Errors.Should().BeEquivalentTo(new Collection<Error>() { MessageContainer.API.ErrorEntityNotExist() });
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Account")]
        public void Delete_NotExistingAccount_NotFound()
        {
            var unknownAccountId = "Unknown";
            var response = ApiSteps.AccountSteps.DeleteAccount(unknownAccountId);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound.ToString());
            response.Data.Should().BeNull();
            response.Errors.Should().BeEquivalentTo(new Collection<Error>() { MessageContainer.API.ErrorEntityNotFoundOrNotAccessible(unknownAccountId) });
        }
        #endregion
    }
}
