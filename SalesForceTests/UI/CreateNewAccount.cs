using BusinessObject.SalesForce;
using BusinessObject.SalesForce.Model;
using NUnit.Allure.Attributes;
using NUnit.Framework;


namespace Tests.UI
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class CreateNewAccount : TestBaseSalesForce
    {
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("CreateNewAccount")]
        public void CreateNewAccount_OnlyRequiredAtts_Created()
        {
            var account = new Account();
            account.AccountName = Faker.InternetFaker.Email();

            appHelper.InitAccountCreation(UserBuilder.GetSalesForceUser())
                     .FillNewAccountForm(account)
                     .ConfirmAccountCreation()
                     .CheckSuccessMessage(account.AccountName)
                     .ReloadAccounts()
                     .CheckAccountWithAttExist(account.AccountName);
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("CreateNewAccount")]
        public void CreateNewAccount_FullAccountInformationPart_Created()
        {
            var account = new Account();
            account.AccountName = Faker.InternetFaker.Email();
            account.AccountSite = Faker.InternetFaker.Email();
            account.ParentAccount = TestData.defaultAccount;
            account.AccountNumber = Faker.NumberFaker.Number().ToString();
            account.Type = "Other";
            account.Industry = "Education";
            account.AnnualRevenue = Faker.NumberFaker.Number(4).ToString();
            account.Rating = "Hot";
            account.Phone = Faker.PhoneFaker.Phone().ToString();
            account.Fax = Faker.PhoneFaker.Phone().ToString();
            account.Website = Faker.InternetFaker.Url();
            account.TickerSymbol = Faker.StringFaker.Alpha(5);
            account.Ownership = "Private";
            account.Employees = Faker.NumberFaker.Number(3).ToString();
            account.SICCode = Faker.NumberFaker.Number(6).ToString();

            appHelper.InitAccountCreation(UserBuilder.GetSalesForceUser())
                     .FillNewAccountForm(account)
                     .ConfirmAccountCreation()
                     .CheckSuccessMessage(account.AccountName)
                     .ReloadAccounts()
                     .CheckAccountWithAttExist(account.AccountName);
        }
    }
}
