using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class ExpenseType
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}