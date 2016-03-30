using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class ExpenseTypes
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("expenseGroup")]
        public IList<ExpenseGroup> ExpenseGroup { get; set; } 
    }
}