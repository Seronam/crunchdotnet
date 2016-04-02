using System.Collections.Generic;
using Crunch.DotNet.Authorization;
using Crunch.DotNet.Model;
using Crunch.DotNet.Utilities;

namespace Crunch.DotNet.Rest.Resources
{
    internal class ExpensesResource : IResource<Expense>
    {
        private readonly JsonRestRequest _rest;

        public ExpensesResource(IRestUrlProvider restUrlProvider, OAuthTokens tokens, IHttpWebRequestFactory webRequestFactory)
        {
            _rest = new JsonRestRequest("expenses", restUrlProvider, tokens, webRequestFactory);
        }

        public IReadOnlyList<Expense> Get()
        {
            var expenses = _rest.Get<Expenses>();
            return expenses.List;
        }

        public void AddOrUpdate(Expense item)
        {
            _rest.AddOrUpdate(item, item.ExpenseId);
        }
    }
}