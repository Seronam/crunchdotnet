using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class ExpenseLineItem
    {
        [JsonProperty("expenseType")]
        public string ExpenseType { get; set; }

        [JsonProperty("benefitingDirector")]
        public Director BenefitingDirector { get; set; }

        [JsonProperty("lineItemDescription")]
        public string LineItemDescription { get; set; }

        [JsonProperty("lineItemAmount")]
        public Amount LineItemAmount { get; set; }
    }
}