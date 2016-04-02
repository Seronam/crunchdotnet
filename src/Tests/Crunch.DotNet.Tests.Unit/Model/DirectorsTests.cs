using Crunch.DotNet.Model;

namespace Crunch.DotNet.Tests.Unit.Model
{
    public class DirectorsTests : SimpleDeserialiseTests<Directors>
    {
        protected override string GetSeralisedJsonName()
        {
            return "directors";
        }
    }
}