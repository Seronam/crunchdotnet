using System;
using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class ExpenseDetails
    {
        [JsonProperty("supplier")]
        public Supplier Supplier { get; set; }

        [JsonProperty("supplierReference")]
        public string SupplierReference { get; set; }

        [JsonProperty("postingDate")]
        public DateTime PostingDate { get; set; }

        [JsonProperty("rechargeable")]
        public Rechargeable Rechargeable { get; set; }
    }
}