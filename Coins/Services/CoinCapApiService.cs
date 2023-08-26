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

        public async Task<List<Currency>> GetCurrenciesAsync()
        {
            var url = $"{BaseUrl}assets";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<CurrenciesApiResponse>(content);
                var currencies = apiResponse.Currencies;

                return currencies;
            }
            else
            {
                return null;
            }
        }

        public async Task<Currency> GetCurrencyByIdAsync(string id)
        {
            var url = $"{BaseUrl}assets/{id}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<CurrencyApiResponse>(content);
                var currency = apiResponse.Currency;

                return currency;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<CurrencyMarketInfo>> GetMarketsInfoByCurrencyIdAsync(string id)
        {
            var url = $"{BaseUrl}assets/{id}/markets";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<MarketApiResponse>(content);
                var marketsInfo = apiResponse.MarketsInfo;

                return marketsInfo;
            }
            else
            {
                return null;
            }
        }


    }

    public class CurrenciesApiResponse
    {
        [JsonProperty("data")]
        public List<Currency>? Currencies { get; set; }
    }

    public class CurrencyApiResponse
    {
        [JsonProperty("data")]
        public Currency Currency { get; set; }
    }

    public class MarketApiResponse
    {
        [JsonProperty("data")]
        public List<CurrencyMarketInfo>? MarketsInfo { get; set; }
    }
}


