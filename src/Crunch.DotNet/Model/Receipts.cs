using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class Receipts
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("receipt")]
        public IList<File> Receipt { get; set; } 
    }
}