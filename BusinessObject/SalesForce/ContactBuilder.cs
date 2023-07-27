using BusinessObject.SalesForce.Model;
using System.Text;

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
                LastName = Faker.NameFaker.LastName(),
            };
        public static Contact WithFullNameAndSalutation() =>
            new Contact()
            {
                LastName = Faker.NameFaker.LastName(),
                FirstName = Faker.NameFaker.FirstName(),
                Salutation = "Ms."
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

        public static Contact WithLongDescription()
        {
            var contact = WithOnlyRequiredProperties();
            contact.Description = StringGenerator(4000);
            return contact;
        }

        public static Contact WithMediumDescription()
        {
            var contact = WithOnlyRequiredProperties();
            contact.Description = StringGenerator(100);
            return contact;
        }

        private static string StringGenerator(int length)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZабвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ+-*/`~!#№$:;%^&?<>«»    ";
            StringBuilder stringBuilder = new StringBuilder(); 
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                stringBuilder.Append(chars[index]);
            }
            return stringBuilder.ToString();
        }
    }
}
