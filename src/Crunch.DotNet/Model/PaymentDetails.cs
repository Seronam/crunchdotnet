using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class PaymentDetails
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("payment")]
        public IList<Payment> Payment { get; set; } 
    }
}