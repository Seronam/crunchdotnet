using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class SalesInvoiceLineItems
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("salesInvoiceLineItem")]
        public IList<SalesInvoiceLineItem>  SalesInvoiceLineItem { get; set; }
    }
}