using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class Suppliers
    {
        [JsonProperty("supplier")]
        public List<Supplier> List { get; set; }
    }
}