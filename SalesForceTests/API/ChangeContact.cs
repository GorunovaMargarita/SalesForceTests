using BusinessObject.SalesForce;
using BusinessObject.SalesForce.API.Steps;
using BusinessObject.SalesForce.Model;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using NUnit.Allure.Attributes;

namespace Tests.API
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class ChangeContact : TestBaseAPI
    {
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Change contacts: positive")]
        public void PATCHChangeContact_LastName_NoContent()
        {
            var contact = APISteps.contactSteps.GetAndReturnRandomContact();
            var patchedContact = new Contact() { LastName = Faker.NameFaker.LastName() };

            var response = APISteps.contactSteps.ChangeContact(contact.Id, JObject.FromObject(patchedContact));

            response.Should().BeNull();

            var resultAccount = (Contact)APISteps.contactSteps.GetContactById(contact.Id);

            contact.LastName = patchedContact.LastName;
            contact.AccountName = contact.FirstName + " " + patchedContact.LastName;
            resultAccount.Should().BeEquivalentTo(contact);
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Change contacts: positive")]
        public void PATCHChangeContact_Phone_NoContent()
        {
            var contact = APISteps.contactSteps.GetAndReturnRandomContact();
            var patchedContact = new Account() { Phone = Faker.PhoneFaker.Phone() };

            var response = APISteps.contactSteps.ChangeContact(contact.Id, JObject.FromObject(patchedContact));

            response.Should().BeNull();

            var resultAccount = (Contact)APISteps.contactSteps.GetContactById(contact.Id);

            contact.Phone = patchedContact.Phone;
            resultAccount.Should().BeEquivalentTo(contact);
        }

        [Test]
        [AllureTag("Additional")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Change contacts: negative")]
        public void PATCHChangeContact_InvalidField_BadRequest()
        {
            var contact = APISteps.contactSteps.GetAndReturnRandomContact();
            var pathedContact = JObject.FromObject(new { BillingCity = Faker.LocationFaker.City() }); ;

            var response = (ICollection<Error>)APISteps.contactSteps.ChangeContact(contact.Id, pathedContact);

            response.Should().NotBeNull();

            response.First().Should().BeEquivalentTo(MessageContainer.API.ErrorInvalidField("BillingCity", "Contact"));
        }
    }
}
