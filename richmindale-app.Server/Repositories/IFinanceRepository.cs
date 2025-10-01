using richmindale_app.Server.Models.ViewModels;

namespace richmindale_app.Server.Repositories
{
    public interface IFinanceRepository
    {
        Task<IEnumerable<PaypalPaymentsViewModels>> LoadPaypalPaymentTransactions();
    }
}