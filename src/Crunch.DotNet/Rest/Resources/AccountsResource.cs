using Crunch.DotNet.Authorization;
using Crunch.DotNet.Model;
using Crunch.DotNet.Utilities;

namespace Crunch.DotNet.Rest.Resources
{
    internal class AccountsResource : IReadOnlySingleResource<Accounts>
    {
        private readonly JsonRestRequest _rest;

        public AccountsResource(IRestUrlProvider restUrlProvider, OAuthTokens tokens, IHttpWebRequestFactory webRequestFactory)
        {
            _rest = new JsonRestRequest("accounts", restUrlProvider, tokens, webRequestFactory);
        }

        public Accounts Get()
        {
            return _rest.Get<Accounts>();
        }
    }
}