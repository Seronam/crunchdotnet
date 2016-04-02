using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class Directors
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("director")]
        public List<Director> List { get; set; } 
    }
}