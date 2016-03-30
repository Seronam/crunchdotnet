using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class Expense
    {
        [JsonProperty("expenseId")]
        public long ExpenseId { get; set; }

        [JsonProperty("resourceUrl")]
        public string ResourceUrl { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("expenseDetails")]
        public ExpenseDetails ExpenseDetails { get; set; }

        [JsonProperty("expenseLineItems")]
        public ExpenseLineItems ExpenseLineItems { get; set; }

        [JsonProperty("paymentDetails")]
        public PaymentDetails PaymentDetails { get; set; }

        [JsonProperty("receipts")]
        public IList<Receipts> Receipts { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }
    }
}