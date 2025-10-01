using richmindale_app.Server.Models.ViewModels;
using richmindale_app.Server.Models.StoredProcedures;

namespace richmindale_app.Server.Repositories
{
    public interface IAdmission
    {
        Task<string> VerifyEmail(string EmailAddress);
        Task<string> ValidatePasskey(string email, string passkey);
        Task<Guid> VerifyApplication(AdmissionVerificationModel model);
        Task<AdmissionViewModel> LoadAdmissionSummaryDetails(Guid id);
        Task<int> UpdateAdmissionApplication(AdmissionViewModel model);
        Task<int> UpdateGradeLevelAdmissionApplication(AdmissionViewModel model);
        Task<int> SubmitAdmissionApplication(AdmissionViewModel model);
        Task UploadAdmissionDocuments(AdmissionDocsViewModel model);
        Task UpdateAdmissionPayment(AdmissionPaymentViewModel model);
        Task<IEnumerable<AdmissionDocsViewModel>> LoadAdmissionDocs(Guid id);
        Task<IEnumerable<AgreementCoursesViewModel>> LoadAgreementCourses(int id);

        // Updates for Grade Level Admission
        Task<IEnumerable<AdmissionStudentViewModel>> LoadAdmissionStudents(Guid id);
        Task<AdmissionStudentViewModel> GetAdmissionStudentDetails(int id);
        Task<int> SaveAdmissionStudent(AdmissionStudentViewModel model);
        Task<int> UpdateAdmissionStudent(int id);
        // Task<string> VerifyEmail(object emailAddress);
    }
}
