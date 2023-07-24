using BusinessObject.SalesForce.API.Steps;
using BusinessObject.SalesForce.Model;
using BusinessObject.SalesForce;
using NUnit.Allure.Attributes;
using FluentAssertions;
using Core;
using Newtonsoft.Json.Linq;

namespace Tests.API
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class ContactTests : TestBaseAPI
    {
        #region Create
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Create accounts: positive")]
        public void Post_CreateContact_OnlyRequiredAttributes_Created()
        {
            var contactForCreation = ContactBuilder.WithOnlyRequiredProperties();
            SharedStep_SendAndCheckSuccess(contactForCreation);
        }

        [Test]
        [AllureTag("Additional")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Create accounts: positive")]
        public void Post_CreateContact_WithFullName_Created()
        {
            var contactForCreation = ContactBuilder.WithFullName();
            SharedStep_SendAndCheckSuccess(contactForCreation);
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Create contacts: negative")]
        public void Post_CreateContact_RequiredPropertyNotSet_BadRequest()
        {
            var contactForCreation = ContactBuilder.WithoutRequiredProperty();
            var errors = ApiSteps.contactSteps.CreateContact<ICollection<Error>>(contactForCreation);

            errors.First().Should().BeEquivalentTo(MessageContainer.API.ErrorRequiredFieldMissing("LastName"));
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Create contacts: negative")]
        public void Post_CreateContact_IncorrectBirthdateFormat_BadRequest()
        {
            var contactForCreation = ContactBuilder.WithBirtdateIncorrectFormat();
            var errors = ApiSteps.contactSteps.CreateContact<ICollection<Error>>(contactForCreation);

            errors.First().Message.Should().Contain(MessageContainer.API.ErrorJsonParse(contactForCreation.Birthdate).Message);
            errors.First().ErrorCode.Should().Be(MessageContainer.API.parseErrorCode);
        }

        private void SharedStep_SendAndCheckSuccess(Contact contactForCreation)
        {
            var response = ApiSteps.contactSteps.CreateContact<CreateResponse>(contactForCreation);
            response.Success.Should().BeTrue();
            response.Errors.Should().BeEmpty();

            var createdContact = ApiSteps.contactSteps.GetContactById<Contact>(response.Id);

            //system set AccountName = FirstName + LastName
            contactForCreation.AccountName = (contactForCreation.FirstName + " " + contactForCreation.LastName).Trim();

            createdContact.Should().BeEquivalentTo(contactForCreation, options => options.Excluding(o => o.Id));
            createdContact.Id.Should().NotBeEmpty();
            Log.Instance.Logger.Info($"Contact with Id: {createdContact.Id} was created");
        }
        #endregion

        #region Get
        Contact controlContact = ContactBuilder.DefaultContact();

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("GET contacts")]
        public void Get_AllContacts_OK()
        {
            var contacts = ApiSteps.contactSteps.GetAllContacts();
            contacts.Should().Contain(x => x.AccountName.Equals(controlContact.AccountName));
            Log.Instance.Logger.Info($"Contact collection contains contact {controlContact.AccountName}");
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("GET contacts")]
        public void Get_ById_OK()
        {
            var contact = ApiSteps.contactSteps.GetContactById<Contact>(controlContact.Id);
            contact.Should().BeEquivalentTo(controlContact);
            Log.Instance.Logger.Info($"Getted default contact:\r\n{contact}");
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("GET contacts")]
        public void Get_ById_UnknownContact_OK()
        {
            var unknownContactId = "Unknown";
            var errors = ApiSteps.contactSteps.GetContactById<ICollection<Error>>(unknownContactId);

            errors.First().Should().BeEquivalentTo(MessageContainer.API.ErrorEntityNotFoundOrNotAccessible(unknownContactId));
        }
        #endregion

        #region Change
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Change contacts: positive")]
        public void Patch_ChangeContact_LastName_NoContent()
        {
            var contact = ApiSteps.contactSteps.GetAndReturnRandomContact();
            var patchedContact = new Contact() { LastName = Faker.NameFaker.LastName() };

            var response = ApiSteps.contactSteps.ChangeContact<string>(contact.Id, JObject.FromObject(patchedContact));

            response.Should().BeNull();

            var resultAccount = ApiSteps.contactSteps.GetContactById<Contact>(contact.Id);

            contact.LastName = patchedContact.LastName;
            contact.AccountName = (contact.FirstName + " " + patchedContact.LastName).Trim();
            resultAccount.Should().BeEquivalentTo(contact);
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Change contacts: positive")]
        public void Patch_ChangeContact_Phone_NoContent()
        {
            var contact = ApiSteps.contactSteps.GetAndReturnRandomContact();
            var patchedContact = new Account() { Phone = Faker.PhoneFaker.Phone() };

            var response = ApiSteps.contactSteps.ChangeContact<string>(contact.Id, JObject.FromObject(patchedContact));

            response.Should().BeNull();

            var resultAccount = ApiSteps.contactSteps.GetContactById<Contact>(contact.Id);

            contact.Phone = patchedContact.Phone;
            resultAccount.Should().BeEquivalentTo(contact);
        }

        [Test]
        [AllureTag("Additional")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Change contacts: negative")]
        public void Patch_ChangeContact_InvalidField_BadRequest()
        {
            var contact = ApiSteps.contactSteps.GetAndReturnRandomContact();
            var pathedContact = JObject.FromObject(new { BillingCity = Faker.LocationFaker.City() }); ;

            var response = ApiSteps.contactSteps.ChangeContact<ICollection<Error>>(contact.Id, pathedContact);

            response.Should().NotBeNull();

            response.First().Should().BeEquivalentTo(MessageContainer.API.ErrorInvalidField("BillingCity", "Contact"));
        }
        #endregion

        #region Delete
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Delete contact")]
        public void Delete_RandomContact_OK()
        {
            var contact = ApiSteps.contactSteps.GetAndReturnRandomContact();

            var response = ApiSteps.contactSteps.DeleteContact<string>(contact.Id);
            response.Should().BeNull();

            var errors = ApiSteps.contactSteps.GetContactById<ICollection<Error>>(contact.Id);
            errors.First().Should().BeEquivalentTo(MessageContainer.API.ErrorEntityNotExist());
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Delete contact")]
        public void Delete_NotExistingContact_NotFound()
        {
            var unknownContactId = "Unknown";
            var errors = ApiSteps.contactSteps.DeleteContact<ICollection<Error>>(unknownContactId);

            errors.First().Should().BeEquivalentTo(MessageContainer.API.ErrorEntityNotFoundOrNotAccessible(unknownContactId));
        }
        #endregion
    }
}
