using System;
using Crunch.DotNet.Authorization;
using Crunch.DotNet.Utilities;

namespace Crunch.DotNet.Rest.Resources
{
    internal class ResourceFactory : IResourceFactory
    {
        private readonly IRestUrlProvider _restUrlProvider;
        private readonly OAuthTokens _tokens;
        private readonly IHttpWebRequestFactory _webRequestFactory;

        public ResourceFactory(IRestUrlProvider restUrlProvider, 
            OAuthTokens tokens,
            IHttpWebRequestFactory webRequestFactory)
        {
            _restUrlProvider = restUrlProvider;
            _tokens = tokens;
            _webRequestFactory = webRequestFactory;
        }

        public T Create<T>()
        {
            return (T) Activator.CreateInstance(typeof (T), _restUrlProvider, _tokens, _webRequestFactory);
        }
    }
}