using BusinessObject.SalesForce.Model;
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

        public class AccountAPI
        {
            public const string notFoundCode = "NOT_FOUND";
            public const string requiredFieldMissingCode = "REQUIRED_FIELD_MISSING";
            public static Error ErrorEntityNotFound(string Id) => new Error() { ErrorCode = notFoundCode, Message = $"Provided external ID field does not exist or is not accessible: {Id}" };

            public static Error ErrorRequiredFieldMissing(string PropertyName) => new Error() { ErrorCode = requiredFieldMissingCode, Message = $"Required fields are missing: [{PropertyName}]", Fields = new[] { PropertyName } };

        }
    }
}
