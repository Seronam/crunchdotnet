using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class Director
    {
        [JsonProperty("directorId")]
        public long DirectorId { get; set; }

        [JsonProperty("directorEmail")]
        public string DirectorEmail { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}