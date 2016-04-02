using System.Collections.Generic;
using Crunch.DotNet.Authorization;
using Crunch.DotNet.Model;
using Crunch.DotNet.Utilities;

namespace Crunch.DotNet.Rest.Resources
{
    internal class PaymentMethodsInResource : PaymentMethodsResource
    {
        public PaymentMethodsInResource(IRestUrlProvider restUrlProvider, OAuthTokens tokens, IHttpWebRequestFactory webRequestFactory) 
            : base(restUrlProvider, tokens, webRequestFactory, Direction.In)
        {
        }
    }

    internal class PaymentMethodsOutResource : PaymentMethodsResource
    {
        public PaymentMethodsOutResource(IRestUrlProvider restUrlProvider, OAuthTokens tokens, IHttpWebRequestFactory webRequestFactory)
            : base(restUrlProvider, tokens, webRequestFactory, Direction.Out)
        {
        }
    }

    internal abstract class PaymentMethodsResource : IReadOnlyResource<PaymentMethod>
    {
        public enum Direction
        {
            In,
            Out
        }

        private readonly JsonRestRequest _rest;

        protected PaymentMethodsResource(IRestUrlProvider restUrlProvider, OAuthTokens tokens, IHttpWebRequestFactory webRequestFactory, Direction direction)
        {
            var resource = string.Join("/", "payment_methods", direction.ToString().ToLowerInvariant());

            _rest = new JsonRestRequest(resource, restUrlProvider, tokens, webRequestFactory);
        }

        public IReadOnlyList<PaymentMethod> Get()
        {
            var paymentMethods = _rest.Get<PaymentMethods>();
            return paymentMethods.List;
        }
    }
}