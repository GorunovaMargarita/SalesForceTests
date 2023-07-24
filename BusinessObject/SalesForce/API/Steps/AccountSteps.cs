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
        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <returns>Collection of accounts</returns>
        [AllureStep]
        public new ICollection<Account> GetAllAccounts()
        {
            var response = base.GetAllAccounts();
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK) || response.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsNotNull(response.Content);
            var jsonResponse = JObject.Parse(response.Content);
            return JsonConvert.DeserializeObject<ICollection<Account>>(jsonResponse.SelectToken("$.recentItems").ToString());
        }

        /// <summary>
        /// Get account by Id
        /// </summary>
        /// <param name="Id">Unique account Id</param>
        /// <returns>Account if success or collection of errors if not success</returns>
        [AllureStep]
        public new T GetAccountById<T>(string Id)
        {
            var response = base.GetAccountById(Id);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK) || response.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsNotNull(response.Content);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        /// <summary>
        /// Create account
        /// </summary>
        /// <param name="account">Account model</param>
        /// <returns></returns>
        [AllureStep]
        public new T CreateAccount<T>(Account account)
        {
            var response = base.CreateAccount(account);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.Created) || response.StatusCode.Equals(HttpStatusCode.BadRequest));
            Assert.IsNotNull(response.Content);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        /// <summary>
        /// Change account
        /// </summary>
        /// <param name="accountForChangeId">Id account for change</param>
        /// <param name="account">JObject Account model. Set fields for change only</param>
        /// <returns>CreateResponse if success or collection of errors if not success</returns>
        [AllureStep]
        public new T ChangeAccount<T>(string accountForChangeId, JObject account)
        {
            var response = base.ChangeAccount(accountForChangeId, account);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.NoContent) || response.StatusCode.Equals(HttpStatusCode.BadRequest));
            Assert.IsNotNull(response.Content);
            return JsonConvert.DeserializeObject<T>(response.Content);
            //else return null;
        }

        /// <summary>
        /// Delete account
        /// </summary>
        /// <param name="Id">Unique account Id</param>
        /// <returns>Empty or collection of errors if not success</returns>
        [AllureStep]
        public new T DeleteAccount<T>(string Id)
        {
            var response = base.DeleteAccount(Id);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.NoContent) || response.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.IsNotNull(response.Content);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        /// <summary>
        /// Get random account
        /// </summary>
        /// <returns>Account</returns>
        [AllureStep]
        public Account GetAndReturnRandomAccount()
        {
            var allAccountCollection = GetAllAccounts();
            allAccountCollection.Remove(allAccountCollection.First(a => a.Id.Equals(AccountBuilder.DefaultAcccount().Id)));
            var randomAccount = allAccountCollection.FirstOrDefault();
            return GetAccountById<Account>(randomAccount.Id);
        }
    }
}
