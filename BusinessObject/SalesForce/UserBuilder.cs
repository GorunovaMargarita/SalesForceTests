using Bogus;
using BusinessObject.SalesForce.Model;
using Core;
using Core.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce
{
    public class UserBuilder
    {
        public static User GetSalesForceUser() => new User(Configurator.Browser.UserName, Configurator.Browser.UserPassword);

        public static User GetRandomUser() => new User(Faker.InternetFaker.Email(), Faker.StringFaker.Alpha(10));
    }
}
