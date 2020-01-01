using Newtonsoft.Json.Linq;
using NHL.Data.Attributes;
using NHL.Data.Interfaces;
using NHL_Core.Client.Constants;
using NHL_Core.Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace NHL_Core.Client.RequestHandlers
{
    internal class RequestHandlerBase<TResult> : IRequestHandler<TResult>
        where TResult : INHLModel
    {
        protected static HttpClient HttpClient { get; } = HttpClientSingleton.Instance;
        private static string jsonObjectAnnotationName;

        #region ctors

        static RequestHandlerBase()
        {
            jsonObjectAnnotationName = typeof(TResult).GetCustomAttribute<ObjectAnnotationAttribute>()?.JsonObjectName;
        }

        #endregion

        public virtual async Task<RequestResponse<TResult>> ExecuteRequestAsync(Uri requestUri)
        {
            try
            {
                string responseString = null;

                using (var request = new HttpRequestMessage(HttpMethod.Get, requestUri.AbsoluteUri))
                using (var response = await HttpClient.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        return RequestResponse<TResult>.Fail(ErrorMessages.InternalError);
                    }

                    responseString = await response.Content.ReadAsStringAsync();
                }

                return DeserializeResponse(responseString);

            }
            catch (Exception)
            {
                return RequestResponse<TResult>.Fail(ErrorMessages.InternalError);
            }
        }

        private RequestResponse<TResult> DeserializeResponse(string responseString)
        {
            try
            {
                var parsedJObject = JObject.Parse(responseString);
                var result = parsedJObject[jsonObjectAnnotationName].ToObject<List<TResult>>();

                return RequestResponse<TResult>.Ok(result);
            }
            catch
            {
                return RequestResponse<TResult>.Fail(ErrorMessages.ParseResponseError);
            }
        }
    }
}
