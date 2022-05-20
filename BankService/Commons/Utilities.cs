using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BankService.Commons
{
    public class Utilities
    {
        private static HttpClient BuildHeader(HttpClient httpClient, string apiKey)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);

            return httpClient;
        }

        public static async Task<HttpResponseMessage> Get(string url, string apiKey)
        {
            using (var httpClient = new HttpClient())
            {
                var client = BuildHeader(httpClient, apiKey);

                HttpResponseMessage response = await client.GetAsync(url);

                return response;

            }
        }
    }
}
