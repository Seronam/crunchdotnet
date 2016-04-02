using System.Net;

namespace Crunch.DotNet.Utilities
{
    public class HttpWebRequestFactory : IHttpWebRequestFactory
    {
        public HttpWebRequest Create(string url, string method, string authorizationHeader = null, ContentType contentType = ContentType.Json)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = method;
            request.Accept = contentType.GetAcceptString();

            if (!string.IsNullOrWhiteSpace(authorizationHeader))
            {
                request.ContentType = "application/json";
                request.Headers.Add("Authorization", authorizationHeader);
            }

            return request;
        }
    }
}