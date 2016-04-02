using System.Collections.Generic;
using Crunch.DotNet.Authorization;
using Crunch.DotNet.Model;
using Crunch.DotNet.Utilities;

namespace Crunch.DotNet.Rest.Resources
{
    internal class ExpenseTypesResource : IReadOnlyResource<ExpenseGroup>
    {
        private readonly JsonRestRequest _rest;

        public ExpenseTypesResource(IRestUrlProvider restUrlProvider, OAuthTokens tokens, IHttpWebRequestFactory webRequestFactory)
        {
            _rest = new JsonRestRequest("expense_types", restUrlProvider, tokens, webRequestFactory);
        }

        public IReadOnlyList<ExpenseGroup> Get()
        {
            var expenseTypes = _rest.Get<ExpenseTypes>();
            return expenseTypes.ExpenseGroup;
        }
    }
}