using Dapper;
using System.Data;
using richmindale_app.Server.DapperContext;
using richmindale_app.Server.Models.StoredProcedures;
using richmindale_app.Server.Models.ViewModels;


namespace richmindale_app.Server.Repositories
{
    public class RegistrarRepository : IRegistrarRepository
    {

        private readonly DapperDbContext db;

        public RegistrarRepository(DapperDbContext _db)
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

        public async Task<IEnumerable<LoadAllAdmissionsViewModel>> LoadAllAdmissionRequests(FilterViewModel model)
        {
            var sql = $@"EXEC sp_LoadAdmissionRequests @Search, @SortName, @SortDirection, @StartIndex, @PageSize";
            var param = new DynamicParameters();
            param.Add("Search", model.Search, DbType.String);
            param.Add("SortName", model.SortName, DbType.String);
            param.Add("SortDirection", model.SortDirection, DbType.String);
            param.Add("StartIndex", model.StartIndex, DbType.Int32);
            param.Add("PageSize", model.PageSize, DbType.Int32);
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<LoadAllAdmissionsViewModel>(sql, param);
        }

        public async Task<AdmissionViewModel> LoadAdmissionSummaryDetails(Guid id)
        {
            using var conn = db.CreateConnection();
            var sql = $@"EXEC sp_AdmissionSummaryDetails @Id";
            var param = new DynamicParameters();
            param.Add("Id", id, DbType.Guid);
            return await conn.QueryFirstOrDefaultAsync<AdmissionViewModel>(sql, param);
        }

         public async Task UpdateAdmissionStatus(Guid id, int status, string? reason)
        {
            var sql = $@"UPDATE LrnAdmissionApplications 
                         SET Status=@Status, 
                         Remarks=(case when isnull(Remarks,'') = '' then @reason else Remarks + '<br/>' + @Reason end) 
                         WHERE Id=@Id";
            var param = new DynamicParameters();
            param.Add("Status", status, DbType.Int32);
            param.Add("Reason", reason, DbType.String);
            param.Add("Id", id, DbType.Guid);
            using var conn = db.CreateConnection();
            await conn.ExecuteScalarAsync(sql, param);
        }

        

        

    }
}
