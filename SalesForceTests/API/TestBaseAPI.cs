using BusinessObject.SalesForce.API.Steps;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.API
{
    public class TestBaseAPI : TestBase
    {
        protected AccountSteps accountHelper;

        [OneTimeSetUp]
        public void Initial()
        {
            accountHelper = new AccountSteps();
        }
    }
}
