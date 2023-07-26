using BusinessObject.SalesForce.API.Steps;
using BusinessObject.SalesForce.Model;
using BusinessObject.SalesForce;
using NUnit.Allure.Attributes;
using FluentAssertions;
using Core;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Net;

namespace Tests.API
{
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("API")]
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
            SharedStep_SendAndCheckSuccess(ContactBuilder.WithOnlyRequiredProperties());
        }

        [Test]
        [AllureTag("Additional")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Create accounts: positive")]
        public void Post_CreateContact_WithFullName_Created()
        {
            SharedStep_SendAndCheckSuccess(ContactBuilder.WithFullName());
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Create contacts: negative")]
        public void Post_CreateContact_RequiredPropertyMiss_BadRequest()
        {
            var response = ApiSteps.ContactSteps.CreateContact(ContactBuilder.WithoutRequiredProperty());

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest.ToString());
            response.Data.Should().BeNull();
            response.Errors.Should().BeEquivalentTo(new Collection<Error>() { MessageContainer.API.ErrorRequiredFieldMissing("LastName") });
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Create contacts: negative")]
        public void Post_CreateContact_IncorrectBirthdateFormat_BadRequest()
        {
            var contactForCreation = ContactBuilder.WithBirtdateIncorrectFormat();
            var response = ApiSteps.ContactSteps.CreateContact(contactForCreation);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest.ToString());
            response.Data.Should().BeNull();
            response.Errors.First().Message.Should().Contain(MessageContainer.API.ErrorJsonParse(contactForCreation.Birthdate).Message);
            response.Errors.First().ErrorCode.Should().Be(MessageContainer.API.parseErrorCode);
        }

        private void SharedStep_SendAndCheckSuccess(Contact contactForCreation)
        {
            var response = ApiSteps.ContactSteps.CreateContact(contactForCreation);

            response.StatusCode.Should().Be(HttpStatusCode.Created.ToString());
            response.Errors.Should().BeNull();
            response.Data.Success.Should().BeTrue();
            response.Data.Id.Should().NotBeNull();

            var getResponse = ApiSteps.ContactSteps.GetContactById(response.Data.Id);

            //system set AccountName = FirstName + LastName
            contactForCreation.AccountName = (contactForCreation.FirstName + " " + contactForCreation.LastName).Trim();

            getResponse.Data.Should().BeEquivalentTo(contactForCreation, options => options.Excluding(o => o.Id));
            getResponse.Data.Id.Should().Be(response.Data.Id);
            Log.Instance.Logger.Info($"Contact with Id: {getResponse.Data.Id} was created");
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
            var response = ApiSteps.ContactSteps.GetAllContacts();

            response.StatusCode.Should().Be(HttpStatusCode.OK.ToString());
            response.Errors.Should().BeNull();
            response.Data.Should().Contain(x => x.AccountName.Equals(controlContact.AccountName));
            Log.Instance.Logger.Info($"Contact collection contains contact {controlContact.AccountName}");
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("GET contacts")]
        public void Get_ContactById_OK()
        {
            var response = ApiSteps.ContactSteps.GetContactById(controlContact.Id);

            response.StatusCode.Should().Be(HttpStatusCode.OK.ToString());
            response.Data.Should().BeEquivalentTo(controlContact);
            response.Errors.Should().BeNull();
            Log.Instance.Logger.Info($"Getted default contact:\r\n{response.Data}");
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("GET contacts")]
        public void Get_ContactById_UnknownContact_OK()
        {
            var unknownContactId = "Unknown";
            var response = ApiSteps.ContactSteps.GetContactById(unknownContactId);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound.ToString());
            response.Data.Should().BeNull();
            response.Errors.Should().BeEquivalentTo(new Collection<Error>() { MessageContainer.API.ErrorEntityNotFoundOrNotAccessible(unknownContactId) });
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
            var contact = ApiSteps.ContactSteps.GetAndReturnRandomContact();
            var patchedContact = new Contact() { LastName = Faker.NameFaker.LastName() };

            var response = ApiSteps.ContactSteps.ChangeContact(contact.Id, JObject.FromObject(patchedContact));

            response.StatusCode.Should().Be(HttpStatusCode.NoContent.ToString());
            response.Data.Should().BeNull();
            response.Errors.Should().BeNull();

            var resultContact = ApiSteps.ContactSteps.GetContactById(contact.Id).Data;

            contact.LastName = patchedContact.LastName;
            contact.AccountName = (contact.FirstName + " " + patchedContact.LastName).Trim();
            resultContact.Should().BeEquivalentTo(contact);
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Change contacts: positive")]
        public void Patch_ChangeContact_Phone_NoContent()
        {
            var contact = ApiSteps.ContactSteps.GetAndReturnRandomContact();
            var patchedContact = new Account() { Phone = Faker.PhoneFaker.Phone() };

            var response = ApiSteps.ContactSteps.ChangeContact(contact.Id, JObject.FromObject(patchedContact));

            response.StatusCode.Should().Be(HttpStatusCode.NoContent.ToString());
            response.Data.Should().BeNull();
            response.Errors.Should().BeNull();

            var Contact = ApiSteps.ContactSteps.GetContactById(contact.Id).Data;

            contact.Phone = patchedContact.Phone;
            Contact.Should().BeEquivalentTo(contact);
        }

        [Test]
        [AllureTag("Additional")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Change contacts: negative")]
        public void Patch_ChangeContact_InvalidField_BadRequest()
        {
            var contact = ApiSteps.ContactSteps.GetAndReturnRandomContact();
            var pathedContact = JObject.FromObject(new { BillingCity = Faker.LocationFaker.City() }); ;

            var response = ApiSteps.ContactSteps.ChangeContact(contact.Id, pathedContact);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest.ToString());
            response.Data.Should().BeNull();
            response.Errors.Should().BeEquivalentTo(new Collection<Error>() { MessageContainer.API.ErrorInvalidField("BillingCity", "Contact") });
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
            var contact = ApiSteps.ContactSteps.GetAndReturnRandomContact();

            var response = ApiSteps.ContactSteps.DeleteContact(contact.Id);

            response.StatusCode.Should().Be(HttpStatusCode.NoContent.ToString());
            response.Data.Should().BeNull();
            response.Errors.Should().BeNull();

            var getResponse = ApiSteps.ContactSteps.GetContactById(contact.Id);

            getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound.ToString());
            getResponse.Data.Should().BeNull();
            getResponse.Errors.Should().BeEquivalentTo(new Collection<Error>() { MessageContainer.API.ErrorEntityNotExist() });
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Delete contact")]
        public void Delete_NotExistingContact_NotFound()
        {
            var unknownContactId = "Unknown";
            var response = ApiSteps.ContactSteps.DeleteContact(unknownContactId);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound.ToString());
            response.Data.Should().BeNull();
            response.Errors.Should().BeEquivalentTo(new Collection<Error>() { MessageContainer.API.ErrorEntityNotFoundOrNotAccessible(unknownContactId) });
        }
        #endregion
    }
}
