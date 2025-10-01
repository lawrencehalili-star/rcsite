
using richmindale_app.Server.Models.ViewModels;

namespace richmindale_app.Server.Repositories
{
    public interface IAuthentication
    {
        Task<UserInfoViewModel> AuthenticateAdmin(string? username, string? password);
        Task<string> AuthenticateStudent(string? username);
        Task<UserInfoViewModel> ValidatePasskey(string username, string passkey);
        Task<UserInfoViewModel> GetUserInfo(Guid id);
        Task<IEnumerable<UserMenuViewModel>> LoadUserMenus(Guid id);



    }
}
