using System.IO;
using System.Net;
using System.Text;

namespace Crunch.DotNet.Rest
{
    internal static class HttpWebRequestExtensions
    {
        public static string Call(this HttpWebRequest httpWebRequest)
        {
            using (var response = (HttpWebResponse)httpWebRequest.GetResponse())
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream == null)
                {
                    throw new WebException("Server returned no response.");
                }

                using (var reader = new StreamReader(responseStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static string PutOrPost(this HttpWebRequest httpWebRequest, string content, string method)
        {
            var body = Encoding.UTF8.GetBytes(content);
            httpWebRequest.ContentLength = body.Length;
            httpWebRequest.Method = method;

            using (var requestStream = httpWebRequest.GetRequestStream())
            {
                requestStream.Write(body, 0, body.Length);
            }

            using (var response = (HttpWebResponse)httpWebRequest.GetResponse())
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream == null)
                {
                    throw new WebException("Server returned no response.");
                }

                using (var reader = new StreamReader(responseStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}