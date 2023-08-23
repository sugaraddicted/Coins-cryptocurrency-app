using Coins.MVVM.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Coins.Services
{
    public class CoinGeckoApiService
    {
        private const string BaseUrl = "https://api.coingecko.com/api/v3/";

        private readonly HttpClient _httpClient;

        public CoinGeckoApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Currency>> GetTopCurrenciesAsync(int limit)
        {
            var url = $"{BaseUrl}coins/markets?vs_currency=usd&order=market_cap_desc&per_page={limit}&page=1";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var currencies = JsonConvert.DeserializeObject<List<Currency>>(content);
                return currencies;
            }
            else
            {
                return null;
            }
        }
    }
}
