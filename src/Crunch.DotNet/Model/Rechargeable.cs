using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class Rechargeable
    {
        [JsonProperty("customerId")]
        public long CustomerId { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}