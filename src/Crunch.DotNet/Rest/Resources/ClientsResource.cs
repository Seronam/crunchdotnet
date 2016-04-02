using System.Collections.Generic;
using Crunch.DotNet.Authorization;
using Crunch.DotNet.Model;
using Crunch.DotNet.Utilities;

namespace Crunch.DotNet.Rest.Resources
{
    internal class ClientsResource : IResource<Client>
    {
        private readonly JsonRestRequest _rest;

        public ClientsResource(IRestUrlProvider restUrlProvider, OAuthTokens tokens, IHttpWebRequestFactory webRequestFactory)
        {
            _rest = new JsonRestRequest("clients", restUrlProvider, tokens, webRequestFactory);
        }

        public IReadOnlyList<Client> Get()
        {
            var clients = _rest.Get<Clients>();
            return clients.List;
        }

        public void AddOrUpdate(Client item)
        {
            _rest.AddOrUpdate(item, item.ClientId);
        }
    }
}