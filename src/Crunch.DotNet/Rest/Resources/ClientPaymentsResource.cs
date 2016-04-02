using System.Collections.Generic;
using Crunch.DotNet.Authorization;
using Crunch.DotNet.Model;
using Crunch.DotNet.Utilities;

namespace Crunch.DotNet.Rest.Resources
{
    internal class ClientPaymentsResource : IResource<ClientPayment>
    {
        private readonly JsonRestRequest _rest;

        public ClientPaymentsResource(IRestUrlProvider restUrlProvider, OAuthTokens tokens, IHttpWebRequestFactory webRequestFactory)
        {
            _rest = new JsonRestRequest("client_payments", restUrlProvider, tokens, webRequestFactory);
        }

        public IReadOnlyList<ClientPayment> Get()
        {
            var payments = _rest.Get<ClientPayments>();
            return payments.List;
        }

        public void AddOrUpdate(ClientPayment item)
        {
            _rest.AddOrUpdate(item, item.ClientPaymentId);
        }
    }
}