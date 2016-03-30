namespace Crunch.DotNet.Authorization
{
    public class OAuthAccessResponse
    {
        public OAuthAccessResponse(string token, string tokenSecret)
        {
            Token = token;
            TokenSecret = tokenSecret;
        }

        public string Token { get; }

        public string TokenSecret { get; }
    }
}