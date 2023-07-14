using BusinessObject.SalesForce;
using BusinessObject.SalesForce.Model;
using Core;
using FluentAssertions;
using NUnit.Allure.Attributes;


namespace Tests.API
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class CreateAccounts : TestBaseAPI
    {
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Create accounts: positive")]
        public void POSTCreateAccount_OnlyRequiredAttributes_Created()
        {
            var accountForCreation = AccountBuilder.WithOnlyRequiredProperties();
            var response = (CreateResponse)APISteps.accountSteps.CreateAccount(accountForCreation);
            response.Success.Should().BeTrue();
            response.Errors.Should().BeEmpty();

            var createdAccount = (Account)APISteps.accountSteps.GetAccountById(response.Id);
            createdAccount.Should().BeEquivalentTo(accountForCreation, options => options.Excluding(o => o.Id));
            createdAccount.Id.Should().NotBeEmpty();
            Log.Instance.Logger.Info($"Account with Id: {createdAccount.Id} was created");
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Create accounts: positive")]
        public void POSTCreateAccount_WithBillingAddress_Created()
        {
            var accountForCreation = AccountBuilder.WithBillingAddress();
            var response = (CreateResponse)APISteps.accountSteps.CreateAccount(accountForCreation);
            response.Success.Should().BeTrue();
            response.Errors.Should().BeEmpty();

            var createdAccount = (Account)APISteps.accountSteps.GetAccountById(response.Id);
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
        public void POSTCreateAccount_RequiredPropertyEmpty_BadRequest()
        {
            var accountForCreation = new Account() { AccountName = String.Empty };
            var errors = (ICollection<Error>)APISteps.accountSteps.CreateAccount(accountForCreation);

            errors.First().Should().BeEquivalentTo(MessageContainer.AccountAPI.ErrorRequiredFieldMissing("Name"));
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Create accounts: negative")]
        public void POSTCreateAccount_RequiredPropertyMiss_BadRequest()
        {
            var accountForCreation = new Account() { AccountNumber = Faker.NumberFaker.Number().ToString() };
            var errors = (ICollection<Error>)APISteps.accountSteps.CreateAccount(accountForCreation);

            errors.First().Should().BeEquivalentTo(MessageContainer.AccountAPI.ErrorRequiredFieldMissing("Name"));
        }
    }
}
