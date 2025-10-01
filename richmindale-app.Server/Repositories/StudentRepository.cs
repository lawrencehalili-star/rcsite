using Dapper;
using richmindale_app.Server.DapperContext;
using System.Data;
using richmindale_app.Server.Models.ViewModels;
using richmindale_app.Server.Models.StoredProcedures;
using Microsoft.Data.SqlClient;


namespace richmindale_app.Server.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DapperDbContext db;

        public StudentRepository(DapperDbContext _db)
        {
            db = _db;
        }
      
        public async Task<ReportCardsViewModel> LoadReportCardDetails(Guid StudentId)
        {
            var sql = $@"EXEC sp_LoadReportCardHeader @StudentId";
            var param = new DynamicParameters();
            param.Add("StudentId", StudentId, DbType.Guid);

            using var conn = db.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<ReportCardsViewModel>(sql, param);
        }

        public async Task<IEnumerable<PaypalPaymentsViewModels>> LoadStudentPaypalPayments(Guid id)
        {
            var sql = $@"EXEC sp_LoadStudentPaypalPaymentTransactions @Id";
            var param = new DynamicParameters();
            param.Add("Id", id, DbType.Guid);
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<PaypalPaymentsViewModels>(sql, param);
        }

        
       
    }
}