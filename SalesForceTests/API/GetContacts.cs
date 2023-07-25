using BusinessObject.SalesForce;
using BusinessObject.SalesForce.Model;
using Core;
using FluentAssertions;
using NUnit.Allure.Attributes;


namespace Tests.API
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class GetContacts : TestBaseAPI
    {
        Contact controlContact = ContactBuilder.DefaultContact();

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("GET contacts")]
        public void GET_AllContacts_OK()
        {
            var contacts = APISteps.contactSteps.GetAllContacts();
            contacts.Should().Contain(x => x.AccountName.Equals(controlContact.AccountName));
            Log.Instance.Logger.Info($"Contact collection contains contact {controlContact.AccountName}");
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("GET contacts")]
        public void GET_ById_OK()
        {
            var contact = (Contact)APISteps.contactSteps.GetContactById(controlContact.Id);
            contact.Should().BeEquivalentTo(controlContact);
            Log.Instance.Logger.Info($"Getted default contact:\r\n{contact}");
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("GET contacts")]
        public void GET_ById_UnknownAccount_OK()
        {
            var unknownContactId = "Unknown";
            var errors = (ICollection<Error>)APISteps.contactSteps.GetContactById(unknownContactId);

            errors.First().Should().BeEquivalentTo(MessageContainer.API.ErrorEntityNotFoundOrNotAccessible(unknownContactId));
        }
    }
}
