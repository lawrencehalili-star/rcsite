using richmindale_app.Server.Models.ViewModels;


namespace richmindale_app.Server.Repositories
{
    public interface IPublicRepository
    {
        Task<string> VerifyEmail(string EmailAddress);
        Task<string> ValidatePasskey(string email, string passkey);
        Task SubmitGrievance(GrievanceViewModel model);
        Task SaveEnrollmentRequest(EnrollmentRequestViewModel model);
        Task SavePaypalPayment(PaypalPaymentsViewModels model);
    }
}