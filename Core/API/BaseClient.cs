﻿using RestSharp;
using System.Text;


namespace Core.API
{
    public class BaseClient
    {
        private RestClient restClient;
        public BaseClient(string url)
        {
            var option = new RestClientOptions(url)
            {
                MaxTimeout = 10000,
                ThrowOnAnyError = false
            };
            restClient = new RestClient(option);
            restClient.AddDefaultHeader("Content-Type", "application/json");
        }

        public void AddAuthToken(string Token)
        {
            restClient.AddDefaultHeader("Authorization", Token);
        }

        public RestResponse Execute(RestRequest request)
        {
            Log.Instance.Logger.Info($"Request method: {request.Method},\r\n URI: {restClient.BuildUri(request)}");
            Log.Instance.Logger.Info(RequestToLog(request));
            var response = restClient.Execute<RestResponse>(request);
            Log.Instance.Logger.Info($"Response content: {response.Content.Normalize()}");
            return response;
        }

        public T Execute<T>(RestRequest request)
        {
            Log.Instance.Logger.Info(request);
            var response = restClient.Execute<T>(request);
            Log.Instance.Logger.Info($"Response content: {response.Content.Normalize()}");
            return response.Data;
        }

        public string RequestToLog(RestRequest request)
        {
            var stringBuilder = new StringBuilder();
            Log.Instance.Logger.Info("Request parameters: \r\n");
            foreach (var param in request.Parameters)
            {
                stringBuilder.AppendFormat("{0}: {1}\r\n", param.Name, param.Value);
            }
            return stringBuilder.ToString();
        }
    }
}
