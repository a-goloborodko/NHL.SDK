using System.Net.Http;

namespace NHL_Core.Client
{
    internal class HttpClientSingleton : HttpClient
    {
        private static HttpClientSingleton instance = null;
        private static readonly object syncRoot = new object();

        private HttpClientSingleton() { }

        public static HttpClientSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new HttpClientSingleton();
                        }
                    }
                }

                return instance;
            }
        }
    }
}
