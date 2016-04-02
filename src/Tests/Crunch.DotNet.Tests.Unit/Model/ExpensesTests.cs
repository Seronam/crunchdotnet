using Crunch.DotNet.Model;

namespace Crunch.DotNet.Tests.Unit.Model
{
    public class ExpensesTests : SimpleDeserialiseTests<Expenses>
    {
        protected override string GetSeralisedJsonName()
        {
            return "expenses";
        }
    }
}