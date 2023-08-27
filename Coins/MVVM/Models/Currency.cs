using Newtonsoft.Json;

namespace Coins.MVVM.Models
{
    public class Currency
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("supply")]
        public string Supply { get; set; }

        [JsonProperty("maxSupply")]
        public string MaxSupply { get; set; }

        [JsonProperty("marketCapUsd")]
        public decimal MarketCapUsd { get; set; }

        [JsonProperty("volumeUsd24Hr")]
        public decimal VolumeUsd24Hr { get; set; }

        [JsonProperty("priceUsd")]
        public decimal PriceUsd { get; set; }

        [JsonProperty("changePercent24Hr")]
        public string ChangePercent24Hr { get; set; }

        [JsonProperty("vwap24Hr")]
        public string Vwap24Hr { get; set; }
    }
}
