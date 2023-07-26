using Allure.Commons;
using BusinessObject.SalesForce;
using BusinessObject.SalesForce.Model;
using BusinessObject.SalesForce.UI.Steps;
using FluentAssertions;
using NUnit.Allure.Attributes;
using System.Net;

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
            var contact = ContactBuilder.WithOnlyRequiredProperties();

            UiSteps.ContactSteps.InitContactCreation()
                                .FillNewContactForm(contact)
                                .ConfirmContactCreateOrEdit()
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
            var contact = ContactBuilder.WithUniqueLastName();

            UiSteps.ContactSteps.InitContactCreation()
                                .FillNewContactForm(contact)
                                .CancelContactCreation()
                                .ReloadContacts()
                                .CheckContactWithAttNotExist(contact.LastName);
        }
        #endregion

        #region Change
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("ChangeContact")]
        public void ChangeContact_Phone_Ok()
        {
            var contact = ApiSteps.ContactSteps.CreateAndGetContact(ContactBuilder.WithPhones());
            Thread.Sleep(1500);
            var patchedContact = new Contact() { Phone = Faker.PhoneFaker.Phone() };
            UiSteps.ContactSteps.OpenContactPage()
                                .InitContactChange(contact.Phone)
                                .EditData(patchedContact)
                                .ConfirmContactCreateOrEdit();
            //need time to save changes or clear cache
            Thread.Sleep(1000);
            ApiSteps.ContactSteps.GetContactById(contact.Id).Data.Phone.Should().Be(patchedContact.Phone);
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("ChangeContact")]
        public void ChangeContact_Level_Ok()
        {
            var contact = ApiSteps.ContactSteps.CreateAndGetContact(ContactBuilder.WithPhones());
            Thread.Sleep(1500);
            var newValue = "Secondary";
            var patchedContact = new Contact() { Level = newValue };
            UiSteps.ContactSteps.OpenContactPage()
                                .InitContactChange(contact.Phone)
                                .EditData(patchedContact)
                                .ConfirmContactCreateOrEdit();
            //need time to save changes or clear cache
            Thread.Sleep(1000);
            ApiSteps.ContactSteps.GetContactById(contact.Id).Data.Level.Should().Be(newValue);
        }
        #endregion

        #region Delete
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("DeleteContact")]
        public void DeleteContact_Ok()
        {
            var contact = ApiSteps.ContactSteps.GetAndReturnRandomContact();
            UiSteps.ContactSteps.OpenContactPage()
                                .DeleteContact(contact.AccountName)
                                .CheckDeleteSuccessMessage(contact.AccountName);
            ApiSteps.ContactSteps.GetContactById(contact.Id).StatusCode.Should().Be(HttpStatusCode.NotFound.ToString());
        }
        #endregion
    }
}
