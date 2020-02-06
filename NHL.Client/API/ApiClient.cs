using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NHL.Client.API
{
    internal class ApiClient : IApiClient
    {
        private HttpClientSingleton _httpClient;

        protected HttpClient HttpClient
        {
            get
            {
                if (_httpClient != null)
                {
                    return _httpClient;
                }

                _httpClient = HttpClientSingleton.Instance;

                return _httpClient;
            }
        }

        public virtual async Task<ApiResult<T>> GetAsync<T>(Uri uri)
        {
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Get;
                request.RequestUri = uri;
                try
                {
                    var response = await HttpClient.SendAsync(request);

                    if (!response.IsSuccessStatusCode)
                    {
                        return new ApiResult<T>((int)response.StatusCode, default(T));
                    }

                    //if (typeof(T) == typeof(byte[]))
                    //{
                    //    var responseData = await response.Content.ReadAsByteArrayAsync();
                    //    return new ApiResult<T>((int)response.StatusCode, (T)(object)responseData);
                    //}

                    string responseString = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(responseString))
                    {
                        return new ApiResult<T>((int)HttpStatusCode.BadRequest, default(T));
                    }

                    //if (typeof(T) == typeof(String))
                    //{
                        return new ApiResult<T>((int)response.StatusCode, (T)(object)responseString);
                    //}

                    //if (typeof(T) == typeof(bool))
                    //{
                    //    return new ApiResult<T>((int)response.StatusCode, (T)((object)bool.Parse(responseString)));
                    //}

                    //var model = JsonConvert.DeserializeObject<T>(responseString);

                    //return new ApiResult<T>((int)response.StatusCode, model);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("API Call failed. " + ex);
                    return new ApiResult<T>((int)HttpStatusCode.InternalServerError, default(T));
                }
            }
        }
    }
}
