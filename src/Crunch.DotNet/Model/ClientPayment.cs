using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class ClientPayment
    {
        [JsonProperty("clientPaymentId")]
        public string ClientPaymentId { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("resourceUrl")]
        public string ResourceUrl { get; set; }

        [JsonProperty("client")]
        public Client Client { get; set; }

        [JsonProperty("processingExpense")]
        public Expense ProcessingExpense { get; set; }

        [JsonProperty("salesInvoices")]
        public SalesInvoices SalesInvoices { get; set; }
    }
}