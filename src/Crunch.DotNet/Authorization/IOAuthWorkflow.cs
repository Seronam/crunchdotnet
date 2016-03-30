namespace Crunch.DotNet.Authorization
{
    public interface IOAuthWorkflow
    {
        OAuthAccessResponse RequestAccess();

        string GetAccessToken(string verificationToken, OAuthAccessResponse oAuthAccessResponse);
    }
}