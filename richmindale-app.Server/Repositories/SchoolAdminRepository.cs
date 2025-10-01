using Dapper;
using richmindale_app.Server.DapperContext;
using System.Data;
using richmindale_app.Server.Models.StoredProcedures;
using richmindale_app.Server.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace richmindale_app.Server.Repositories
{
    public class SchoolAdminRepository : ISchoolAdminRepository
    {

        private readonly DapperDbContext db;

        public SchoolAdminRepository(DapperDbContext _db)
        {
            db = _db;
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

        public async Task<IEnumerable<LoadAllAdmissionsViewModel>> LoadCollegeAdmissionRequests(FilterViewModel model)
        {
            var sql = $@"EXEC sp_LoadCollegeAdmissionRequests @Search, @SortName, @SortDirection, @StartIndex, @PageSize";
            var param = new DynamicParameters();
            param.Add("Search", model.Search, DbType.String);
            param.Add("SortName", model.SortName, DbType.String);
            param.Add("SortDirection", model.SortDirection, DbType.String);
            param.Add("StartIndex", model.StartIndex, DbType.Int32);
            param.Add("PageSize", model.PageSize, DbType.Int32);
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<LoadAllAdmissionsViewModel>(sql, param);
        }

        public async Task<IEnumerable<LoadAllAdmissionsViewModel>> LoadGradeLevelAdmissionRequests(FilterViewModel model)
        {
            var sql = $@"EXEC sp_LoadGradeLevelAdmissionRequests @Search, @SortName, @SortDirection, @StartIndex, @PageSize";
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
                         Remarks = @Reason 
                         WHERE Id=@Id; 
                         INSERT INTO LrnAdmissionHistory (AdmissionApplicationId, TransactionDate, StatusId, Remarks)  
                         SELECT @Id, GETDATE(), 8, @Reason; ";
            var param = new DynamicParameters();
            param.Add("Status", status, DbType.Int32);
            param.Add("Reason", reason, DbType.String);
            param.Add("Id", id, DbType.Guid);
            using var conn = db.CreateConnection();
            await conn.ExecuteScalarAsync(sql, param);
        }
        public async Task<IEnumerable<AgreementCoursesViewModel>> LoadAgreementCourses(int id)
        {
            var sql =$@"EXEC sp_LoadAgreementCourses @ProgramId=" + id ;

            var lookup = new Dictionary<int, AgreementCoursesViewModel>();
            using var conn = db.CreateConnection();
            await conn.QueryAsync<AgreementCoursesViewModel, TermCourses, AgreementCoursesViewModel>(sql, map: (t, c) => {
                    
                    if(!lookup.TryGetValue(c.Id, out var courses)) 
                    {
                        courses = t;
                        courses.TermCourses ??= new List<TermCourses>();
                        lookup.Add(t.Id, courses);
                    }
                    courses.TermCourses.Add(c);
                    return courses;
                   
                }, splitOn: "TermName");

            return lookup.Values.AsEnumerable();
    
        }

        
    
    
    }
}