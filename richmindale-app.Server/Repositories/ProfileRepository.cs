using Dapper;
using richmindale_app.Server.DapperContext;
using System.Data;
using richmindale_app.Server.Models.ViewModels;


namespace richmindale_app.Server.Repositories
{
    public class ProfileRepository : IProfileRepository
    {

        private readonly DapperDbContext db;
        public ProfileRepository(DapperDbContext _db)
        {
            db = _db;
        }

        public async Task<StudentInfoViewModel> GetStudentProfile(Guid id)
        {
            var sql  = $@"EXEC sp_LoadUserInfo @UserId";
            var param = new DynamicParameters();
            param.Add("UserId", id, DbType.Guid);
            using var conn = db.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<StudentInfoViewModel>(sql, param); 
        }

        public async Task<int> UpdatePassword(Guid id, string pass)
        {
            var sql = $@"UPDATE Users SET Password=@Password WHERE Id = @UserId";
            var param = new DynamicParameters();
            param.Add("Id", id, DbType.Guid);
            param.Add("Password", pass, DbType.String);
            using var conn = db.CreateConnection();
            return await conn.ExecuteScalarAsync<int>(sql, param);
        }




    }
}
