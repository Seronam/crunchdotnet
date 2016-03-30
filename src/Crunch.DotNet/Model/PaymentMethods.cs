using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class PaymentMethods
    {
        [JsonProperty("paymentMethod")]
        public IList<PaymentMethod> PaymentMethod { get; set; }
    }
}