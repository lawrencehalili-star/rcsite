using richmindale_app.Server.Models.ViewModels.ExpenseTracker;
using richmindale_app.Server.Models.ViewModels;

namespace richmindale_app.Server.Repositories
{
    public interface IExpenseTrackerRepository
    {
        Task<AuthenticationViewModel> AuthenticateUser(string? username, string? password);
        Task<IEnumerable<SetupTablesViewModel>> LoadSetupTables(string? table);
        Task<int> SaveSetupItems(string? table, int? id, string? code, string? value);
        Task DeleteSetupItems(string? table, int id);
        Task<IEnumerable<CommonDropdownModel>> GetLocations();
        Task<int> AddLocation(string? LocationName);
        Task<IEnumerable<CommonDropdownModel>> GetActivities();
        Task<int> AddActivity(string? ActivityName);
        Task<IEnumerable<CommonDropdownModel>> GetAssets();
        Task<int> AddAsset(string? AssetName);
        Task<IEnumerable<CommonDropdownModel>> GetBanks();
        Task<int> AddBank(string? BankCode, string? BankName);
        Task<IEnumerable<CommonDropdownModel>> GetBankAccounts();
        Task<BankAccountViewModel> GetBankAccountDetails(int id);
        Task<int> AddBankAccount(BankAccountViewModel model);
        Task<IEnumerable<BankAccountViewModel>> LoadPaginatedBankAccounts(FilterViewModel model);
        Task<IEnumerable<BankAccountViewModel>> LoadBankAccounts();
        Task DeleteBankAccount(int id);
        Task<IEnumerable<CommonDropdownModel>> GetCurrencies();
        Task<IEnumerable<ExpenseMasterViewModel>> LoadExpenseMasterData(Guid id);
        Task<IEnumerable<ExpenseMasterViewModel>> LoadPaginatedExpense(ExpenseFilterViewModel model);
        Task<ExpenseViewModel> GetExpenseDetails(Guid id);
        Task<Guid> SaveExpenseTransaction(ExpenseViewModel model);
        Task DeleteExpenseTransaction(Guid id);
        Task<IEnumerable<UsersViewModel>> LoadUsers();
        Task<IEnumerable<UsersViewModel>> LoadPaginatedUsers(FilterViewModel model);
        Task<UsersViewModel>  GetUserDetails(Guid id);
        Task<IEnumerable<CommonDropdownModel>> GetRoles();
        Task<Guid> SaveUserDetails(UsersViewModel model);
        Task DeactivateUser(Guid id);
        Task SaveUserProfile(UsersViewModel model);
        Task<string> SendResetRequest(string? username, string? email);
        Task ResetPassword(Guid id, string? password);
        Task<DebitDashboardViewModel> LoadMonthlyDebit(Guid id, int? month);
        Task<CreditDashboardViewModel> LoadMonthlyCredit(Guid id, int? month);
        Task<IEnumerable<YearlyDashboardViewModel>> LoadYearlyDashboard(Guid id, int? year);
    }
}