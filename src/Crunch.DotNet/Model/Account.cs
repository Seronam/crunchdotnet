using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class Account
    {
        [JsonProperty("accountId")]
        public long AccountId { get; set; }

        [JsonProperty("lastFourDigits")]
        public long LastFourDigits { get; set; }

        [JsonProperty("sortCode")]
        public string SortCode { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
