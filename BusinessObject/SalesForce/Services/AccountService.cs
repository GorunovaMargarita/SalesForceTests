using Core;
using Core.API;
using Core.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce.Services
{
    public class AccountService : BaseService
    {
        public string AccountEndpoint = "/sobjects/Account/";
        public string AccountByIdEndpoint = "/sobjects/Account/{id}";

        public AccountService() : base(Configurator.API.BaseUrl)
        {
            apiClient.AddAuthToken(Configurator.API.Token);
        }

        public RestResponse GetAllAccounts()
        {
            var request = new RestRequest(AccountEndpoint);
            return apiClient.Execute(request);
        }

        public RestResponse GetAccountById(string id)
        {
            var request = new RestRequest(AccountByIdEndpoint).AddUrlSegment("id", id);
            return apiClient.Execute(request);
        }
    }
}
