using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet
{
    public class Client
    {
        public Client()
        {
            Contacts = new Contacts();
        }

        [JsonProperty("clientId")]
        public long ClientId { get; set; }

        [JsonProperty("resourceUrl")]
        public string ResourceUrl { get; set; }

        [JsonProperty("defaultCurrency")]
        public string DefaultCurrency { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("companyRegistrationNumber")]
        public string CompanyRegistrationNumber { get; set; }

        [JsonProperty("vatRegistrationNumber")]
        public string VatRegistrationNumber { get; set; }

        [JsonProperty("paymentTermsDays")]
        public int PaymentTermsDays { get; set; }

        [JsonProperty("contacts")]
        public Contacts Contacts { get; set; }

        [JsonProperty("billingAddress")]
        public Address BillingAddress { get; set; }

        [JsonProperty("shipToAddress")]
        public Address ShipToAddress { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }
    }
}