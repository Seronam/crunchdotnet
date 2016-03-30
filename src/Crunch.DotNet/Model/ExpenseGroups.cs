using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class ExpenseGroups
    {
        public ExpenseGroups()
        {
            List = new List<ExpenseGroup>();
        }

        [JsonProperty("expenseGroup")]
        public IList<ExpenseGroup> List { get; set; }
    }
}