using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce
{
    public class MessageContainer
    {
        public class AccountPage
        {
            public static string CreationSuccessMessage(string accountName) => $"Account \"{accountName}\" was created.";
        }
    }
}
