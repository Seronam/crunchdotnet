using System.Collections.Generic;
using Crunch.DotNet.Authorization;
using Crunch.DotNet.Model;
using Crunch.DotNet.Utilities;

namespace Crunch.DotNet.Rest.Resources
{
    internal class DirectorsResource : IReadOnlyResource<Director>
    {
        private readonly JsonRestRequest _rest;

        public DirectorsResource(IRestUrlProvider restUrlProvider, OAuthTokens tokens, IHttpWebRequestFactory webRequestFactory)
        {
            _rest = new JsonRestRequest("directors", restUrlProvider, tokens, webRequestFactory);
        }

        public IReadOnlyList<Director> Get()
        {
            var directors = _rest.Get<Directors>();
            return directors.List;
        }
    }
}