using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class SalesInvoices
    {
        [JsonProperty("salesInvoice")]
        public IList<SalesInvoice>  SalesInvoice { get; set; }
    }
}