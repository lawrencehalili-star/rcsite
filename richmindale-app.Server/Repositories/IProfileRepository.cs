using richmindale_app.Server.Models.ViewModels;

namespace richmindale_app.Server.Repositories
{
    public interface IProfileRepository
    {
        Task<StudentInfoViewModel> GetStudentProfile(Guid id);
        Task<int> UpdatePassword(Guid id, string pass);
    }
}