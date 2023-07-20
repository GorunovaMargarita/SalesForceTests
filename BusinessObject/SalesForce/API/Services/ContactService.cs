using BusinessObject.SalesForce.Model;
using Core.API;
using Core.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace BusinessObject.SalesForce.API.Services
{
    public class ContactService : BaseService
    {
        public string ContactEndpoint = "/sobjects/Contact/";
        public string ContactByIdEndpoint = "/sobjects/Contact/{id}";

        public ContactService() : base(Configurator.API.BaseUrl)
        {
            apiClient.AddAuthToken(Configurator.API.Token);
        }

        public RestResponse GetAllContacts()
        {
            var request = new RestRequest(ContactEndpoint);
            return apiClient.Execute(request);
        }

        public RestResponse GetContactById(string id)
        {
            var request = new RestRequest(ContactByIdEndpoint).AddUrlSegment("id", id);
            return apiClient.Execute(request);
        }

        public RestResponse CreateContact(Contact contact)
        {
            var request = new RestRequest(ContactEndpoint, Method.Post);
            request.AddBody(JsonConvert.SerializeObject(contact));
            return apiClient.Execute(request);
        }

        public RestResponse ChangeContact(string id, JObject contact)
        {
            var request = new RestRequest(ContactByIdEndpoint, Method.Patch).AddUrlSegment("id", id);
            request.AddBody(JsonConvert.SerializeObject(contact));
            return apiClient.Execute(request);
        }

        public RestResponse DeleteContact(string id)
        {
            var request = new RestRequest(ContactByIdEndpoint, Method.Delete).AddUrlSegment("id", id);
            return apiClient.Execute(request);
        }
    }
}
