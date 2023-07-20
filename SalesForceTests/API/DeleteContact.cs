using BusinessObject.SalesForce;
using BusinessObject.SalesForce.Model;
using FluentAssertions;
using NUnit.Allure.Attributes;


namespace Tests.API
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class DeleteContact : TestBaseAPI
    {
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Delete contact")]
        public void Delete_RandomContact_OK()
        {
            var contact = APISteps.contactSteps.GetAndReturnRandomContact();
            APISteps.contactSteps.GetContactById(contact.Id);
            var response = APISteps.contactSteps.DeleteContact(contact.Id);
            response.Should().BeNull();

            var errors = (ICollection<Error>)APISteps.contactSteps.GetContactById(contact.Id);
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
            var errors = (ICollection<Error>)APISteps.contactSteps.DeleteContact(unknownContactId);

            errors.First().Should().BeEquivalentTo(MessageContainer.API.ErrorEntityNotFoundOrNotAccessible(unknownContactId));
        }
    }
}
