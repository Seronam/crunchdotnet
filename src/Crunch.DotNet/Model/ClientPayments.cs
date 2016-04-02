using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class ClientPayments
    {
        [JsonProperty("clientPayment")]
        public List<ClientPayment> List { get; set; } 
    }
}