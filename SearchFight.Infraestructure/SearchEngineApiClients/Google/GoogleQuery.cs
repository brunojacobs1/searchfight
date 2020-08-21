using SearchFight.Infraestructure.ResponseEntities.Google;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace SearchFight.Infraestructure.SearchEngineAPIs.Google
{
    public class GoogleQuery : ISearchEngineAPI
    {
        public string Name => "Google";

        private readonly string _apiKey = "";
        private readonly string _searchEngineId = "";
        private const string _baseUri = "https://www.googleapis.com/customsearch/v1";

        private bool AreKeysProvided()
        {
            return !string.IsNullOrEmpty(_apiKey) && !string.IsNullOrEmpty(_searchEngineId);
        }

        public async Task<long> GetAmountOfResults(string searchTerm)
        {
            if (!AreKeysProvided())
            {
                throw new Exception("One or both of the keys required are not provided or invalid.");
            }
           
            if (string.IsNullOrEmpty(searchTerm))
            {
                throw new ArgumentException("The specified search term is null or empty.", nameof(searchTerm));
            }

            string requestUri = _baseUri +"?key=" + _apiKey + "&cx=" + _searchEngineId 
                + "&q=" + Uri.EscapeDataString(searchTerm);

            using var response = await HttpClientInstance.Client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            GoogleQueryResponse result = JsonSerializer.Deserialize<GoogleQueryResponse>(await response.Content.ReadAsStringAsync());
            return long.Parse(result.searchInformation.totalResults);

        }
    }
}
