using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class ApiQueryList
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("firstResult")]
        public int FirstResult { get; set; }

        [JsonProperty("resultsPerPage")]
        public int ResultsPerPage { get; set; }
    }
}