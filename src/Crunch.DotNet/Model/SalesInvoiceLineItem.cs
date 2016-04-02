using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class SalesInvoiceLineItem
    {
        [JsonProperty("lineItemDescription")]
        public string LineItemDescription { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        [JsonProperty("lineItemAmount")]
        public Amount LineItemAmount { get; set; }

        [JsonProperty("vatType")]
        public string VatType { get; set; }
    }
}