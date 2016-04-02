using Newtonsoft.Json;

namespace Crunch.DotNet.Authorization
{
    public class OAuthTokens
    {
        [JsonProperty("consumerKey")]
        public string ConsumerKey { get; set; }

        [JsonProperty("consumerSecret")]
        public string ConsumerSecret { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("tokenSecret")]
        public string TokenSecret { get; set; }
    }
}