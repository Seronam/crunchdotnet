using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class PaymentMethods
    {
        [JsonProperty("paymentMethod")]
        public List<PaymentMethod> List { get; set; }
    }
}