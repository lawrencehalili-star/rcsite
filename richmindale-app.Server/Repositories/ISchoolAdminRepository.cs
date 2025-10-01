using richmindale_app.Server.Models.ViewModels;
using richmindale_app.Server.Models.StoredProcedures;


namespace richmindale_app.Server.Repositories
{
    public interface ISchoolAdminRepository
    {
        Task<IEnumerable<LoadAllAdmissionsViewModel>> LoadAllAdmissionRequests(FilterViewModel model);
        Task<IEnumerable<LoadAllAdmissionsViewModel>> LoadCollegeAdmissionRequests(FilterViewModel model);
        Task<IEnumerable<LoadAllAdmissionsViewModel>> LoadGradeLevelAdmissionRequests(FilterViewModel model);
        Task<AdmissionViewModel> LoadAdmissionSummaryDetails(Guid id);
        Task UpdateAdmissionStatus(Guid id, int status, string? reason);
        Task<IEnumerable<AgreementCoursesViewModel>> LoadAgreementCourses(int id);
    }
}