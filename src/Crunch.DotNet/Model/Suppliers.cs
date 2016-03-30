using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class Suppliers
    {
        [JsonProperty("supplier")]
        public IList<Supplier> Supplier { get; set; }
    }
}