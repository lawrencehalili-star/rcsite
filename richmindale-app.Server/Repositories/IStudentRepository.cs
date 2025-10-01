using richmindale_app.Server.Models.StoredProcedures;
using richmindale_app.Server.Models.ViewModels;

namespace richmindale_app.Server.Repositories
{
    public interface IStudentRepository
    {
        Task<ReportCardsViewModel> LoadReportCardDetails(Guid StudentId);
        Task<IEnumerable<PaypalPaymentsViewModels>> LoadStudentPaypalPayments(Guid id);
    }
}