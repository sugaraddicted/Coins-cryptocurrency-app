using Newtonsoft.Json;

namespace Coins.MVVM.Models.ApiResponceDtos
{
    public class CurrencyApiResponse
    {
        [JsonProperty("data")]
        public Currency Currency { get; set; }
    }
}
