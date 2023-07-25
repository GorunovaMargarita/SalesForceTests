using Allure.Commons;
using BusinessObject.SalesForce;
using BusinessObject.SalesForce.Model;
using NUnit.Allure.Attributes;
using NUnit.Framework;


namespace Tests.UI
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class CreateNewContact : TestBaseUI
    {
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

            appHelper.InitContactCreation(UserBuilder.GetSalesForceUser())
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

            appHelper.InitContactCreation(UserBuilder.GetSalesForceUser())
                     .FillNewContactForm(contact)
                     .CancelContractCreation()
                     .ReloadContacts()
                     .CheckContactWithAttNotExist(contact.LastName);
        }
    }
}
