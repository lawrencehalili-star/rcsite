using richmindale_app.Server.Models.ViewModels;
using richmindale_app.Server.Models.StoredProcedures;

namespace richmindale_app.Server.Repositories
{
    public interface IRegistrarRepository
    {
        Task<IEnumerable<MasterListViewModel>> LoadPaginatedMasterlist(FilterViewModel model);
        Task<IEnumerable<LoadAllAdmissionsViewModel>> LoadAllAdmissionRequests(FilterViewModel model);
        Task<AdmissionViewModel> LoadAdmissionSummaryDetails(Guid id);
        Task UpdateAdmissionStatus(Guid id, int status, string? reason);
    }
}
