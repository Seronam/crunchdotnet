using Crunch.DotNet.Authorization;
using Crunch.DotNet.Model;
using Crunch.DotNet.Rest;
using Crunch.DotNet.Rest.Resources;
using Crunch.DotNet.Utilities;

namespace Crunch.DotNet
{
    public class CrunchClient : ICrunchClient
    {
        public CrunchClient(OAuthTokens tokens, CrunchEnvironment environment = CrunchEnvironment.Demo) 
            : this(tokens, new HttpWebRequestFactory(), environment)
        {
        }

        public CrunchClient(OAuthTokens tokens, IHttpWebRequestFactory webRequestFactory, CrunchEnvironment environment = CrunchEnvironment.Demo)
        {
            var urlProvider = new CrunchRestUrlProvider(environment);
            var factory = new ResourceFactory(urlProvider, tokens, webRequestFactory);

            Accounts = factory.Create<AccountsResource>();
            Clients = factory.Create<ClientsResource>();
            ClientPayments = factory.Create<ClientPaymentsResource>();
            Directors = factory.Create<DirectorsResource>();
            Expenses = factory.Create<ExpensesResource>();
            ExpenseTypes = factory.Create<ExpenseTypesResource>();
            PaymentMethodsIn = factory.Create<PaymentMethodsInResource>();
            PaymentMethodsOut = factory.Create<PaymentMethodsOutResource>();
            SalesInvoices = factory.Create<SalesInvoicesResource>();
            Suppliers = factory.Create<SuppliersResource>();
        }

        public IReadOnlySingleResource<Accounts> Accounts { get; }
        public IResource<Client> Clients { get; }
        public IResource<ClientPayment> ClientPayments { get; }
        public IReadOnlyResource<Director> Directors { get; }
        public IResource<Expense> Expenses { get; }
        public IReadOnlyResource<ExpenseGroup> ExpenseTypes { get; }
        public IReadOnlyResource<PaymentMethod> PaymentMethodsIn { get; }
        public IReadOnlyResource<PaymentMethod> PaymentMethodsOut { get; }
        public IResource<SalesInvoice> SalesInvoices { get; }
        public IResource<Supplier> Suppliers { get; }
    }
}