using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class Expenses
    {
        [JsonProperty("expense")]
        public IList<Expense> Expense { get; set; }
    }
}