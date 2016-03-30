using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class ExpenseGroup
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("expenseTypes")]
        public IList<ExpenseType> ExpenseTypes { get; set; }
    }
}