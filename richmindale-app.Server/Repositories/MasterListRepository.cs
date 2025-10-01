using Dapper;
using System.Data;
using richmindale_app.Server.DapperContext;
using richmindale_app.Server.Models.StoredProcedures;
using richmindale_app.Server.Models.ViewModels;

namespace richmindale_app.Server.Repositories
{
    public class MasterListRepository : IMasterListRepository
    {
        private readonly DapperDbContext db;

        public MasterListRepository(DapperDbContext _db)
        {
            db = _db;
        }

        public async Task<IEnumerable<MasterListViewModel>> LoadPaginatedMasterlist(FilterViewModel model)
        {
            var sql  = $@"EXEC sp_LoadPaginatedMasterlist @Search, @SortName, @SortDirection, @StartIndex, @PageSize";
            var param = new DynamicParameters();
            param.Add("Search", model.Search, DbType.String);
            param.Add("SortName", model.SortName, DbType.String);
            param.Add("SortDirection", model.SortDirection, DbType.String);
            param.Add("StartIndex", model.StartIndex, DbType.Int32);
            param.Add("PageSize", model.PageSize, DbType.Int32);

            using var conn = db.CreateConnection();
            return await conn.QueryAsync<MasterListViewModel>(sql, param);

        }


    }
}
