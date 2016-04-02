using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class Supplier
    {
        [JsonProperty("supplierId")]
        public long SupplierId { get; set; }

        [JsonProperty("defaultExpenseType")]
        public string DefaultExpenseType { get; set; }

        [JsonProperty("resourceUrl")]
        public string ResourceUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("contactName")]
        public string ContactName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }
    }
}