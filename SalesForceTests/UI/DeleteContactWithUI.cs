using FluentAssertions;
using NUnit.Allure.Attributes;

namespace Tests.UI
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class DeleteContactWithUI : TestBaseUI
    {
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("UI Tests")]
        [AllureSubSuite("DeleteContact")]
        public void DeleteContact_ByName_Ok()
        {
            var accountName = APISteps.contactSteps.GetAndReturnRandomContact().AccountName;
            appHelper.OpenContactPage()
                     .DeleteContact(accountName)
                     .CheckDeleteSuccessMessage(accountName);
            APISteps.contactSteps.GetAllContacts().Should().NotContain(x => x.AccountName.Equals(accountName));
        }
    }
}
