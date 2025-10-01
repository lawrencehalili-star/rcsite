using Dapper;
using System.Data;
using richmindale_app.Server.DapperContext;
using richmindale_app.Server.Models.ViewModels;

namespace richmindale_app.Server.Repositories
{
    public class FinanceRepository : IFinanceRepository
    {
        private readonly DapperDbContext db;

        public FinanceRepository(DapperDbContext _db)
        {
            db = _db;
        }

        public async Task<IEnumerable<PaypalPaymentsViewModels>> LoadPaypalPaymentTransactions()
        {
            var sql = $@"EXEC sp_LoadPaypalPaymentTransactions";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<PaypalPaymentsViewModels>(sql);
        }

        
    }
}