using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class PaymentMethod
    {
        [JsonProperty("paymentMethodDisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("requiredElement")]
        public string RequiredElement { get; set; }

        [JsonProperty("paymentMethodName")]
        public string Name { get; set; }
    }
}