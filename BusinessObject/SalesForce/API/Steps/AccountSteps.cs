﻿using BusinessObject.SalesForce.API.Services;
using BusinessObject.SalesForce.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Allure.Attributes;
using System.Net;

namespace BusinessObject.SalesForce.API.Steps
{
    public class AccountSteps : AccountService
    {
        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <returns>CommonResponse&lt;ICollection&lt;Account&gt;&gt;</returns>
        [AllureStep]
        public new CommonResponse<ICollection<Account>> GetAllAccounts()
        {
            var response = base.GetAllAccounts();
            string responseBodyPart = null;
            if (response.Content != null)
            {
                try
                {
                    responseBodyPart = JObject.Parse(response.Content).SelectToken("$.recentItems").ToString();
                }
                catch (Exception ex) when (ex is JsonReaderException)
                {
                    responseBodyPart = null;
                }
            }
            return Common.ParseContent<ICollection<Account>>(response, responseBodyPart);
        }

        /// <summary>
        /// Get account by Id
        /// </summary>
        /// <param name="Id">Unique account Id</param>
        /// <returns>CommonResponse&lt;Account&gt;</returns>
        [AllureStep]
        public new CommonResponse<Account> GetAccountById(string Id)
        {
            var response = base.GetAccountById(Id);
            return Common.ParseContent<Account>(response);
        }

        /// <summary>
        /// Create account
        /// </summary>
        /// <param name="account">Account model</param>
        /// <returns>CommonResponse&lt;CreateResponse&gt;</returns>
        [AllureStep]
        public new CommonResponse<CreateResponse> CreateAccount(Account account)
        {
            var response = base.CreateAccount(account);
            return Common.ParseContent<CreateResponse>(response);
        }

        /// <summary>
        /// Change account
        /// </summary>
        /// <param name="accountForChangeId">Id account for change</param>
        /// <param name="account">JObject Account model. Set fields for change only</param>
        /// <returns>CommonResponse&lt;EmptyResponse&gt;</returns>
        [AllureStep]
        public new CommonResponse<EmptyResponse> ChangeAccount(string accountForChangeId, JObject account)
        {
            var response = base.ChangeAccount(accountForChangeId, account);
            return Common.ParseContent<EmptyResponse>(response);
        }

        /// <summary>
        /// Delete account
        /// </summary>
        /// <param name="Id">Unique account Id</param>
        /// <returns>CommonResponse&lt;EmptyResponse&gt;</returns>
        [AllureStep]
        public new CommonResponse<EmptyResponse> DeleteAccount(string Id)
        {
            var response = base.DeleteAccount(Id);
            return Common.ParseContent<EmptyResponse>(response);
        }

        /// <summary>
        /// Get random account
        /// </summary>
        /// <returns>Account</returns>
        [AllureStep]
        public Account GetAndReturnRandomAccount()
        {
            var allAccountCollection = GetAllAccounts().Data;
            allAccountCollection?.Remove(allAccountCollection.First(a => a.Id.Equals(AccountBuilder.DefaultAcccount().Id)));
            var randomAccount = allAccountCollection.ElementAt(new Random().Next(allAccountCollection.Count - 1));
            return GetAccountById(randomAccount.Id).Data;
        }
    }
}
