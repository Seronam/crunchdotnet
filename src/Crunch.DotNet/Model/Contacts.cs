using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crunch.DotNet.Model
{
    public class Contacts
    {
        public Contacts()
        {
            List = new List<Contact>();
        }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("contacts")]
        public IList<Contact> List { get; set; }
    }
}