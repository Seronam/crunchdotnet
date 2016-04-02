using System;

namespace Crunch.DotNet.Utilities
{
    internal class AcceptAttribute : Attribute
    {
        public AcceptAttribute(string accept)
        {
            Accept = accept;
        }

        public string Accept { get; }
    }
}