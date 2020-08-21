using SearchFight.Infraestructure.ResponseEntities.Bing;
using SearchFight.Infraestructure.SearchEngineAPIs;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SearchFight.Infraestructure.SearchEngineApiClients.Bing
{
    public class BingQuery : ISearchEngineAPI
    {
        public string Name => "Bing";

        private readonly string _apiKey = "";
        private const string _baseUri = "https://api.cognitive.microsoft.com/bing/v7.0/search";

        private bool IsKeyProvided()
        {
            return !string.IsNullOrEmpty(_apiKey) && _apiKey.Length == 32;
        }

        public async Task<long> GetAmountOfResults(string searchTerm)
        {
            if (!IsKeyProvided())
            {
                throw new Exception("The api key required is not provided or invalid.");
            }

            if (string.IsNullOrEmpty(searchTerm))
            {
                throw new ArgumentException("The specified search term is null or empty.", nameof(searchTerm));
            }

            string requestUri = _baseUri + "?q=" + Uri.EscapeDataString(searchTerm);

            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            requestMessage.Headers.Add("Ocp-Apim-Subscription-Key", _apiKey);

            var response = await HttpClientInstance.Client.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            BingQueryResponse result = JsonSerializer.Deserialize<BingQueryResponse>(await response.Content.ReadAsStringAsync());
            return result.webPages.totalEstimatedMatches;
        }
    }
}
