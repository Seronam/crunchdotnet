namespace Crunch.DotNet.Authorization
{
    public class CrunchRestUrlProvider : IRestUrlProvider
    {
        private readonly CrunchEnvironment _target;

        public CrunchRestUrlProvider(CrunchEnvironment target = CrunchEnvironment.Demo)
        {
            _target = target;
        }

        public string Realm => $"https://{_target.ToString().ToLowerInvariant()}.crunch.co.uk";

        public string Rest => $"https://{(_target == CrunchEnvironment.Live ? "api" : "sandbox.api")}.crunch.co.uk/rest/v2/";

        public string RequestToken => string.Concat(Realm, "/crunch-core/oauth/request_token");

        public string AccessToken => string.Concat(Realm, "/crunch-core/oauth/access_token");

        public string GetAuthLogin(string requestToken)
        {
            return string.Concat(Realm, "/crunch-core/login/oauth-login.seam?oauth_token=", requestToken);
        }
    }
}