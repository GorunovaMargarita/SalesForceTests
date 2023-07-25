using BusinessObject.SalesForce.Model;
using Core.API;
using Core.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;


namespace BusinessObject.SalesForce.API.Services
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

        public RestResponse CreateAccount(Account account)
        {
            var request = new RestRequest(AccountEndpoint, Method.Post);
            request.AddBody(JsonConvert.SerializeObject(account));
            return apiClient.Execute(request);
        }

        public RestResponse ChangeAccount(string id, JObject account)
        {
            var request = new RestRequest(AccountByIdEndpoint, Method.Patch).AddUrlSegment("id", id);
            request.AddBody(JsonConvert.SerializeObject(account));
            return apiClient.Execute(request);
        }

        public RestResponse DeleteAccount(string id)
        {
            var request = new RestRequest(AccountByIdEndpoint, Method.Delete).AddUrlSegment("id", id);
            return apiClient.Execute(request);
        }
    }
}
