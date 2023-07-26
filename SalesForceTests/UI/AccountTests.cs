using BusinessObject.SalesForce;
using BusinessObject.SalesForce.Model;
using FluentAssertions;
using NUnit.Allure.Attributes;
using System.Net;

namespace Tests.UI
{
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("UI")]
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

            UiSteps.AccountSteps.InitAccountCreation()
                                .FillNewAccountForm(account)
                                .ConfirmAccountCreateOrEdit()
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

            UiSteps.AccountSteps.InitAccountCreation()
                                .FillNewAccountForm(account)
                                .ConfirmAccountCreateOrEdit()
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
            var account = ApiSteps.AccountSteps.GetAndReturnRandomAccount();
            var patchedAccount = new Account() { AccountName = Faker.InternetFaker.Email() };
            UiSteps.AccountSteps.OpenAccountPage()
                                .InitAccountChange(account.AccountName)
                                .EditData(patchedAccount)
                                .ConfirmAccountCreateOrEdit();
            //need time to save changes or clear cache
            Thread.Sleep(1000);
            ApiSteps.AccountSteps.GetAccountById(account.Id).Data.AccountName.Should().Be(patchedAccount.AccountName);
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("Change account")]
        public void ChangeAccount_Type_Ok()
        {
            var account = ApiSteps.AccountSteps.GetAndReturnRandomAccount();
            string newType = "Technology Partner";

            UiSteps.AccountSteps.OpenAccountPage()
                                .InitAccountChange(account.AccountName)
                                .EditData(new Account() { Type = newType })
                                .ConfirmAccountCreateOrEdit();
            //need time to save changes or clear cache
            Thread.Sleep(1000);
            ApiSteps.AccountSteps.GetAccountById(account.Id).Data.Type.Should().Be(newType);
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("Change account")]
        public void ChangeAccount_ParentAccount_Ok()
        {
            var account = ApiSteps.AccountSteps.GetAndReturnRandomAccount();
            var newParentAccount = ApiSteps.AccountSteps.GetAndReturnRandomAccount();
            if(account.ParentAccount == newParentAccount.AccountName)
                newParentAccount = ApiSteps.AccountSteps.GetAndReturnRandomAccount();
            var patchedAccount = new Account() { ParentAccount = newParentAccount.AccountName };
            UiSteps.AccountSteps.OpenAccountPage()
                                .InitAccountChange(account.AccountName)
                                .EditData(patchedAccount)
                                .ConfirmAccountCreateOrEdit();
            //need time to save changes or clear cache
            Thread.Sleep(1000);
            ApiSteps.AccountSteps.GetAccountById(account.Id).Data.ParentAccount.Should().Be(newParentAccount.Id);
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
            var account = ApiSteps.AccountSteps.GetAndReturnRandomAccount();
            UiSteps.AccountSteps.OpenAccountPage()
                                .DeleteAccount(account.AccountName)
                                .CheckDeleteSuccessMessage(account.AccountName);
            ApiSteps.AccountSteps.GetAccountById(account.Id).StatusCode.Should().Be(HttpStatusCode.NotFound.ToString());
        }
        #endregion
    }
}
