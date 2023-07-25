using BusinessObject.SalesForce.Model;
using Newtonsoft.Json;
using RestSharp;

namespace BusinessObject.SalesForce.API.Steps
{
    internal static class Common
    {
        /// <summary>
        /// Parse RestResponse
        /// </summary>
        /// <typeparam name="T">Type of CommonResponse.Data</typeparam>
        /// <param name="response">RestResponse</param>
        /// <param name="responseBodyPart">Part of RestResponse. Use it if CommonResponse.Data must be deserialized using only this part of RestResponse</param>
        /// <returns>CommonResponse<T></returns>
        internal static CommonResponse<T> ParseContent<T>(RestResponse response, string responseBodyPart = null)
        {
            var commonResponse = new CommonResponse<T>();
            commonResponse.StatusCode = response.StatusCode.ToString();
            if (response.Content == null)
            {
                commonResponse.Data = default(T);
                commonResponse.Errors = null;
            }
            else
            {
                try
                {
                    commonResponse.Data = responseBodyPart == null ? JsonConvert.DeserializeObject<T>(response.Content) : JsonConvert.DeserializeObject<T>(responseBodyPart);
                }
                catch (Exception e) when (e is JsonSerializationException)
                {
                    commonResponse.Data = default(T);
                    try
                    {
                        commonResponse.Errors = JsonConvert.DeserializeObject<ICollection<Error>>(response.Content);
                    }
                    catch (Exception ex) when (ex is JsonSerializationException)
                    {
                        commonResponse.Errors = null;
                    }
                }
            }
            return commonResponse;
        }
    }
}
