using Core;
using FluentAssertions;
using NLog;
using NUnit.Allure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.API
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class GetAccounts : TestBaseAPI
    {
        [Test]
        [AllureTag("Smoke")]
        [AllureOwner("Margarita")]
        [AllureSuite("API Tests")]
        [AllureSubSuite("GET all accounts")]
        public void GET_AllAccounts_OK()
        {
            var accounts = accountHelper.GetAllAccounts();
            accounts.Should().Contain(x => x.AccountName.Equals(TestData.defaultAccount));
            Log.Instance.Logger.Info($"Account collection contains account {TestData.defaultAccount}");
        }
    }
}
