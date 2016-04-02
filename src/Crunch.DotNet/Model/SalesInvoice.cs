using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class SalesInvoice
    {
        [JsonProperty("salesInvoiceId")]
        public long SalesInvoiceId { get; set; }

        [JsonProperty("resourceUrl")]
        public string ResourceUrl { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("allocatedAmount")]
        public decimal AllocatedAmount { get; set; }

        [JsonProperty("salesInvoiceDetails")]
        public SalesInvoiceDetails SalesInvoiceDetails { get; set; }

        [JsonProperty("salesInvoiceLineItems")]
        public SalesInvoiceLineItems SalesInvoiceLineItems { get; set; }

        [JsonProperty("clientPayments")]
        public ClientPayments ClientPayments { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("document")]
        public File Document { get; set; }
    }
}