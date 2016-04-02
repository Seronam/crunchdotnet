using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Crunch.DotNet.Utilities;
using OAuth;

namespace Crunch.DotNet.Authorization
{
    public class OAuthWorkflow : IOAuthWorkflow
    {
        private readonly string _consumerKey;
        private readonly string _secret;
        private readonly IRestUrlProvider _restUrlProvider;
        private readonly IHttpWebRequestFactory _webRequestFactory;

        public OAuthWorkflow(string consumerKey, string secret, IRestUrlProvider restUrlProvider)
            : this(consumerKey, secret, restUrlProvider, new HttpWebRequestFactory())
        {
        }

        public OAuthWorkflow(string consumerKey, string secret, IRestUrlProvider restUrlProvider, IHttpWebRequestFactory webRequestFactory)
        {
            _consumerKey = consumerKey;
            _secret = secret;
            _restUrlProvider = restUrlProvider;
            _webRequestFactory = webRequestFactory;
        }

        public OAuthTempTokens InitiateAccessRequest()
        {
            var oAuthRequest = OAuthRequest.ForRequestToken(_consumerKey, _secret);
            oAuthRequest.RequestUrl = _restUrlProvider.RequestToken;

            var authHeader = oAuthRequest.GetAuthorizationHeader();
            var request = _webRequestFactory.Create(oAuthRequest.RequestUrl, WebRequestMethods.Http.Get, authHeader);

            var result = GetResponseContent(request);
            var tokens = GetTokens(result).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var token = tokens["oauth_token"];
            var secret = tokens["oauth_token_secret"];

            var verificationUrl = _restUrlProvider.GetAuthLogin(token);

            return new OAuthTempTokens(token, secret, verificationUrl);
        }

        public OAuthTokens RequestAccess(string verificationToken, OAuthTempTokens oAuthTempTokens)
        {
            var oAuthRequest = OAuthRequest.ForAccessToken(_consumerKey, _secret, oAuthTempTokens.TemporaryToken, oAuthTempTokens.TokenSecret, verificationToken);
            oAuthRequest.RequestUrl = _restUrlProvider.AccessToken;

            var authHeader = oAuthRequest.GetAuthorizationHeader();
            var request = _webRequestFactory.Create(oAuthRequest.RequestUrl, WebRequestMethods.Http.Get, authHeader);

            var result = GetResponseContent(request);

            var tokens = GetTokens(result).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var accessToken = tokens["oauth_token"];

            return new OAuthTokens
            {
                ConsumerKey = _consumerKey,
                ConsumerSecret = _secret,
                Token = accessToken,
                TokenSecret = oAuthTempTokens.TokenSecret
            };
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