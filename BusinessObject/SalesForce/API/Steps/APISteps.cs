using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce.API.Steps
{
    public class APISteps
    {
        public AccountSteps accountSteps { get; }
        public ContactSteps contactSteps { get; }

        public APISteps()
        {
            accountSteps = new AccountSteps();
            contactSteps = new ContactSteps();
        }
    }
}
