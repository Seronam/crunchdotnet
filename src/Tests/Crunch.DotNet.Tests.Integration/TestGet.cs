using Crunch.DotNet.Authorization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Crunch.DotNet.Tests.Integration
{
    [TestFixture]
    public class TestGet
    {
        [Test]
        public void Get()
        {
            var client = GetClient();
            var accounts = client.Accounts.Get();
            
            Assert.NotNull(accounts);
            Assert.AreEqual(0, accounts.Count);

            var clients = client.Clients.Get();
            Assert.NotNull(clients);
            Assert.AreEqual(1, clients.Count);

            var clientPayments = client.ClientPayments.Get();
            Assert.NotNull(clientPayments);
            Assert.AreEqual(0, clientPayments.Count);

            var directors = client.Directors.Get();
            Assert.NotNull(directors);
            Assert.AreEqual(1, directors.Count);

            var expenseTypes = client.ExpenseTypes.Get();
            Assert.NotNull(expenseTypes);
            Assert.AreEqual(13, expenseTypes.Count);

            var expenses = client.Expenses.Get();
            Assert.NotNull(expenses);
            Assert.AreEqual(0, expenses.Count);

            var paymentMethodsIn = client.PaymentMethodsIn.Get();
            Assert.NotNull(paymentMethodsIn);
            Assert.AreEqual(5, paymentMethodsIn.Count);

            var paymentMethodsOut = client.PaymentMethodsOut.Get();
            Assert.NotNull(paymentMethodsOut);
            Assert.AreEqual(7, paymentMethodsOut.Count);

            var salesInvoices = client.SalesInvoices.Get();
            Assert.NotNull(salesInvoices);
            Assert.AreEqual(0, salesInvoices.Count);

            var suppliers = client.Suppliers.Get();
            Assert.NotNull(suppliers);
            Assert.AreEqual(0, suppliers.Count);
        }

        private CrunchClient GetClient()
        {
            var tokens = JsonConvert.DeserializeObject<OAuthTokens>(System.IO.File.ReadAllText(@".\tokens.json"));
            return new CrunchClient(tokens);
        }
    }
}
