using Newtonsoft.Json.Linq;
using NHL.Data.Interfaces;
using NHL_Core.Client.Constants;
using NHL_Core.Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NHL_Core.Client.RequestHandlers
{
    internal class RequestHandlerBase<TResult> : IRequestHandler<TResult>
        where TResult : INHLModel
    {
        protected static HttpClient HttpClient { get; } = HttpClientSingleton.Instance;

        public virtual async Task<RequestResponse<TResult>> ExecuteRequestAsync(Uri requestUri)
        {
            try
            {
                string responseString = null;

                using (var request = new HttpRequestMessage(HttpMethod.Get, requestUri.AbsoluteUri))
                using (var response = await HttpClient.SendAsync(request))
                {
                    responseString = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        try
                        {
                            var parsedJObject = JObject.Parse(responseString);

                            if (parsedJObject.ContainsKey("message"))
                            {
                                var error = parsedJObject.ToObject<NHLApiError>();
                                return RequestResponse<TResult>.Fail(error.Message);
                            }
                        }
                        catch (Exception)
                        {
                            return RequestResponse<TResult>.Fail(ErrorMessages.InternalError);
                        }

                        return RequestResponse<TResult>.Fail(ErrorMessages.InternalError);
                    }
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
                var result = parsedJObject["data"].ToObject<List<TResult>>();
                return RequestResponse<TResult>.Ok(result);
            }
            catch
            {
                return RequestResponse<TResult>.Fail(ErrorMessages.ParseResponseError);
            }
        }
    }
}
