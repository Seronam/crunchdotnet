using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class Directors
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("director")]
        public IList<Director> Director { get; set; } 
    }
}