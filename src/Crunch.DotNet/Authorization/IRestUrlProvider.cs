namespace Crunch.DotNet.Authorization
{
    public interface IRestUrlProvider
    {
        string Realm { get; }

        string Rest { get; }

        string RequestToken { get; }

        string AccessToken { get; }

        string GetAuthLogin(string requestToken);
    }
}