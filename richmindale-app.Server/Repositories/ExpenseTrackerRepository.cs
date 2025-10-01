using System.Data;
using Dapper;
using richmindale_app.Server.DapperContext;
using richmindale_app.Server.Models.ViewModels;
using richmindale_app.Server.Models.ViewModels.ExpenseTracker;
using richmindale_app.Server.Helpers;
using richmindale_app.Server.Model.ViewModels.ExpenseTracker;

namespace richmindale_app.Server.Repositories
{

    public class ExpenseTrackerRepository : IExpenseTrackerRepository
    {

        private readonly ExpenseTrackerDbContext db;

        public ExpenseTrackerRepository(ExpenseTrackerDbContext _db)
        {
            db = _db;
        }

        public async Task<AuthenticationViewModel> AuthenticateUser(string? username, string? password)
        {
            Guid id = Guid.Empty;
            var count = $@"SELECT COUNT(Id) FROM Users WHERE Username=@Username AND Password=@Password";
            var par = new DynamicParameters();
            par.Add("Username", username, DbType.String);
            par.Add("Password", password, DbType.String);

            using var conn = db.CreateConnection();
            var sql = string.Empty;
            if (conn.ExecuteScalar<int>(count, par) > 0)
            {
                sql = $@"SELECT Id FROM Users WHERE Username=@Username AND Password=@Password";
                var iParam = new DynamicParameters();
                iParam.Add("Username", username, DbType.String);
                iParam.Add("Password", password, DbType.String);
                id = await conn.QueryFirstOrDefaultAsync<Guid>(sql, par);
            }

            sql = $@"exec sp_LoadUserInfo @UserId";
            var param = new DynamicParameters();
            param.Add("UserId", id, DbType.Guid);
            return await conn.QueryFirstOrDefaultAsync<AuthenticationViewModel>(sql, param);
        }
        public async Task<IEnumerable<SetupTablesViewModel>> LoadSetupTables(string? table)
        {
            var sql = "";
            switch(table)
            {
                case "locations":
                    sql = $@"SELECT Id, LocationName 'Name' from ExpenseLocations order by LocationName asc";
                    break;
                case "assets":
                    sql = $@"SELECT Id, AssetName 'Name' from Assets order by AssetName asc";
                    break;
                case "activities":
                    sql = $@"SELECT Id, ActivityName 'Name' from Activities order by ActivityName asc";
                    break;
                case "banks":
                    sql = $@"SELECT Id, BankCode 'Code', BankName 'Name' from Banks order by BankName asc";
                    break;
            }
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<SetupTablesViewModel>(sql);
        }
        public async Task<int> SaveSetupItems(string? table, int? id, string? code, string? value)
        {
            var sql = string.Empty;
            var param = new DynamicParameters();
            if(table == "banks")
            {
                sql = "EXEC sp_SaveSetupItems @Tablename, @Id, @Code, @Name";
                param.Add("TableName", table, DbType.String);
                param.Add("Id", id, DbType.Int32);
                param.Add("Code", code, DbType.String);
                param.Add("Name", value, DbType.String); 
            }
            else
            {
                sql = "EXEC sp_SaveSetupItems @Tablename, @Id, @Code, @Name";
                param.Add("TableName", table, DbType.String);
                param.Add("Id", id, DbType.Int32);
                param.Add("Code", string.Empty, DbType.String);
                param.Add("Name", value, DbType.String); 
            }
            using var conn = db.CreateConnection();
            return await conn.ExecuteScalarAsync<int>(sql, param);
        }
        public async Task DeleteSetupItems(string? table, int id)
        {
            var sql = "";
            switch(table)
            {
                case "locations":
                    sql = $@"DELETE from ExpenseLocations WHERE Id=" + id;
                    break;
                case "assets":
                    sql = $@"DELETE from Assets WHERE Id=" + id;
                    break;
                case "activities":
                    sql = $@"DELETE from Activities WHERE Id=" + id;
                    break;
                case "banks":
                    sql = $@"DELETE from Banks WHERE Id=" + id;
                    break;
                case "accounts":
                    sql = $@"DELETE FROM BankAccounts WHERE Id=" + id;
                    break;
            }
            using var conn = db.CreateConnection();
            await conn.ExecuteAsync(sql);
        }
        public async Task<IEnumerable<CommonDropdownModel>> GetLocations()
        {
            var sql = $@"SELECT Id 'value', LocationName 'text' from ExpenseLocations ORDER BY LocationName asc";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql);
        }
        public async Task<int> AddLocation(string? LocationName)
        {
            try
            {
                var sql = $@"INSERT INTO ExpenseLocations (LocationName, IsActive) VALUES ('" + LocationName + "',1) " +
                            "SELECT IDENT_CURRENT('ExpenseLocations')";
                using var conn = db.CreateConnection();
                return await conn.ExecuteScalarAsync<int>(sql);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<IEnumerable<CommonDropdownModel>> GetActivities()
        {
            var sql = $@"SELECT Id 'value', ActivityName 'text' from Activities ORDER BY ActivityName asc";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql);
        }
        public async Task<int> AddActivity(string? ActivityName)
        {
            try
            {
                var sql = $@"INSERT INTO Activities (ActivityName, IsActive) VALUES ('" + ActivityName + "',1) " +
                            "SELECT IDENT_CURRENT('Activities')";
                using var conn = db.CreateConnection();
                return await conn.ExecuteScalarAsync<int>(sql);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<IEnumerable<CommonDropdownModel>> GetAssets()
        {
            var sql = $@"SELECT Id 'value', AssetName 'text' FROM Assets ORDER BY AssetName asc";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql);
        }
        public async Task<int> AddAsset(string? AssetName)
        {
            var sql = $@"INSERT INTO Assets (AssetName, IsActive) VALUES ('" + AssetName + "',1) " +
                         "SELECT IDENT_CURRENT('Assets')";
            using var conn = db.CreateConnection();
            return await conn.ExecuteScalarAsync<int>(sql);
        }
        public async Task<IEnumerable<CommonDropdownModel>> GetBanks()
        {
            try
            {
              var sql = $@"SELECT Id 'value', BankCode + ' ' + BankName 'text' from Banks ORDER BY BankName asc";
                using var conn = db.CreateConnection();
                return await conn.QueryAsync<CommonDropdownModel>(sql);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<int> AddBank(string? BankCode, string? BankName)
        {
            try
            {
                var sql = $@"INSERT INTO Banks (BankCode, BankName, IsActive) VALUES ('"+ BankCode + "','" + BankName + "',1) " +
                            "SELECT IDENT_CURRENT('Banks')";
                using var conn = db.CreateConnection();
                return await conn.ExecuteScalarAsync<int>(sql);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<IEnumerable<CommonDropdownModel>> GetBankAccounts()
        {
            var sql = $@"SELECT a.Id 'value', b.BankCode + ' - ' + a.AccountNumber 'text'
                         FROM BankAccounts a 
                         INNER JOIN Banks b
                         ON a.BankId = b.Id 
                         ORDER BY b.BankCode ASC";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql);
        }

        public async Task<BankAccountViewModel> GetBankAccountDetails(int id)
        {
            var sql = $@"SELECT isnull(Id,0) 'Id', isnull(AccountNumber,'') 'AccountNumber', isnull(AccountName,'') 'AccountName', isnull(BankId,0) 'BankId', isnull(Branch,'') 'Branch' from BankAccounts WHERE Id=" + id;
            using var conn = db.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<BankAccountViewModel>(sql);
        }
        public async Task<int> AddBankAccount(BankAccountViewModel model)
        {
            try
            {
                var sql = $@"EXEC sp_SaveBankAccounts @Id, @AccountNumber, @AccountName, @BankId, @Branch";
                var param = new DynamicParameters();
                param.Add("Id", model.Id, DbType.Int32);
                param.Add("AccountNumber", model.AccountNumber, DbType.String);
                param.Add("AccountName", model.AccountName, DbType.String);
                param.Add("BankId", model.BankId, DbType.Int32);
                param.Add("Branch", model.Branch, DbType.String);

                using var conn = db.CreateConnection();
                return await conn.ExecuteScalarAsync<int>(sql, param);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
        public async Task<IEnumerable<BankAccountViewModel>> LoadPaginatedBankAccounts(FilterViewModel model)
        {
            var sql = $@"EXEC sp_LoadPaginatedBankAccountCards @Search, @SortName, @SortDirection, @StartIndex, @PageSize";
            var param = new DynamicParameters();
            param.Add("Search", model.Search, DbType.String);
            param.Add("SortName", model.SortName, DbType.String);
            param.Add("SortDirection", model.SortDirection, DbType.String);
            param.Add("StartIndex", model.StartIndex, DbType.Int32);
            param.Add("PageSize", model.PageSize, DbType.Int32);
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<BankAccountViewModel>(sql, param);
        }
        public async Task<IEnumerable<BankAccountViewModel>> LoadBankAccounts()
        {
            var sql = $@"SELECT a.Id, a.AccountNumber, a.AccountName, a.BankId, b.BankCode, b.BankName, a.Branch 
                         FROM BankAccounts a 
                         LEFT JOIN Banks b
                         ON a.BankId = b.Id
                         ORDER BY a.Id ASC ";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<BankAccountViewModel>(sql);
        }
        public async Task<BankAccountViewModel> GetBankAccountDetails(int? id)
        {
            var sql = $@"SELECT Id, AccountNumber, AccountName, BankId, Branch FROM BankAccounts WHERE Id=" + id;
            using var conn = db.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<BankAccountViewModel>(sql);
        }
        public async Task DeleteBankAccount(int id)
        {
            try
            {
                var sql = $@"UPDATE BankAccounts SET IsActive = 0 WHERE Id=" + id;
                using var conn = db.CreateConnection();
                await conn.ExecuteAsync(sql);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<IEnumerable<CommonDropdownModel>> GetCurrencies()
        {
            var sql = $@"SELECT Id 'value', Currency 'text', Emoji 'code' from Currencies ORDER BY Currency asc";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql);
        }
        public async Task<IEnumerable<ExpenseMasterViewModel>> LoadExpenseMasterData(Guid id)
        {
            var sql = $@"EXEC sp_LoadExpenseMasterRecord @UserId";
            var param = new DynamicParameters();
            param.Add("UserId", id, DbType.Guid);
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<ExpenseMasterViewModel>(sql, param);
        }
        public async Task<IEnumerable<ExpenseMasterViewModel>> LoadPaginatedExpense(ExpenseFilterViewModel model)
        {
            var sql  = $@"EXEC sp_LoadPaginatedCardMaster @UserId, @Search, @SortName, @SortDirection, @StartIndex, @PageSize";
            var param = new DynamicParameters();
            param.Add("UserId", model.UserId, DbType.Guid);
            param.Add("Search", model.Search, DbType.String);
            param.Add("SortName", model.SortName, DbType.String);
            param.Add("SortDirection", model.SortDirection, DbType.String);
            param.Add("StartIndex", model.StartIndex, DbType.Int32);
            param.Add("PageSize", model.PageSize, DbType.Int32);

            using var conn = db.CreateConnection();
            return await conn.QueryAsync<ExpenseMasterViewModel>(sql, param);
        }
        public async Task<ExpenseViewModel> GetExpenseDetails(Guid id)
        {
            var sql = $@"EXEC sp_LoadExpenseDetails @Id";
            var param = new DynamicParameters();
            param.Add("Id", id, DbType.Guid);
            using var conn = db.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<ExpenseViewModel>(sql,param);
        }
        public async Task<Guid> SaveExpenseTransaction(ExpenseViewModel model)
        {
            try
            {
                var sql = $@"EXEC sp_SaveExpenseTransaction 
                                  @Id, @ExpenseDate, @ActivityId, @LocationId, @AssetId, @CreditAmount, @DebitAmount,
                                  @CurrencyId, @BankAccountId, @Comments, @UserId ";
                var param = new DynamicParameters();
                param.Add("Id", model.Id, DbType.Guid);
                param.Add("ExpenseDate", model.ExpenseDate, DbType.DateTime);
                param.Add("ActivityId", model.ActivityId, DbType.Int32);
                param.Add("LocationId", model.LocationId, DbType.Int32);
                param.Add("AssetId", model.AssetId, DbType.Int32);
                param.Add("CreditAmount", model.CreditAmount, DbType.Decimal);
                param.Add("DebitAmount", model.DebitAmount, DbType.Decimal);
                param.Add("CurrencyId", model.CurrencyId, DbType.Int32);
                param.Add("BankAccountId", model.BankAccountId, DbType.Int32);
                param.Add("Comments", model.Comments, DbType.String);
                param.Add("UserId", model.UserId, DbType.Guid);
                   
                using var conn = db.CreateConnection();
                return await conn.ExecuteScalarAsync<Guid>(sql, param);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task DeleteExpenseTransaction(Guid id)
        {
            try
            {
                var sql = $@"UPDATE ExpenseTransactions SET IsValid = 0 WHERE Id='" + id + "'";
                using var conn = db.CreateConnection();
                await conn.ExecuteAsync(sql);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<IEnumerable<UsersViewModel>> LoadUsers()
        {
            var sql = $@"EXEC sp_LoadUsers";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<UsersViewModel>(sql);
        }
        public async Task<IEnumerable<UsersViewModel>> LoadPaginatedUsers(FilterViewModel model)
        {
            var sql = $@"EXEC sp_LoadPaginatedUserCards @Search, @SortName, @SortDirection, @StartIndex, @PageSize";
            var param = new DynamicParameters();
            param.Add("Search", model.Search, DbType.String);
            param.Add("SortName", model.SortName, DbType.String);
            param.Add("SortDirection", model.SortDirection, DbType.String);
            param.Add("StartIndex", model.StartIndex, DbType.Int32);
            param.Add("PageSize", model.PageSize, DbType.Int32);
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<UsersViewModel>(sql, param);
        }
        public async Task<IEnumerable<CommonDropdownModel>> GetRoles()
        {
            var sql = $@"SELECT Id 'value', RoleName 'text' FROM Roles ORDER BY RoleName ASC";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql);
        }
        public async Task<UsersViewModel>  GetUserDetails(Guid id)
        {
            var sql = $@"SELECT Id, Username, Password, DisplayName, Firstname, Lastname, EmailAddress, MobileNumber, RoleId, IsActive FROM Users WHERE Id = @Id";
            var param = new DynamicParameters();
            param.Add("Id", id, DbType.Guid);
            using var conn = db.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<UsersViewModel>(sql, param);
        }
        public async Task<Guid> SaveUserDetails(UsersViewModel model)
        {
            try
            {
                var sql = $@"EXEC sp_SaveUserDetails @Id, @Username, @Password, @DisplayName, @Firstname, @Lastname, @EmailAddress, @MobileNumber, @RoleId";
                var param = new DynamicParameters();
                param.Add("Id", model.Id, DbType.Guid);
                param.Add("Username", model.Username, DbType.String);
                param.Add("Password", model.Password, DbType.String);
                param.Add("DisplayName", model.DisplayName, DbType.String);
                param.Add("Firstname", model.Firstname, DbType.String);
                param.Add("Lastname", model.Lastname, DbType.String);
                param.Add("EmailAddress", model.EmailAddress, DbType.String);
                param.Add("MobileNumber", model.MobileNumber, DbType.String);
                param.Add("RoleId", model.RoleId, DbType.Guid);
                using var conn = db.CreateConnection();
                return await conn.ExecuteScalarAsync<Guid>(sql, param);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task DeactivateUser(Guid id)
        {
            var sql = $@"UPDATE Users SET IsActive = 0 WHERE Id='" + id +"'";
            using var conn = db.CreateConnection();
            await conn.ExecuteAsync(sql);
        }
        public async Task SaveUserProfile(UsersViewModel model)
        {
            try
            {
                var sql = $@"EXEC sp_SaveUserProfile @Id, @DisplayName, @Firstname, @Lastname, @EmailAddress, @MobileNumber";
                var param  = new DynamicParameters();
                param.Add("Id", model.Id, DbType.Guid);
                param.Add("DisplayName", model.DisplayName, DbType.String);
                param.Add("Firstname", model.Firstname, DbType.String);
                param.Add("Lastname", model.Lastname, DbType.String);
                param.Add("EmailAddress", model.EmailAddress, DbType.String);
                param.Add("MobileNumber", model.MobileNumber, DbType.String);
                using var conn = db.CreateConnection();
                await conn.ExecuteAsync(sql);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<string> SendResetRequest(string? username, string? email)
        {
            
            try
            {
                var count = "SELECT COOUNT(Id) FROM Users WHERE Username = '" + username +"' AND EmailAddress='" + email +"'";
                using var conn = db.CreateConnection();
                if(await conn.ExecuteScalarAsync<int>(count) > 0)
                {

                    Guid id = Guid.Empty;
                    var sql = $@"SELECT Id FROM Users WHERE Username='" + username + "' AND EmailAddress='" + email + "'";
                    id = await conn.QueryFirstOrDefaultAsync<Guid>(sql);
                    EmailSender mail = new EmailSender();
                    string body = $@"Dear User,<br/><br/>
                                    You have requested to reset your password using Expense Tracker Application.<br/><br/>
                                    To reset your account password please use below link:<br/>
                                    <a href='https://tracker.richmindale.net/#/reset/" + id + ">Password Reset</a><br/><br/>" +
                                    "If you did not requested to reset your password, please ignore this message.<br/><br/>" +
                                    "Webmaster"; 
                    mail.SendMail(email, "Password Reset", body);
                    return "success";
                }
                else
                {
                    return "invalid";
                }
            }
            catch(Exception ex)
            {
                return "error";
                throw new Exception(ex.Message.ToString());
                
            }

        }
        public async Task ResetPassword(Guid id, string? password)
        {
            var sql = $@"UPDATE Users SET Password='" + password + "' WHERE Id='" + id + "'";
            using var conn = db.CreateConnection();
            await conn.ExecuteAsync(sql); 
        }
    
        public async Task<DebitDashboardViewModel> LoadMonthlyDebit(Guid id, int? month)
        {
            var sql = $@"EXEC sp_MonthlyDebitDashboard @UserId, @Month";
            var param = new DynamicParameters();
            param.Add("UserId", id, DbType.Guid);
            param.Add("Month", month, DbType.Int32);
            using var conn = db.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<DebitDashboardViewModel>(sql, param);
        }

        public async Task<CreditDashboardViewModel> LoadMonthlyCredit(Guid id, int? month)
        {
            var sql = $@"EXEC sp_MonthlyCreditDashboard @UserId, @Month";
            var param = new DynamicParameters();
            param.Add("UserId", id, DbType.Guid);
            param.Add("Month", month, DbType.Int32);
            using var conn = db.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<CreditDashboardViewModel>(sql, param);
        }

        public async Task<IEnumerable<YearlyDashboardViewModel>> LoadYearlyDashboard(Guid id, int? year)
        {
            var sql = $@"EXEC sp_LoadYearlyExpenseRecord @UserId, @Year";
            var param = new DynamicParameters();
            param.Add("UserId", id, DbType.Guid);
            param.Add("Year", year, DbType.Int32);
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<YearlyDashboardViewModel>(sql, param);
        }
    
    }

}