using Crunch.DotNet.Model;

namespace Crunch.DotNet.Tests.Unit.Model
{
    public class ClientsTests : SimpleDeserialiseTests<Clients>
    {
        protected override string GetSeralisedJsonName()
        {
            return "clients";
        }
    }
}