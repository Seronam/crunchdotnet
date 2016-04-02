using Crunch.DotNet.Model;

namespace Crunch.DotNet.Tests.Unit.Model
{
    public class SalesInvoicesTests : SimpleDeserialiseTests<SalesInvoices>
    {
        protected override string GetSeralisedJsonName()
        {
            return "salesinvoices";
        }
    }
}