using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class Accounts
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("bankAccounts")]
        public IList<Account> BankAccount { get; set; }

        [JsonProperty("creditCards")]
        public IList<Account> CreditCard { get; set; }

        [JsonProperty("paymentProcessingAccounts")]
        public IList<Account> PaymentProcessingAccount { get; set; }
    }
}

