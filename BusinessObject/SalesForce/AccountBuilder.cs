using BusinessObject.SalesForce.Model;
using Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce
{
    public class AccountBuilder
    {
        public static Account DefaultAcccount() => new Account() { Id = "001Hr00001lHwzuIAC", AccountName = "fiona@hotmail.com" };
        public static Account WithOnlyRequiredProperties() => new Account() { AccountName = Faker.InternetFaker.Email() };

        public static Account WithBillingAddress()
        {
            var account = WithOnlyRequiredProperties();
            account.BillingCity = Faker.LocationFaker.City();
            account.BillingCountry = Faker.LocationFaker.Country();
            account.BillingStateProvince = Faker.LocationFaker.StreetNumber().ToString();
            account.BillingStreet = Faker.LocationFaker.Street();
            account.BillingZipPostalCode = Faker.LocationFaker.ZipCode();
            return account;
        }

        public static Account WithoutRequiredProperty() => new Account()
        {
            AccountNumber = Faker.NumberFaker.Number().ToString(),
            Phone = Faker.PhoneFaker.Phone()
        };

        public static Account WithEmptyRequiredProperty() => new Account()
        {
            AccountName = String.Empty,
            AccountNumber = Faker.NumberFaker.Number().ToString()
        };
    }
}
