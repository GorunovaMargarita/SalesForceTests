using BusinessObject.SalesForce;
using BusinessObject.SalesForce.Model;
using FluentAssertions;
using NUnit.Allure.Attributes;


namespace Tests.UI
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class AccountTests : TestBaseUI
    {
        #region Create

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("CreateNewAccount")]
        public void CreateNewAccount_OnlyRequiredAtts_Created()
        {
            var account = AccountBuilder.WithOnlyRequiredProperties();

            UiSteps.accountSteps.InitAccountCreation()
                                .FillNewAccountForm(account)
                                .ConfirmAccountCreation()
                                .CheckCreateSuccessMessage(account.AccountName)
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
            Account account = AccountBuilder.GetAccountWithFullAccountInfoPart();

            UiSteps.accountSteps.InitAccountCreation()
                                .FillNewAccountForm(account)
                                .ConfirmAccountCreation()
                                .CheckCreateSuccessMessage(account.AccountName)
                                .ReloadAccounts()
                                .CheckAccountWithAttExist(account.AccountName);
        }
        #endregion

        #region Change
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("Change account")]
        public void ChangeAccount_AccountName_Ok()
        {
            var accountName = ApiSteps.accountSteps.GetAndReturnRandomAccount().AccountName;
            var patchedAccount = new Account() { AccountName = Faker.InternetFaker.Email() };
            UiSteps.accountSteps.OpenAccountPage()
                                .InitAccountChange(accountName)
                                .EditData(patchedAccount)
                                .ConfirmAccountCreation();
            ApiSteps.accountSteps.GetAllAccounts().Should().NotContain(x => x.AccountName.Equals(accountName));
        }
        #endregion

        #region Delete
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("DeleteAccount")]
        public void DeleteAccount_Ok()
        {
            //var accountName = "laura99@hotmail.com";
            var accountName = ApiSteps.accountSteps.GetAndReturnRandomAccount().AccountName;
            UiSteps.accountSteps.OpenAccountPage()
                                .DeleteAccount(accountName)
                                .CheckDeleteSuccessMessage(accountName);
            ApiSteps.accountSteps.GetAllAccounts().Should().NotContain(x => x.AccountName.Equals(accountName));
        }
        #endregion
    }
}
