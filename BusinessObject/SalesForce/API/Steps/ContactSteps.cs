using Newtonsoft.Json.Linq;
using NUnit.Allure.Attributes;
using BusinessObject.SalesForce.Model;
using BusinessObject.SalesForce.API.Services;
using OpenQA.Selenium.DevTools.V112.DOM;

namespace BusinessObject.SalesForce.API.Steps
{
    public class ContactSteps : ContactService
    {

        /// <summary>
        /// Get all contacts
        /// </summary>
        /// <returns>CommonResponse<ICollection<Contact>></returns>
        [AllureStep]
        public new CommonResponse<ICollection<Contact>> GetAllContacts()
        {
            var response = base.GetAllContacts();
            return Common.ParseContent<ICollection<Contact>>(response, responseBodyPart: response.Content == null ? null : JObject.Parse(response.Content).SelectToken("$.recentItems").ToString());
        }

        /// <summary>
        /// Get contact by Id
        /// </summary>
        /// <param name="Id">Unique contact Id</param>
        /// <returns>CommonResponse<Contact></returns>
        [AllureStep]
        public new CommonResponse<Contact> GetContactById(string Id)
        {
            var response = base.GetContactById(Id);
            return Common.ParseContent<Contact>(response);
        }

        /// <summary>
        /// Create contact
        /// </summary>
        /// <param name="contact">Contact model</param>
        /// <returns>CommonResponse<CreateResponse></returns>
        [AllureStep]
        public new CommonResponse<CreateResponse> CreateContact(Contact contact)
        {
            var response = base.CreateContact(contact);
            return Common.ParseContent<CreateResponse>(response);
        }

        /// <summary>
        /// Change contact
        /// </summary>
        /// <param name="contactForChangeId">Id contact for change</param>
        /// <param name="contact">JObject Contact model. Set fields for change only</param>
        /// <returns>CommonResponse<EmptyResponse></returns>
        [AllureStep]
        public new CommonResponse<EmptyResponse> ChangeContact(string contactForChangeId, JObject contact)
        {
            var response = base.ChangeContact(contactForChangeId, contact);
            return Common.ParseContent<EmptyResponse>(response);
        }

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="Id">Unique contact Id</param>
        /// <returns>CommonResponse<EmptyResponse></returns>
        [AllureStep]
        public new CommonResponse<EmptyResponse> DeleteContact(string Id)
        {
            var response = base.DeleteContact(Id);
            return Common.ParseContent<EmptyResponse>(response);
        }

        /// <summary>
        /// Get random Contact
        /// </summary>
        /// <returns>Contact</returns>
        [AllureStep]
        public Contact GetAndReturnRandomContact()
        {
            var allContactCollection = GetAllContacts().Data;
            allContactCollection?.Remove(allContactCollection.First(a => a.Id.Equals(ContactBuilder.DefaultContact().Id)));
            var randomContact = allContactCollection.ElementAt(new Random().Next(allContactCollection.Count - 1));
            return GetContactById(randomContact.Id).Data;
        }

        /// <summary>
        /// Create and get new contact
        /// </summary>
        /// <param name="contact">Contact model</param>
        /// <returns>Contact</returns>
        public Contact CreateAndGetContact(Contact contact)
        {
            var newContactId = CreateContact(contact).Data.Id;
            return GetContactById(newContactId).Data;
        }
    }
}
