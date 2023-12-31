﻿using BusinessObject.SalesForce.Model;


namespace BusinessObject.SalesForce
{
    public class MessageContainer
    {
        public class UI
        {
            public static string CreationSuccessMessage(string entityName, string accountName) => $"{entityName} \"{accountName}\" was created.";
            public static string DeleteSuccessMessage(string entityName, string accountName) => $"{entityName} \"{accountName}\" was deleted. Undo";
        }

        public class API
        {
            public const string notFoundCode = "NOT_FOUND";
            public const string parseErrorCode = "JSON_PARSER_ERROR";
            public const string requiredFieldMissingCode = "REQUIRED_FIELD_MISSING";
            public const string invalidFieldCode = "INVALID_FIELD";

            public static Error ErrorEntityNotExist() => new Error() { ErrorCode = notFoundCode, Message = $"The requested resource does not exist" };

            public static Error ErrorEntityNotFoundOrNotAccessible(string Id) => new Error() { ErrorCode = notFoundCode, Message = $"Provided external ID field does not exist or is not accessible: {Id}" };

            public static Error ErrorRequiredFieldMissing(string propertyName) => new Error() { ErrorCode = requiredFieldMissingCode, Message = $"Required fields are missing: [{propertyName}]", Fields = new[] { propertyName } };

            public static Error ErrorJsonParse(string propertyValue) => new Error() { ErrorCode = parseErrorCode, Message = $"Cannot deserialize instance of date from VALUE_STRING value {propertyValue} or request may be missing a required field at" };

            public static Error ErrorInvalidField(string propertyName, string sobjectType) => new Error() { ErrorCode = invalidFieldCode, Message = $"No such column '{propertyName}' on sobject of type {sobjectType}" };

        }
    }
}
