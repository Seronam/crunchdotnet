using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using OAuth;

namespace Crunch.DotNet.Authorization
{
    public class OAuthWorkflow : IOAuthWorkflow
    {
        private readonly string _consumerKey;
        private readonly string _secret;
        private readonly IRestUrlProvider _restUrlProvider;

        public OAuthWorkflow(string consumerKey, string secret, IRestUrlProvider restUrlProvider)
        {
            _consumerKey = consumerKey;
            _secret = secret;
            _restUrlProvider = restUrlProvider;
        }

        public OAuthAccessResponse RequestAccess()
        {
            var oAuthRequest = OAuthRequest.ForRequestToken(_consumerKey, _secret);
            oAuthRequest.RequestUrl = _restUrlProvider.RequestToken;

            var authHeader = oAuthRequest.GetAuthorizationHeader();
            var request = (HttpWebRequest)WebRequest.Create(oAuthRequest.RequestUrl);

            request.Headers.Add("Authorization", authHeader);
            request.Method = "GET";

            var result = GetResponseContent(request);
            var tokens = GetTokens(result).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var token = tokens["oauth_token"];
            var secret = tokens["oauth_token_secret"];

            var loginUrl = _restUrlProvider.GetAuthLogin(token);

            System.Diagnostics.Process.Start(loginUrl);

            return new OAuthAccessResponse(token, secret);
        }

        public string GetAccessToken(string verificationToken, OAuthAccessResponse oAuthAccessResponse)
        {
            var oauthClient = OAuthRequest.ForAccessToken(_consumerKey, _secret, oAuthAccessResponse.Token, oAuthAccessResponse.TokenSecret, verificationToken);
            oauthClient.RequestUrl = _restUrlProvider.AccessToken;

            var auth = oauthClient.GetAuthorizationHeader();
            var request = (HttpWebRequest)WebRequest.Create(oauthClient.RequestUrl);

            request.Headers.Add("Authorization", auth);
            request.Method = "GET";

            var result = GetResponseContent(request);

            var tokens = GetTokens(result).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            return tokens["oauth_token"];
        }

        public string CreateAuthenticationHeader(string url, string authToken, string authTokenSecret, string method = "GET")
        {
            var oauthClient = OAuthRequest.ForProtectedResource(method, _consumerKey, _secret, authToken, authTokenSecret);
            oauthClient.RequestUrl = url;
            oauthClient.Realm = url;
            return oauthClient.GetAuthorizationHeader();
        }

        private string GetResponseContent(HttpWebRequest request)
        {
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseStream = response.GetResponseStream();

                if (responseStream == null)
                {
                    var exception = new WebException("No response received from server.");
                    exception.Data.Add("Request", request);
                    throw exception;
                }

                using (var reader = new StreamReader(responseStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private IEnumerable<KeyValuePair<string, string>> GetTokens(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                yield break;
            }

            var namevaluepairs = content.Split(new[] {'&'}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var namevaluepair in namevaluepairs)
            {
                var name = namevaluepair.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries);

                if (name.Length == 2)
                {
                    yield return new KeyValuePair<string, string>(name[0], name[1]);
                }
            }
        }
    }
}