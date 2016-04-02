using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    internal class ExpenseTypes
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("expenseGroup")]
        public List<ExpenseGroup> ExpenseGroup { get; set; } 
    }
}