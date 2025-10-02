using System.Data;
using Dapper;
using richmindale_app.Server.DapperContext;
using richmindale_app.Server.Helpers;

using richmindale_app.Server.Models.ViewModels;

namespace richmindale_app.Server.Repositories
{
    public class AuthenticationRepository : IAuthentication
    {
        private readonly DapperDbContext db;
        private readonly IEmailSender emailSender;

        // public AuthenticationRepository(DapperDbContext _db)
        public AuthenticationRepository(DapperDbContext _db, IEmailSender _emailSender)
        {
            db = _db;
            emailSender = _emailSender;
        }

        public async Task<UserInfoViewModel> AuthenticateAdmin(string? username, string? password)
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
                id = await conn.ExecuteScalarAsync<Guid>(sql, par);
            }

            sql = $@"exec sp_LoadUserInfo @UserId";
            var param = new DynamicParameters();
            param.Add("UserId", id, DbType.Guid);
            return await conn.QueryFirstOrDefaultAsync<UserInfoViewModel>(sql, param);
            
        }
        public async Task<string> AuthenticateStudent(string? username)
        {

            var sql = $@"SELECT Email from Users WHERE Username=@Username";
            using var conn = db.CreateConnection();
            var param = new DynamicParameters();
            param.Add("Username", username, DbType.String);
            var email = await conn.QueryFirstOrDefaultAsync<string>(sql, param);

            //check if email is null or empty
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("Student not found with the provided student number.");
            }

            var passkey = CodeGenerator.Passkey(8);
            var subject = "Richmindale - Login Code";
            var body = "Dear Student, <br/><br/>" +
                       "Your passkey for login is: " + passkey;

            // EmailSender mail = new EmailSender();
            // mail.SendMail(email, subject, body);
            emailSender.SendMail(email, subject, body);

            sql = $@"INSERT INTO SysPasskey (Id, Email, StudentNumber, Passkey, GeneratedDate) VALUES (@Id, @Email, @StudentNumber, @Passkey, @generatedDate)";
            var iParam = new DynamicParameters();
            iParam.Add("Id", Guid.NewGuid(), DbType.Guid);
            iParam.Add("Email", email, DbType.String);
            iParam.Add("StudentNumber", username, DbType.String);
            iParam.Add("Passkey", passkey, DbType.String);
            iParam.Add("GeneratedDate", DateTime.Now, DbType.DateTime);
            await conn.ExecuteAsync(sql, iParam);
            return passkey;
        }
        public async Task<UserInfoViewModel> ValidatePasskey(string username, string passkey)
        {

            Guid id = Guid.Empty;
            using var conn = db.CreateConnection();
            var sql = $@"SELECT COUNT(Passkey) FROM SysPasskey WHERE StudentNumber=@Username AND Passkey=@Passkey";
            var param = new DynamicParameters();
            param.Add("Username", username, DbType.String);
            param.Add("Passkey", passkey, DbType.String);
            //param.Add("GeneratedDate", DateTime.Now, DbType.DateTime);
            if (conn.ExecuteScalar<int>(sql, param) > 0)
            {
                sql = $@"DELETE FROM SysPasskey WHERE StudentNumber=@StudentNumber";
                var par = new DynamicParameters();
                par.Add("StudentNumber", username, DbType.String);
                await conn.ExecuteAsync(sql, par);

                sql = $@"SELECT Id FROM Users WHERE Username=@Username";
                var uParam = new DynamicParameters();
                uParam.Add("Username", username, DbType.String);
                id = await conn.ExecuteScalarAsync<Guid>(sql, uParam);
            }
            
            sql = $@"EXEC sp_LoadUserInfo @UserId";
            var iParam = new DynamicParameters();
            iParam.Add("UserId", id, DbType.Guid);
            return await conn.QueryFirstOrDefaultAsync<UserInfoViewModel>(sql, iParam);

        }
        public async Task<UserInfoViewModel> GetUserInfo(Guid id)
        {
            var sql = $@"exec sp_LoadUserInfo @UserId";
            var param = new DynamicParameters();
            param.Add("UserId", id, DbType.Guid);
            using var conn = db.CreateConnection();
            // return await conn.ExecuteScalarAsync<UserInfoViewModel>(sql, param);
            return await conn.QueryFirstOrDefaultAsync<UserInfoViewModel>(sql, param);
        }
        public async Task<IEnumerable<UserMenuViewModel>> LoadUserMenus(Guid id)
        {
            var sql = $@"SELECT Id, MenuName, MenuUrl, IconClass FROM AccessMatrix WHERE UserId=@UserId";
            // var sql = $@"SELECT Id,  FROM AccessMatrix WHERE UserId=@UserId";
            var param = new DynamicParameters();
            param.Add("UserId", id, DbType.Guid);

            using var conn = db.CreateConnection();
            return await conn.QueryAsync<UserMenuViewModel>(sql, param);
        }
        
        
   
    }
}
