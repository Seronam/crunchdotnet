using System.Collections.Generic;
using Crunch.DotNet.Authorization;
using Crunch.DotNet.Model;
using Crunch.DotNet.Utilities;

namespace Crunch.DotNet.Rest.Resources
{
    internal class SuppliersResource : IResource<Supplier>
    {
        readonly JsonRestRequest _rest;

        public SuppliersResource(IRestUrlProvider restUrlProvider, OAuthTokens tokens, IHttpWebRequestFactory webRequestFactory)
        {
            _rest = new JsonRestRequest("suppliers", restUrlProvider, tokens, webRequestFactory);
        }

        public IReadOnlyList<Supplier> Get()
        {
            var suppliers = _rest.Get<Suppliers>();
            return suppliers.List;
        }

        public Supplier AddOrUpdate(Supplier item)
        {
            return _rest.AddOrUpdate(item, item.SupplierId);
        }
    }
}