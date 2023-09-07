using Newtonsoft.Json;
using System.Collections.Generic;

namespace Coins.MVVM.Models.ApiResponceDtos
{
    public class CurrenciesApiResponse
    {
        [JsonProperty("data")]
        public List<Currency>? Currencies { get; set; }
    }
}
