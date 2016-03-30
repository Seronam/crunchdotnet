namespace Crunch.DotNet.Tests.Unit.Model
{
    public class ExpenseGroupsTests : SimpleDeserialiseTests<ExpenseGroups>
    {
        protected override string GetSeralisedJsonName()
        {
            return "expensegroups";
        }
    }
}