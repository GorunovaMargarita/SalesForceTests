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
        /// <summary>
        /// Get all contacts
        /// </summary>
        /// <returns>Collection of contacts</returns>
        [AllureStep]
        public new ICollection<Contact> GetAllContacts()
        {
            var response = base.GetAllContacts();
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK) || response.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsNotNull(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            return JsonConvert.DeserializeObject<ICollection<Contact>>(jsonResponse.SelectToken("$.recentItems").ToString());
        }

        /// <summary>
        /// Get contact by Id
        /// </summary>
        /// <param name="Id">Unique contact Id</param>
        /// <returns>Contact if success or collection of errors if not success</returns>
        [AllureStep]
        public new T GetContactById<T>(string Id)
        {
            var response = base.GetContactById(Id);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK) || response.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsNotNull(response.Content);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        /// <summary>
        /// Create contact
        /// </summary>
        /// <param name="contact">Contact model</param>
        /// <returns></returns>
        [AllureStep]
        public new T CreateContact<T>(Contact contact)
        {
            var response = base.CreateContact(contact);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.Created) || response.StatusCode.Equals(HttpStatusCode.BadRequest));
            Assert.IsNotNull(response.Content);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        /// <summary>
        /// Change contact
        /// </summary>
        /// <param name="contacttForChangeId">Id contact for change</param>
        /// <param name="contact">JObject Contact model. Set fields for change only</param>
        /// <returns>CreateResponse if success or collection of errors if not success</returns>
        [AllureStep]
        public new T ChangeContact<T>(string contacttForChangeId, JObject contact)
        {
            var response = base.ChangeContact(contacttForChangeId, contact);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.NoContent) || response.StatusCode.Equals(HttpStatusCode.BadRequest));
            Assert.IsNotNull(response.Content);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="Id">Unique contact Id</param>
        /// <returns>Empty or collection of errors if not success</returns>
        [AllureStep]
        public new T DeleteContact<T>(string Id)
        {
            var response = base.DeleteContact(Id);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.NoContent) || response.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsNotNull(response.Content);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        /// <summary>
        /// Get random Contact
        /// </summary>
        /// <returns>Contact</returns>
        [AllureStep]
        public Contact GetAndReturnRandomContact()
        {
            var accContactCollection = GetAllContacts();
            accContactCollection.Remove(accContactCollection.First(a => a.Id.Equals(ContactBuilder.DefaultContact().Id)));
            var randomContact = accContactCollection.FirstOrDefault();
            return GetContactById<Contact>(randomContact.Id);
        }
    }
}
