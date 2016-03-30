using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class Amount
    {
        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("netAmount")]
        public decimal NetAmount { get; set; }

        [JsonProperty("grossAmount")]
        public decimal GrossAmount { get; set; }

        [JsonProperty("vatAmount")]
        public decimal VatAmount { get; set; }

        [JsonProperty("vatRate")]
        public decimal VatRate { get; set; }
    }
}