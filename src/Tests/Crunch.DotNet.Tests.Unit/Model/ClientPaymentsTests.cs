namespace Crunch.DotNet.Tests.Unit.Model
{
    public class ClientPaymentsTests : SimpleDeserialiseTests<ClientPayments>
    {
        protected override string GetSeralisedJsonName()
        {
            return "clientpayments";
        }
    }
}