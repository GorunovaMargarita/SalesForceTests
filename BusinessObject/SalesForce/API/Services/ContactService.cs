using Core;
using Core.API;
using Core.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
