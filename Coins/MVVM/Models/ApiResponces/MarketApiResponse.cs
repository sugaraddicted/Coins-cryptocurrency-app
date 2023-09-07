using Newtonsoft.Json;
using System.Collections.Generic;

namespace Coins.MVVM.Models.ApiResponceDtos
{
    public class MarketApiResponse
    {
        [JsonProperty("data")]
        public List<CurrencyMarketInfo>? MarketsInfo { get; set; }
    }
}
