namespace Crunch.DotNet.Authorization
{
    public interface IOAuthWorkflow
    {
        OAuthTempTokens InitiateAccessRequest();

        OAuthTokens RequestAccess(string verificationToken, OAuthTempTokens oAuthTempTokens);
    }
}