using System.Net;

namespace Crunch.DotNet.Utilities
{
    public interface IHttpWebRequestFactory
    {
        HttpWebRequest Create(string url, string method, string authorizationHeader = null, ContentType contentType = ContentType.Json);
    }
}