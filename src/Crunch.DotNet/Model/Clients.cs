using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class Clients
    {
        public Clients()
        {
            List = new List<Client>();
        }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("firstResult")]
        public int FirstResult { get; set; }

        [JsonProperty("client")]
        public List<Client> List { get; set; }
    }
}