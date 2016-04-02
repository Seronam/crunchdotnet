using System.Linq;

namespace Crunch.DotNet.Utilities
{
    internal static class AcceptAttributeExtensions
    {
        public static string GetAcceptString(this ContentType contentType)
        {
            var type = typeof (ContentType);
            var memberInfo = type.GetMember(contentType.ToString());
            var attribute = memberInfo[0].GetCustomAttributes(typeof (AcceptAttribute), false).Cast<AcceptAttribute>().SingleOrDefault();

            return attribute == null ? "*/*" : attribute.Accept;
        }
    }
}