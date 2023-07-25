using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using System.Net;
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

        [AllureStep]
        public new object CreateContact(Contact contact)
        {
            var response = base.CreateContact(contact);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.Created) || response.StatusCode.Equals(HttpStatusCode.BadRequest));
            Assert.IsNotNull(response.Content);
            if (response.StatusCode.Equals(HttpStatusCode.Created))
                return JsonConvert.DeserializeObject<CreateResponse>(response.Content);
            else
                return JsonConvert.DeserializeObject<ICollection<Error>>(response.Content);
        }

        [AllureStep]
        public new object ChangeContact(string contacttForChangeId, JObject contact)
        {
            var response = base.ChangeContact(contacttForChangeId, contact);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.NoContent) || response.StatusCode.Equals(HttpStatusCode.BadRequest));
            Assert.IsNotNull(response.Content);
            if (response.StatusCode.Equals(HttpStatusCode.BadRequest))
                return JsonConvert.DeserializeObject<ICollection<Error>>(response.Content);
            else return null;
        }

        [AllureStep]
        public new object DeleteContact(string Id)
        {
            var response = base.DeleteContact(Id);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.NoContent) || response.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsNotNull(response.Content);
            if (response.StatusCode.Equals(HttpStatusCode.NotFound))
                return JsonConvert.DeserializeObject<ICollection<Error>>(response.Content);
            else return null;
        }

        [AllureStep]
        public Contact GetAndReturnRandomContact()
        {
            var accContactCollection = GetAllContacts();
            accContactCollection.Remove(accContactCollection.First(a => a.Id.Equals(ContactBuilder.DefaultContact().Id)));
            var randomContact = accContactCollection.FirstOrDefault();
            return (Contact)GetContactById(randomContact.Id);
        }
    }
}
