using BusinessObject.SalesForce.API.Services;
using BusinessObject.SalesForce.Model;
using FluentAssertions;
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
        public new ICollection<Account> GetAllAccounts()
        {
            var response = base.GetAllAccounts();
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK) || response.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsNotNull(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            return JsonConvert.DeserializeObject<ICollection<Account>>(jsonResponse.SelectToken("$.recentItems").ToString());
        }

        [AllureStep]
        public new object GetAccountById(string Id)
        {
            var response = base.GetAccountById(Id);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK) || response.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsNotNull(response.Content);
            if(response.StatusCode.Equals(HttpStatusCode.OK)) 
                return JsonConvert.DeserializeObject<Account>(response.Content);
            else
                return JsonConvert.DeserializeObject<ICollection<Error>>(response.Content);
        }

        [AllureStep]
        public new object CreateAccount(Account account)
        {
            var response = base.CreateAccount(account);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.Created) || response.StatusCode.Equals(HttpStatusCode.BadRequest));
            Assert.IsNotNull(response.Content);
            if (response.StatusCode.Equals(HttpStatusCode.Created))
                return JsonConvert.DeserializeObject<CreateResponse>(response.Content);
            else
                return JsonConvert.DeserializeObject<ICollection<Error>>(response.Content);
        }

        [AllureStep]
        public new object ChangeAccount(string accountForChangeId, JObject account)
        {
            var response = base.ChangeAccount(accountForChangeId, account);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.NoContent) || response.StatusCode.Equals(HttpStatusCode.BadRequest));
            Assert.IsNotNull(response.Content);
            if (response.StatusCode.Equals(HttpStatusCode.BadRequest))
                return JsonConvert.DeserializeObject<ICollection<Error>>(response.Content);
            else return null;
        }

        [AllureStep]
        public new object DeleteAccount(string Id)
        {
            var response = base.DeleteAccount(Id);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.NoContent) || response.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsNotNull(response.Content);
            if (response.StatusCode.Equals(HttpStatusCode.NotFound))
                return JsonConvert.DeserializeObject<ICollection<Error>>(response.Content);
            else return null;
        }

        [AllureStep]
        public Account GetAndReturnRandomAccount()
        {
            var allAccountCollection = GetAllAccounts();
            allAccountCollection.Remove(allAccountCollection.First(a => a.Id.Equals(AccountBuilder.DefaultAcccount().Id)));
            var randomAccount = allAccountCollection.FirstOrDefault();
            return (Account)GetAccountById(randomAccount.Id);
        }
    }
}
