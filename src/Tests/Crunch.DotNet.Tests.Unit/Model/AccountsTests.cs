using Crunch.DotNet.Model;

namespace Crunch.DotNet.Tests.Unit.Model
{
    public class AccountsTests : SimpleDeserialiseTests<Accounts>
    {
        protected override string GetSeralisedJsonName()
        {
            return "accounts";
        }
    }
}