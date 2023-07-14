
using Core.Helpers;
using System.Text;

namespace BusinessObject.SalesForce.Model
{
    public class Account
    {
        [Newtonsoft.Json.JsonProperty("Id", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Id { get; set; }

        [Newtonsoft.Json.JsonProperty("Name", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? AccountName { get; set; }

        [Newtonsoft.Json.JsonProperty("ParentId", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? ParentAccount { get; set; }

        [Newtonsoft.Json.JsonProperty("AccountNumber", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? AccountNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("Site", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? AccountSite { get; set; }

        [Newtonsoft.Json.JsonProperty("Type", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Type { get; set; }

        [Newtonsoft.Json.JsonProperty("Industry", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Industry { get; set; }

        [Newtonsoft.Json.JsonProperty("AnnualRevenue", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? AnnualRevenue { get; set; }

        [Newtonsoft.Json.JsonProperty("Rating", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Rating { get; set; }

        [Newtonsoft.Json.JsonProperty("Phone", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Phone { get; set; }

        [Newtonsoft.Json.JsonProperty("Fax", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Fax { get; set; }

        [Newtonsoft.Json.JsonProperty("Website", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Website { get; set; }

        [Newtonsoft.Json.JsonProperty("TickerSymbol", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? TickerSymbol { get; set; }

        [Newtonsoft.Json.JsonProperty("Ownership", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Ownership { get; set; }

        [Newtonsoft.Json.JsonProperty("NumberOfEmployees", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Employees { get; set; }

        [Newtonsoft.Json.JsonProperty("Sic", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? SICCode { get; set; }

        [Newtonsoft.Json.JsonProperty("BillingStreet", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? BillingStreet { get; set; }

        [Newtonsoft.Json.JsonProperty("BillingCity", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? BillingCity { get; set; }

        [Newtonsoft.Json.JsonProperty("BillingPostalCode", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? BillingZipPostalCode { get; set; }

        [Newtonsoft.Json.JsonProperty("BillingState", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? BillingStateProvince { get; set; }

        [Newtonsoft.Json.JsonProperty("BillingCountry", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? BillingCountry { get; set; }

        [Newtonsoft.Json.JsonProperty("ShippingStreet", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? ShippingStreet { get; set; }

        [Newtonsoft.Json.JsonProperty("ShippingCity", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? ShippingCity { get; set; }
        [Newtonsoft.Json.JsonProperty("ShippingPostalCode", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? ShippingZipPostalCode { get; set; }

        [Newtonsoft.Json.JsonProperty("ShippingState", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? ShippingStateProvince { get; set; }

        [Newtonsoft.Json.JsonProperty("ShippingCountry", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? ShippingCountry { get; set; }

        [Newtonsoft.Json.JsonProperty("CustomerPriority__c", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? CustomerPriority { get; set; }

        [Newtonsoft.Json.JsonProperty("SLAExpirationDate__c", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? SLAExpirationDate { get; set; }

        [Newtonsoft.Json.JsonProperty("NumberofLocations__c", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? NumberOfLocations { get; set; }

        [Newtonsoft.Json.JsonProperty("Active__c", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Active { get; set; }

        [Newtonsoft.Json.JsonProperty("SLA__c", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? SLA { get; set; }

        [Newtonsoft.Json.JsonProperty("SLASerialNumber__c", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? SLASerialNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("UpsellOpportunity__c", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? UpsellOpportunity { get; set; }

        [Newtonsoft.Json.JsonProperty("Description", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public string? Description { get; set; }

        [Newtonsoft.Json.JsonProperty("BillingAddress", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public BillingAddress? BillingAddress { get; set; }

        [Newtonsoft.Json.JsonProperty("ShippingAddress", DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore)]
        public BillingAddress? ShippingAddress { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var propertyNames = ReflectionHelper.GetPropertyNames(this);
            foreach(var property in propertyNames)
            {
                sb.Append(property);
                sb.Append(": ");
                sb.Append(ReflectionHelper.GetPropertyValue(property,this));
                sb.Append(System.Environment.NewLine);
            }
            return sb.ToString();
        }
    }
    public class BillingAddress : AddressEntity
    {

    }

    public class ShippingAddress : AddressEntity
    {

    }

    public class AddressEntity
    {
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? GeocodeAccuracy { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? PostalCode { get; set; }
        public string? State { get; set; }
        public string? Street { get; set; }
    }
}
