using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce.API.Steps
{
    public class ApiSteps
    {
        public AccountSteps accountSteps = new();
        public ContactSteps contactSteps = new();
    }
}
