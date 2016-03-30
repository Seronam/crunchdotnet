using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class File
    {
        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        [JsonProperty("value")]
        public byte[] Value { get; set; }
    }
}