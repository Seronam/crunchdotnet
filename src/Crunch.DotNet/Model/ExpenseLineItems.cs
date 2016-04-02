using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class ExpenseLineItems
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("lineItemGrossTotal")]
        public decimal LineItemGrossTotal { get; set; }

        [JsonProperty("expenseLineItem")]
        public IList<ExpenseLineItem> ExpenseLineItem { get; set; }
    }
}