using System;
using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class Payment
    {
        [JsonProperty("paymentDate")]
        public DateTime PaymentDate { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("paymentMethod")]
        public string PaymentMethod { get; set; }

        [JsonProperty("bankAccount")]
        public Account BankAccount { get; set; }

        [JsonProperty("creditCard")]
        public Account CreditCard { get; set; }

        [JsonProperty("director")]
        public Director Director { get; set; }

        [JsonProperty("paymentProcessingAccount")]
        public Account PaymentProcessingAccount { get; set; }
    }
}