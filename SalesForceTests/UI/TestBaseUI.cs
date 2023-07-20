using BusinessObject.SalesForce.API.Steps;
using BusinessObject.SalesForce.UI;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.UI
{
    public class TestBaseUI : TestBase
    {
        protected ApplicationHelper appHelper = new ApplicationHelper(Browser.Instance.Driver);
        protected APISteps APISteps = new APISteps();
    }
}
