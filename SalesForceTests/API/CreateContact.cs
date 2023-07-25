using BusinessObject.SalesForce.Model;
using BusinessObject.SalesForce;
using NUnit.Allure.Attributes;
using FluentAssertions;
using Core;

namespace Tests.API
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class CreateContact : TestBaseAPI
    {
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Create accounts: positive")]
        public void POSTCreateContact_OnlyRequiredAttributes_Created()
        {
            var contactForCreation = ContactBuilder.WithOnlyRequiredProperties();
            SharedStep_SendAndCheckSuccess(contactForCreation);
        }

        [Test]
        [AllureTag("Additional")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Create accounts: positive")]
        public void POSTCreateContact_WithFullName_Created()
        {
            var contactForCreation = ContactBuilder.WithFullName();
            SharedStep_SendAndCheckSuccess(contactForCreation);
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Create contacts: negative")]
        public void POSTCreateContact_RequiredPropertyNotSet_BadRequest()
        {
            var contactForCreation = ContactBuilder.WithoutRequiredProperty();
            var errors = (ICollection<Error>)APISteps.contactSteps.CreateContact(contactForCreation);

            errors.First().Should().BeEquivalentTo(MessageContainer.API.ErrorRequiredFieldMissing("LastName"));
        }

        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("Create contacts: negative")]
        public void POSTCreateContact_IncorrectBirthdateFormat_BadRequest()
        {
            var contactForCreation = ContactBuilder.WithBirtdateIncorrectFormat();
            var errors = (ICollection<Error>)APISteps.contactSteps.CreateContact(contactForCreation);

            errors.First().Message.Should().Contain(MessageContainer.API.ErrorJsonParse(contactForCreation.Birthdate).Message);
            errors.First().ErrorCode.Should().Be(MessageContainer.API.parseErrorCode);
        }

        private void SharedStep_SendAndCheckSuccess(Contact contactForCreation)
        {
            var response = (CreateResponse)APISteps.contactSteps.CreateContact(contactForCreation);
            response.Success.Should().BeTrue();
            response.Errors.Should().BeEmpty();

            var createdContact = (Contact)APISteps.contactSteps.GetContactById(response.Id);

            //system set AccountName = FirstName + LastName
            contactForCreation.AccountName = (contactForCreation.FirstName + " " + contactForCreation.LastName).Trim();

            createdContact.Should().BeEquivalentTo(contactForCreation, options => options.Excluding(o => o.Id));
            createdContact.Id.Should().NotBeEmpty();
            Log.Instance.Logger.Info($"Contact with Id: {createdContact.Id} was created");
        }
    }
}
