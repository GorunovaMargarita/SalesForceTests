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
    [Category("UI")]
    [TestFixture]
    public class ContactTests : TestBaseUI
    {
        #region Create
        [Test(Description = "Health check")]
        [AllureSeverity(SeverityLevel.critical)]
        [Description("Create contact with minimal data")]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("Contact")]
        public void CreateNewContact_OnlyRequiredAtts_Created()
        {
            var contact = ContactBuilder.WithOnlyRequiredProperties();

            UiSteps.ContactSteps.InitContactCreation()
                                .FillNewContactForm(contact)
                                .ConfirmContactCreateOrEdit()
                                .ReloadContactsAfterCreation()
                                .CheckContactWithAttExist(contact.LastName);
        }

        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        [Description("Create contact with phones data")]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("Contact")]
        public void CreateNewContact_WithPhones_Created()
        {
            var contact = ContactBuilder.WithPhones();

            UiSteps.ContactSteps.InitContactCreation()
                                .FillNewContactForm(contact)
                                .ConfirmContactCreateOrEdit()
                                .ReloadContactsAfterCreation()
                                .CheckContactWithAttExist(contact.Phone);
        }

        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        [Description("Create contact with full name data")]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("Contact")]
        public void CreateNewContact_WithFullName_Created()
        {
            var contact = ContactBuilder.WithFullNameAndSalutation();

            UiSteps.ContactSteps.InitContactCreation()
                                .FillNewContactForm(contact)
                                .ConfirmContactCreateOrEdit()
                                .ReloadContactsAfterCreation()
                                .CheckContactWithAttExist(contact.FirstName + " " + contact.LastName);
        }

        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        [Description("Create contact with medium description")]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("Contact")]
        public void CreateNewContact_WithMediumDescription_Created()
        {
            var contact = ContactBuilder.WithMediumDescription();

            UiSteps.ContactSteps.InitContactCreation()
                                .FillNewContactForm(contact)
                                .ConfirmContactCreateOrEdit()
                                .ReloadContactsAfterCreation()
                                .CheckContactWithAttExist(contact.LastName);
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("Contact")]
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
        [AllureSubSuite("Contact")]
        public void ChangeContact_Phone_Ok()
        {
            var contact = ApiSteps.ContactSteps.GetAndReturnRandomContact();
            var patchedContact = new Contact() { Phone = Faker.PhoneFaker.Phone() };
            UiSteps.ContactSteps.OpenContactPage()
                                .InitContactChange(contact.LastName, contact.Id)
                                .EditData(patchedContact)
                                .ConfirmContactCreateOrEdit()
                                .CheckContactWithAttExist(patchedContact.Phone);
            //need time to save changes or clear cache
            Thread.Sleep(2000);
            ApiSteps.ContactSteps.GetContactById(contact.Id).Data.Phone.Should().Be(patchedContact.Phone);
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("Contact")]
        public void ChangeContact_Level_Ok()
        {
            var contact = ApiSteps.ContactSteps.GetAndReturnRandomContact();
            var newValue = "Secondary";
            var patchedContact = new Contact() { Level = newValue };
            UiSteps.ContactSteps.OpenContactPage()
                                .InitContactChange(contact.LastName, contact.Id)
                                .EditData(patchedContact)
                                .ConfirmContactCreateOrEdit();
            //need time to save changes or clear cache
            Thread.Sleep(2000);
            ApiSteps.ContactSteps.GetContactById(contact.Id).Data.Level.Should().Be(newValue);
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("Contact")]
        public void ChangeContact_Description_Ok()
        {
            var contact = ApiSteps.ContactSteps.GetAndReturnRandomContact();
            var newValue = ContactBuilder.WithLongDescription().Description;
            var patchedContact = new Contact() { Description = newValue };
            UiSteps.ContactSteps.OpenContactPage()
                                .InitContactChange(contact.LastName, contact.Id)
                                .EditData(patchedContact)
                                .ConfirmContactCreateOrEdit();
            //need time to save changes or clear cache
            Thread.Sleep(2000);
            ApiSteps.ContactSteps.GetContactById(contact.Id).Data.Description.Trim().Should().Be(newValue);
        }
        #endregion

        #region Delete
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("Contact")]
        public void DeleteContact_Ok()
        {
            var contact = ApiSteps.ContactSteps.GetAndReturnRandomContact();
            UiSteps.ContactSteps.OpenContactPage()
                                .DeleteContactById(contact.AccountName, contact.Id)
                                .CheckDeleteSuccessMessage(contact.AccountName);
            ApiSteps.ContactSteps.GetContactById(contact.Id).StatusCode.Should().Be(HttpStatusCode.NotFound.ToString());
        }
        #endregion
    }
}
