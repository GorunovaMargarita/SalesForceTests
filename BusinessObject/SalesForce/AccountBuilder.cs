using BusinessObject.SalesForce.Model;

namespace BusinessObject.SalesForce
{
    public class AccountBuilder
    {
        public static Account DefaultAcccount() =>
            new Account()
            {
                Id = "001Hr00001lHwzuIAC",
                AccountName = "fiona@hotmail.com"
            };
        public static Account WithOnlyRequiredProperties() =>
            new Account()
            {
                AccountName = Faker.InternetFaker.Email()
            };

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

        public static Account WithoutRequiredProperty() =>
            new Account()
            {
                AccountNumber = Faker.NumberFaker.Number().ToString(),
                Phone = Faker.PhoneFaker.Phone()
            };

        public static Account WithEmptyRequiredProperty() =>
            new Account()
            {
                AccountName = String.Empty,
                AccountNumber = Faker.NumberFaker.Number().ToString()
            };

        public static Account GetAccountWithFullAccountInfoPart() =>
            new Account()
            {
                AccountName = Faker.InternetFaker.Email(),
                AccountSite = Faker.InternetFaker.Email(),
                ParentAccount = DefaultAcccount().AccountName,
                AccountNumber = Faker.NumberFaker.Number().ToString(),
                Type = "Other",
                Industry = "Education",
                AnnualRevenue = Faker.NumberFaker.Number(4).ToString(),
                Rating = "Hot",
                Phone = Faker.PhoneFaker.Phone().ToString(),
                Fax = Faker.PhoneFaker.Phone().ToString(),
                Website = Faker.InternetFaker.Url(),
                TickerSymbol = Faker.StringFaker.Alpha(5),
                Ownership = "Private",
                Employees = Faker.NumberFaker.Number(3).ToString(),
                SICCode = Faker.NumberFaker.Number(6).ToString()
            };
    }
}
