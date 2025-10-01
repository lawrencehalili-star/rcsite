using richmindale_app.Server.Models.ViewModels;

namespace richmindale_app.Server.Repositories
{
    public interface IServicesRepository
    {
        Task<IEnumerable<DocumentRequestViewModel>> LoadStudentDocumentRequest(Guid id);
        Task SaveDocumentRequest(DocumentRequestViewModel model);
    }
}