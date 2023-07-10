using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce.Model
{
    public class Contact
    {
        public string? Salutation { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AccountName { get; set; }
        public string? Title { get; set; }
        public string? Departament { get; set; }
        public string? Birthdate { get; set; }
        public string? ReportsTo { get; set; }
        public string? LeadSource { get; set; }
        public string? Phone { get; set; }
        public string? HomePhone { get; set; }
        public string? Mobile { get; set; }
        public string? OtherPhone { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? Assistant { get; set; }
        public string? AssistPhone { get; set; }

        public string? MailingStreet { get; set; }
        public string? MailingCity { get; set; }
        public string? MailingZipPostalCode { get; set; }
        public string? MailingStateProvince { get; set; }
        public string? MailingCountry { get; set; }
        public string? OtherStreet { get; set; }
        public string? OtherCity { get; set; }
        public string? OtherZipPostalCode { get; set; }
        public string? OtherStateProvince { get; set; }
        public string? OtherCountry { get; set; }

        public string? Languages { get; set; }
        public string? Level { get; set; }
        public string? Description { get; set; }
    }
}
