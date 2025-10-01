using richmindale_app.Server.Models.ViewModels;
using richmindale_app.Server.Models.StoredProcedures;

namespace richmindale_app.Server.Repositories
{
    public interface IMasterListRepository
    {
        Task<IEnumerable<MasterListViewModel>> LoadPaginatedMasterlist(FilterViewModel model);

    }
}
