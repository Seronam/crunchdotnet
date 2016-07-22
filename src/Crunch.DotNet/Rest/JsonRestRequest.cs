using System.Net;
using Crunch.DotNet.Authorization;
using Crunch.DotNet.Utilities;
using Newtonsoft.Json;
using System.Text;
using System;

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

        public T AddOrUpdate<T>(T item, string id = null) where T : class
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

            return AddOrUpdate(item, method, url);
        }

        public T AddOrUpdate<T>(T item, long id) where T : class
        {
            return AddOrUpdate(item, id > 0 ? id.ToString() : null);
        }

        public T Get<T>() where T : class
        {
            var url = GetResourceUrl();

            return GetFromUrl<T>(url);
        }

        public T Get<T>(long? id) where T : class
        {
            var url = GetResourceUrl(id?.ToString());

            return GetFromUrl<T>(url);
        }

        public T Get<T>(string id) where T : class
        {
            var url = GetResourceUrl(id);

            return GetFromUrl<T>(url);
        }

        private T GetFromUrl<T>(string url) where T : class
        {
            var authHeader = _tokens.GetAuthorisationHeader(url, WebRequestMethods.Http.Get);
            var request = _webRequestFactory.Create(url, WebRequestMethods.Http.Get, authHeader);

            string result = "";
            try
            {
                result = request.Call();
            }
            catch(WebException we)
            {
                HttpWebResponse errorResponse = we.Response as HttpWebResponse;
                if (errorResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                throw;
            }

            return JsonConvert.DeserializeObject<T>(result);
        }

        private T AddOrUpdate<T>(T item, string method, string url) where T : class
        {
            var authHeader = _tokens.GetAuthorisationHeader(url, method);
            var request = _webRequestFactory.Create(url, method, authHeader);

            var json = JsonConvert.SerializeObject(item);

            try
            {
                var result = request.PutOrPost(json, method);

                return JsonConvert.DeserializeObject<T>(result);
            }
            catch (WebException we)
            {
                using (var reader = new System.IO.StreamReader(we.Response.GetResponseStream(), Encoding.UTF8))
                {
                    var responseText = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(responseText))
                    {
                        //Give the user the response body if we have it, the Crunch API often returns useful diagnostic information
                        throw new Exception(responseText, we);
                    }
                }

                throw;
            }
        }

        private string GetResourceUrl(string id = null)
        {
            return !string.IsNullOrWhiteSpace(id) ? string.Join("/", _resourceUrl, id) : _resourceUrl;
        }
    }
}