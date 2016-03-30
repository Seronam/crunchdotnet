namespace Crunch.DotNet.Tests.Unit.Model
{
    public class PaymentMethodsTests : SimpleDeserialiseTests<PaymentMethods>
    {
        protected override string GetSeralisedJsonName()
        {
            return "paymentmethods";
        }
    }
}