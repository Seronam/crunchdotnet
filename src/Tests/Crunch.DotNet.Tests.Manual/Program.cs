using Crunch.DotNet.Authorization;
using Crunch.DotNet.Model;
using Newtonsoft.Json;

namespace Crunch.DotNet.Tests.Manual
{
    class Program
    {
        static void Main(string[] args)
        {
            var supplier = new Supplier
            {
                ContactName = "Joe Supplier",
                Name = "Best Suppliers"
            };

            var client = GetClient();

            client.Suppliers.AddOrUpdate(supplier);
        }

        private static CrunchClient GetClient()
        {
            var tokens = JsonConvert.DeserializeObject<OAuthTokens>(System.IO.File.ReadAllText(@".\tokens.json"));
            return new CrunchClient(tokens);
        }
    }
}
