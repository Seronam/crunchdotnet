using System.Collections.Generic;
using Crunch.DotNet.Authorization;
using Crunch.DotNet.Model;
using Crunch.DotNet.Utilities;

namespace Crunch.DotNet.Rest.Resources
{
    internal class SalesInvoicesResource : IResource<SalesInvoice>
    {
        private readonly JsonRestRequest _rest;

        public SalesInvoicesResource(IRestUrlProvider restUrlProvider, OAuthTokens tokens, IHttpWebRequestFactory webRequestFactory)
        {
            _rest = new JsonRestRequest("sales_invoices", restUrlProvider, tokens, webRequestFactory);
        }

        public IReadOnlyList<SalesInvoice> Get()
        {
            var invoices = _rest.Get<SalesInvoices>();
            return invoices.List;
        }

        public void AddOrUpdate(SalesInvoice item)
        {
            _rest.AddOrUpdate(item, item.SalesInvoiceId);
        }
    }
}