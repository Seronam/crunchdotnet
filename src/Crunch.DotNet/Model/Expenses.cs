using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class Expenses
    {
        [JsonProperty("expense")]
        public List<Expense> List { get; set; }
    }
}