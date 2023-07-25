using Core.Helpers;
using System.Text;

namespace BusinessObject.SalesForce.Model
{
    public class Contact : BaseModel
    {

        [Newtonsoft.Json.JsonProperty("Id", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Id { get; set; }

        [Newtonsoft.Json.JsonProperty("Salutation", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Salutation { get; set; }

        [Newtonsoft.Json.JsonProperty("FirstName", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty("LastName", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? LastName { get; set; }

        [Newtonsoft.Json.JsonProperty("Name", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? AccountName { get; set; }

        [Newtonsoft.Json.JsonProperty("Title", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Title { get; set; }

        [Newtonsoft.Json.JsonProperty("Department", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Departament { get; set; }

        [Newtonsoft.Json.JsonProperty("Birthdate", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Birthdate { get; set; }

        [Newtonsoft.Json.JsonProperty("ReportsToId", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? ReportsTo { get; set; }

        [Newtonsoft.Json.JsonProperty("LeadSource", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? LeadSource { get; set; }

        [Newtonsoft.Json.JsonProperty("Phone", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Phone { get; set; }

        [Newtonsoft.Json.JsonProperty("HomePhone", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? HomePhone { get; set; }

        [Newtonsoft.Json.JsonProperty("MobilePhone", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Mobile { get; set; }

        [Newtonsoft.Json.JsonProperty("OtherPhone", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? OtherPhone { get; set; }

        [Newtonsoft.Json.JsonProperty("Fax", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Fax { get; set; }

        [Newtonsoft.Json.JsonProperty("Email", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Email { get; set; }

        [Newtonsoft.Json.JsonProperty("AssistantName", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Assistant { get; set; }

        [Newtonsoft.Json.JsonProperty("AssistantPhone", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? AssistPhone { get; set; }

        [Newtonsoft.Json.JsonProperty("MailingStreet", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? MailingStreet { get; set; }

        [Newtonsoft.Json.JsonProperty("MailingCity", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? MailingCity { get; set; }

        [Newtonsoft.Json.JsonProperty("MailingPostalCode", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? MailingZipPostalCode { get; set; }

        [Newtonsoft.Json.JsonProperty("MailingState", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? MailingStateProvince { get; set; }

        [Newtonsoft.Json.JsonProperty("MailingCountry", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? MailingCountry { get; set; }

        [Newtonsoft.Json.JsonProperty("OtherStreet", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? OtherStreet { get; set; }

        [Newtonsoft.Json.JsonProperty("OtherCity", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? OtherCity { get; set; }

        [Newtonsoft.Json.JsonProperty("OtherPostalCode", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? OtherZipPostalCode { get; set; }

        [Newtonsoft.Json.JsonProperty("OtherState", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? OtherStateProvince { get; set; }

        [Newtonsoft.Json.JsonProperty("OtherCountry", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? OtherCountry { get; set; }

        [Newtonsoft.Json.JsonProperty("Languages__c", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Languages { get; set; }

        [Newtonsoft.Json.JsonProperty("Level__c", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Level { get; set; }

        [Newtonsoft.Json.JsonProperty("Description", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Description { get; set; }

    }
}
