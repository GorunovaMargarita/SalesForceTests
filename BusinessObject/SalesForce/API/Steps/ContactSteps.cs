using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.SalesForce.Model;
using BusinessObject.SalesForce.API.Services;

namespace BusinessObject.SalesForce.API.Steps
{
    public class ContactSteps : ContactService
    {
        [AllureStep]
        public new ICollection<Contact> GetAllContacts()
        {
            var response = base.GetAllContacts();
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK) || response.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsNotNull(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            return JsonConvert.DeserializeObject<ICollection<Contact>>(jsonResponse.SelectToken("$.recentItems").ToString());
        }

        [AllureStep]
        public new object GetContactById(string Id)
        {
            var response = base.GetContactById(Id);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK) || response.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsNotNull(response.Content);
            if (response.StatusCode.Equals(HttpStatusCode.OK))
                return JsonConvert.DeserializeObject<Contact>(response.Content);
            else
                return JsonConvert.DeserializeObject<ICollection<Error>>(response.Content);
        }
    }
}
