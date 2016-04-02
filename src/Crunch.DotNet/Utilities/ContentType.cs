namespace Crunch.DotNet.Utilities
{
    public enum ContentType
    {
        [Accept("application/json")]
        Json,
        [Accept("application/xml")]
        Xml
    }
}