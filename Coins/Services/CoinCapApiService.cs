using Coins.MVVM.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Coins.Services
{
    public class CoinCapApiService
    {
        private const string BaseUrl = "https://api.coincap.io/v2/";

        private readonly HttpClient _httpClient;

        public CoinCapApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Currency>> GetTopCurrenciesAsync()
        {
            var url = $"{BaseUrl}assets"; // Corrected URL to fetch assets
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                // The API response structure has a nested 'data' property containing an array of currencies
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);
                var currencies = apiResponse.Data;

                return currencies;
            }
            else
            {
                return null;
            }
        }
    }

    // Define the ApiResponse class to match the structure of the API response
    public class ApiResponse
    {
        public List<Currency> Data { get; set; }
    }
}
