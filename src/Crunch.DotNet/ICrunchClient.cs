using Crunch.DotNet.Model;
using Crunch.DotNet.Rest;

namespace Crunch.DotNet
{
    public interface ICrunchClient
    {
        IReadOnlySingleResource<Accounts> Accounts { get; }

        IResource<Client> Clients { get; }

        IResource<ClientPayment> ClientPayments { get; }

        IReadOnlyResource<Director> Directors { get; } 

        IResource<Expense> Expenses { get; }

        IReadOnlyResource<ExpenseGroup> ExpenseTypes { get; }

        IReadOnlyResource<PaymentMethod> PaymentMethodsIn { get; }

        IReadOnlyResource<PaymentMethod> PaymentMethodsOut { get; }

        IResource<SalesInvoice> SalesInvoices { get; }

        IResource<Supplier> Suppliers { get; }
    }
}