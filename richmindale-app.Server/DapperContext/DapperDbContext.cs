using Microsoft.Data.SqlClient;
using System.Data;

namespace richmindale_app.Server.DapperContext
{
    public class DapperDbContext
    {   
        private readonly IConfiguration config;
        private readonly string conn;
        public DapperDbContext(IConfiguration _config)
        {
            config = _config;
            conn = config.GetConnectionString("RichmindaleConnection")!;
        }
        public IDbConnection CreateConnection() => new SqlConnection(conn);

    }
}
