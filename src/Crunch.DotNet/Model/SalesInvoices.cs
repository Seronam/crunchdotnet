using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class SalesInvoices
    {
        [JsonProperty("salesInvoice")]
        public List<SalesInvoice>  List { get; set; }
    }
}