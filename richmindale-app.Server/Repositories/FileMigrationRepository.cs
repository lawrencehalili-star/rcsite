using richmindale_app.Server.DapperContext;

namespace richmindale_app.Server.Repositories
{
    public class FileMigrationRepository : IFileMigrationRepository
    {
       
       private readonly DapperDbContext db;

       public FileMigrationRepository(DapperDbContext _db)
       {
            db = _db;
       }



    }

    
}