using System;
using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class SalesInvoiceDetails
    {
        [JsonProperty("client")]
        public Client Client { get; set; }

        [JsonProperty("clientReference")]
        public string ClientReference { get; set; }

        [JsonProperty("lastModifiedDate")]
        public DateTime LastModifiedDate { get; set; }

        [JsonProperty("issuedDate")]
        public DateTime IssuedDate { get; set; }

        [JsonProperty("issueDateType")]
        public string IssueDateType { get; set; }

        [JsonProperty("dueDate")]
        public DateTime DueDate { get; set; }

        [JsonProperty("settledDate")]
        public DateTime SettledDate { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("invoiceNumber")]
        public string InvoiceNumber { get; set; }

        [JsonProperty("paymentTermsDays")]
        public int PaymentTermsDays { get; set; }

        [JsonProperty("initialPaymentReminderDays")]
        public int InitialPaymentReminderDays { get; set; }

        [JsonProperty("repetitivePaymentReminderDays")]
        public int RepetitivePaymentReminderDays { get; set; }

        [JsonProperty("emailReminderToCustomer")]
        public bool EmailReminderToCustomer { get; set; }

        [JsonProperty("purchaseOrder")]
        public string PurchaseOrder { get; set; }

        [JsonProperty("euMemberStateCountryCode")]
        public string EuMemberStateCountryCode { get; set; }

        [JsonProperty("bankAccount")]
        public Account BankAccount { get; set; }

        [JsonProperty("paymentProcessingAccount")]
        public Account PaymentProcessingAccount { get; set; }
    }
}