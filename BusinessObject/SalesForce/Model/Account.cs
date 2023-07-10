
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce.Model
{
    public class Account
    {
        public string? AccountName { get; set; }
        public string? ParentAccount { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountSite { get; set; }
        public string? Type { get; set; }
        public string? Industry { get; set; }
        public string? AnnualRevenue { get; set; }
        public string? Rating { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Website { get; set; }
        public string? TickerSymbol { get; set; }
        public string? Ownership { get; set; }
        public string? Employees { get; set; }
        public string? SICCode { get; set; }

        public string? BillingStreet { get; set; }
        public string? BillingCity { get; set; }
        public string? BillingZipPostalCode { get; set; }
        public string? BillingStateProvince { get; set; }
        public string? BillingCountry { get; set; }
        public string? ShippingStreet { get; set; }
        public string? ShippingCity { get; set; }
        public string? ShippingZipPostalCode { get; set; }
        public string? ShippingStateProvince { get; set; }
        public string? ShippingCountry { get; set; }

        public string? CustomerPriority { get; set; }
        public string? SLAExpirationDate { get; set; }
        public string? NumberOfLocations { get; set; }
        public string? Active { get; set; }
        public string? SLA { get; set; }
        public string? SLASerialNumber { get; set; }
        public string? UpsellOpportunity { get; set; }
        public string? Description { get; set; }

    }
}
