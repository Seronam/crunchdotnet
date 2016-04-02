namespace Crunch.DotNet.Authorization
{
    public class OAuthTempTokens
    {
        public OAuthTempTokens(string temporaryToken, string tokenSecret, string verificationUrl)
        {
            TemporaryToken = temporaryToken;
            TokenSecret = tokenSecret;
            VerificationUrl = verificationUrl;
        }

        public string TemporaryToken { get; }

        public string TokenSecret { get; }

        public string VerificationUrl { get; }
    }
}