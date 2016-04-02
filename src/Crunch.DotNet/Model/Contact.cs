using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class Contact
    {
        [JsonProperty("includeInEmail")]
        public bool IncludeInEmail { get; set; }

        [JsonProperty("primaryContact")]
        public bool PrimaryContact { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }
}