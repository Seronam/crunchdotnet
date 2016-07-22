using OAuth;

namespace Crunch.DotNet.Authorization
{
    public static class OAuthTokensExtensions
    {
        public static string GetAuthorisationHeader(this OAuthTokens tokens, string url, string restMethod, string realm = null)
        {            
            OAuthRequest oauthClient = new OAuthRequest
            {
                Method = restMethod,
                Type = OAuthRequestType.ProtectedResource,
                SignatureMethod = OAuthSignatureMethod.HmacSha1,
                ConsumerKey = tokens.ConsumerKey,
                ConsumerSecret = tokens.ConsumerSecret,
                Token = tokens.Token,
                TokenSecret = tokens.TokenSecret,
                RequestUrl = url,
                Realm = realm
            };

            return oauthClient.GetAuthorizationHeader();
        }
    }
}