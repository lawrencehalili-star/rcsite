using Dapper;
using richmindale_app.Server.DapperContext;

namespace richmindale_app.Server.Repositories
{

    public class EnrollmentRepository : IEnrollmentRepository
    {

        private readonly DapperDbContext db;

        public EnrollmentRepository(DapperDbContext _db)
        {
            db = _db;
        }

        

    }

}