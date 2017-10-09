using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace IMS.Web.Helpers
{
    public static class ApiHttpClient
    {
        public static HttpClient GetClient()
        {
            var client = new HttpClient {BaseAddress = new Uri("http://localhost:10853/")};

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}