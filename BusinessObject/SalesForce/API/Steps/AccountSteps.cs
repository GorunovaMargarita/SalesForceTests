using BusinessObject.SalesForce.Model;
using BusinessObject.SalesForce.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using System.Net;


namespace BusinessObject.SalesForce.API.Steps
{
    public class AccountSteps : AccountService
    {
        [AllureStep]
        public ICollection<Account> GetAllAccounts()
        {
            var response = base.GetAllAccounts();
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK) || response.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsNotNull(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            return JsonConvert.DeserializeObject<ICollection<Account>>(jsonResponse.SelectToken("$.recentItems").ToString());
        }
    }
}
