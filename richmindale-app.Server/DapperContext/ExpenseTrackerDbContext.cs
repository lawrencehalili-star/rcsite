using Microsoft.Data.SqlClient;
using System.Data;

namespace richmindale_app.Server.DapperContext
{
    public class ExpenseTrackerDbContext
    {
        private readonly IConfiguration config;
        private readonly string conn;

        public ExpenseTrackerDbContext(IConfiguration _config)
        {
            config = _config;
            conn = config.GetConnectionString("ExpenseTrackerConnection")!;
        }

        public IDbConnection CreateConnection() => new SqlConnection(conn);
    }
}