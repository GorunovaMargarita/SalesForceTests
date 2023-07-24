using Allure.Commons;
using BusinessObject.SalesForce.Model;
using BusinessObject.SalesForce.UI.Steps;
using FluentAssertions;
using NUnit.Allure.Attributes;


namespace Tests.UI
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class ContactTests : TestBaseUI
    {
        #region Create
        [Test(Description = "Health check")]
        [AllureSeverity(SeverityLevel.critical)]
        [Description("Add contract with minimal data")]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("CreateNewContact")]
        public void CreateNewContact_OnlyRequiredAtts_Created()
        {
            var contact = new Contact();
            contact.LastName = Faker.NameFaker.LastName();

            UiSteps.contactSteps.InitContactCreation()
                                .FillNewContactForm(contact)
                                .ConfirmContactCreation()
                                .ReloadContacts()
                                .CheckContactWithAttExist(contact.LastName);
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("CreateNewContact")]
        public void CreateNewContact_Cancel_NotCreated()
        {
            var contact = new Contact();
            contact.LastName = Faker.NameFaker.LastName() + DateTime.Now.ToString();

            UiSteps.contactSteps.InitContactCreation()
                                .FillNewContactForm(contact)
                                .CancelContractCreation()
                                .ReloadContacts()
                                .CheckContactWithAttNotExist(contact.LastName);
        }
        #endregion

        #region Change
        #endregion

        #region Delete
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("DeleteContact")]
        public void DeleteContact_ByName_Ok()
        {
            var accountName = ApiSteps.contactSteps.GetAndReturnRandomContact().AccountName;
            UiSteps.contactSteps.OpenContactPage()
                                .DeleteContact(accountName)
                                .CheckDeleteSuccessMessage(accountName);
            ApiSteps.contactSteps.GetAllContacts().Should().NotContain(x => x.AccountName.Equals(accountName));
        }
        #endregion
    }
}
