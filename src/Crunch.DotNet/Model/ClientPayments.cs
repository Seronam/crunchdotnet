using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class ClientPayments
    {
        [JsonProperty("clientPayment")]
        public IList<ClientPayment> ClientPayment { get; set; } 
    }

}