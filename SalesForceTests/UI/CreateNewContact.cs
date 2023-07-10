using Allure.Commons;
using BusinessObject.SalesForce;
using BusinessObject.SalesForce.Model;
using NUnit.Allure.Attributes;
using NUnit.Framework;


namespace Tests.UI
{
    public class CreateNewContact : TestBaseSalesForce
    {
        [Test(Description = "Health check")]
        [AllureSeverity(SeverityLevel.critical)]
        [Description("Add contract with minimal data")]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("Hometask15")]
        [AllureSubSuite("CreateNewContact")]
        [AllureIssue("JIRA-14")]
        [AllureTms("TMS-16")]
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
        [AllureSuite("Hometask15")]
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
