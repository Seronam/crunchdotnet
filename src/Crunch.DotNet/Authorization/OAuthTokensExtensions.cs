using OAuth;

namespace Crunch.DotNet.Authorization
{
    public static class OAuthTokensExtensions
    {
        public static string GetAuthorisationHeader(this OAuthTokens tokens, string url, string restMethod, string realm = null)
        {
            var oauthClient = OAuthRequest.ForProtectedResource(restMethod, tokens.ConsumerKey, tokens.ConsumerSecret, tokens.Token, tokens.TokenSecret);
            oauthClient.RequestUrl = url;
            oauthClient.Realm = realm;
            return oauthClient.GetAuthorizationHeader();
        }
    }
}