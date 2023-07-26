using BusinessObject.SalesForce.Model;


namespace BusinessObject.SalesForce
{
    public class ContactBuilder
    {
        public static Contact DefaultContact() =>
            new Contact()
            {
                Id = "003Hr00002QoOs9IAF",
                AccountName = "Thompson",
                LastName = "Thompson"
            };

        public static Contact WithOnlyRequiredProperties() =>
            new Contact()
            {
                LastName = Faker.NameFaker.LastName()
            };

        public static Contact WithFullName()
        {
            var contact = WithOnlyRequiredProperties();
            contact.FirstName = Faker.NameFaker.FirstName();
            return contact;
        }

        public static Contact WithoutRequiredProperty() =>
            new Contact()
            {
                MailingCity = Faker.LocationFaker.City(),
                FirstName = Faker.NameFaker.FirstName(),
                Birthdate = Faker.DateTimeFaker.BirthDay().ToString("yyyy-MM-dd")
            };

        public static Contact WithBirtdateIncorrectFormat() =>
            new Contact()
            {
                LastName = Faker.NameFaker.LastName(),
                FirstName = Faker.NameFaker.FirstName(),
                Birthdate = Faker.DateTimeFaker.BirthDay().ToString("dd.MM.yyyy")
            };

        public static Contact WithPhones()
        {
            var contact = WithOnlyRequiredProperties();
            contact.Phone = Faker.PhoneFaker.Phone();
            contact.OtherPhone = Faker.PhoneFaker.Phone();
            contact.AssistPhone = Faker.PhoneFaker.Phone();
            return contact;
        }

        public static Contact WithUniqueLastName()
        {
            var contact = WithOnlyRequiredProperties();
            contact.LastName = Faker.NameFaker.LastName() + System.DateTime.Now.ToString();
            return contact;
        }
    }
}
