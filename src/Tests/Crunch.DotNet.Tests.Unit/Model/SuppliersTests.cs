using Crunch.DotNet.Model;

namespace Crunch.DotNet.Tests.Unit.Model
{
    public class SuppliersTests : SimpleDeserialiseTests<Suppliers>
    {
        protected override string GetSeralisedJsonName()
        {
            return "suppliers";
        }
    }
}