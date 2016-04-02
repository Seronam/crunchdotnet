using System.Net;
using Crunch.DotNet.Authorization;
using Crunch.DotNet.Utilities;
using Newtonsoft.Json;

namespace Crunch.DotNet.Rest
{
    internal class JsonRestRequest
    {
        private readonly OAuthTokens _tokens;
        private readonly IHttpWebRequestFactory _webRequestFactory;
        private readonly string _resourceUrl;

        public JsonRestRequest(string resource, IRestUrlProvider restUrlProvider, OAuthTokens tokens, IHttpWebRequestFactory webRequestFactory)
        {
            _tokens = tokens;
            _webRequestFactory = webRequestFactory;
            _resourceUrl = restUrlProvider.Rest + resource;
        }

        public void AddOrUpdate<T>(T item, string id = null)
        {
            var existing = !string.IsNullOrWhiteSpace(id) && Get<T>(id) != null;

            string url;
            string method;

            if (existing)
            {
                url = GetResourceUrl(id);
                method = WebRequestMethods.Http.Put;
            }
            else
            {
                url = GetResourceUrl();
                method = WebRequestMethods.Http.Post;
            }

            AddOrUpdate(item, method, url);
        }

        public void AddOrUpdate<T>(T item, long id)
        {
            AddOrUpdate(item, id > 0 ? id.ToString() : null);
        }

        public T Get<T>()
        {
            var url = GetResourceUrl();

            return GetFromUrl<T>(url);
        }

        public T Get<T>(long? id)
        {
            var url = GetResourceUrl(id?.ToString());

            return GetFromUrl<T>(url);
        }

        public T Get<T>(string id)
        {
            var url = GetResourceUrl(id);

            return GetFromUrl<T>(url);
        }

        private T GetFromUrl<T>(string url)
        {
            var authHeader = _tokens.GetAuthorisationHeader(url, WebRequestMethods.Http.Get);
            var request = _webRequestFactory.Create(url, WebRequestMethods.Http.Get, authHeader);

            var result = request.Call();

            return JsonConvert.DeserializeObject<T>(result);
        }

        private void AddOrUpdate<T>(T item, string method, string url)
        {
            var authHeader = _tokens.GetAuthorisationHeader(url, method);
            var request = _webRequestFactory.Create(url, method, authHeader);

            var json = JsonConvert.SerializeObject(item);

            request.PutOrPost(json);
        }

        private string GetResourceUrl(string id = null)
        {
            return !string.IsNullOrWhiteSpace(id) ? string.Join("/", _resourceUrl, id) : _resourceUrl;
        }
    }
}