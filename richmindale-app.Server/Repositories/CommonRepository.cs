using Dapper;
using System.Data;
using richmindale_app.Server.DapperContext;
using richmindale_app.Server.Models.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace richmindale_app.Server.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly DapperDbContext db;

        public CommonRepository(DapperDbContext _db)
        {
            db = _db;
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetCountryDropdown()
        {
            var sql = $@"SELECT Id 'value', CountryName 'text', Emoji 'code' from Countries order by Countryname asc";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql);
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetStateCityById(string tbl, string textCol, string? cond,  int id)
        {
            var sql = $@"SELECT Id 'value', " + textCol + " 'text' " +
                       "from " + tbl + " " +
                       "where " + cond + "=" + id + " " +
                       "order by " + textCol + " asc";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql);
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetCommonDropdown(string grp)
        {
            var sql = $@"SELECT Id 'value', CategoryName 'text', CategoryCode 'code' FROM SysCategories " +
                        "WHERE CategoryGroup='" + grp + "' and ParentCategoryId is not null " +
                        "order by CategoryName asc;";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql); 
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetProgramsWithCode(string grp)
        {
            var sql = $@"SELECT ReferenceId 'value', CategoryName 'text', CategoryCode 'code' FROM SysCategories " +
                        "WHERE CategoryGroup='" + grp + "' and ParentCategoryId is not null " +
                        "order by CategoryName asc;";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql); 
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetProgramByCategoryId(int? id)
        {
            var sql = $@"SELECT ReferenceId 'value', CategoryName 'text', CategoryCode 'code' FROM SysCategories " +
                        "WHERE ParentCategoryId = @Id";
            var param = new DynamicParameters();
            param.Add("Id", id, DbType.Int32);
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql, param);
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetGradeLevelPrograms()
        {
            var sql = $@"SELECT ReferenceId 'value', CategoryName 'text' FROM SysCategories 
                         WHERE ParentCategoryId IS NOT NULL AND CategoryGroup='K12 Programs' AND Id NOT IN (162, 163, 164, 165)";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql);
        }
        public async Task<IEnumerable<CommonDropdownModel>> GetGradeLevelPeriods()
        {
            var sql = $@"SELECT Id 'value', CategoryName 'text' FROM SysCategories 
                         WHERE CategoryGroup='K12 Periods' AND ParentCategoryId IS NOT null";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql);
        }
        public async Task<IEnumerable<CommonDropdownModel>> GetGradeLevelCampuses()
        {
            var sql = $@"SELECT Id 'value', CampusName 'text' FROM LrnCampuses WHERE Status = 1 AND Id <> 10";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql);
        }
        public async Task<IEnumerable<CommonDropdownModel>> GetGradeLevelCredentials()
        {
            var sql = $@"SELECT Id 'value', CategoryName 'text', CategoryCode 'code' FROM 
                         SysCategories WHERE CategoryGroup='Credentials' and ParentCategoryId IS NOT NULL";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql);
        }
        
        public async Task<IEnumerable<CommonDropdownModel>> GetRelationships()
        {
            var sql = $@"SELECT Id 'value', CategoryName 'text' FROM SysCategories " +
                        "WHERE CategoryGroup='Relationships' AND ParentCategoryId IS NOT NULL and ID NOT IN (27,28)";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql);
        }
        public async Task<IEnumerable<CommonDropdownModel>> GetCommonDropdownByParent(int? id)
        {
            var sql = $@"SELECT Id 'value', CategoryName 'text' FROM SysCategories ";

            if(id != null || id != 0)
            {
                sql = sql + "WHERE ParentCategoryId=" + id + " ";
            }
                       
            sql += "order by CategoryName asc;";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql); 
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetStatusDropdown(string grp)
        {
             var sql = $@"SELECT Id 'value', StatusName 'text' FROM SysStatuses " +
                        "WHERE StatusGroup='" + grp + "' and ParentStatusId is not null " +
                        "order by StatusName asc;";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql); 
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetCampusCountries()
        {
            var sql = $@"SELECT a.Id 'value', a.CountryName 'text', a.Emoji 'code' FROM Countries a " +
                        "WHERE a.Id IN (SELECT DISTINCT CountryId FROM LrnCampuses)";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql);
        }

        // For US Only
        public async Task<IEnumerable<CommonDropdownModel>> GetUSCountry()
        {
            var sql = $@"SELECT a.Id 'value', a.CountryName 'text', a.Emoji 'code' FROM Countries a " +
                        "WHERE a.Id IN (SELECT DISTINCT CountryId FROM LrnCampuses) " +
                        "and a.Id = 233";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql);
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetDegreeCategory()
        {
            var sql = $@"SELECT Id 'value', CategoryName 'text' FROM SysCategories 
                      WHERE Id = 1";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql); 
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetUsLearningMethod()
        {
             var sql = $@"SELECT Id 'value', LearningMethodName + ' - ' + Description 'text' FROM LrnLearningMethods 
                      WHERE Id = 3";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql); 
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetCampusByCountry(int? id)
        {
            var sql = $@"";
            if(id == null || id == 0) 
            {
                sql = "SELECT Id 'value', CampusName 'text' FROM LrnCampuses WHERE Status=1";
                using var conn = db.CreateConnection();
                return await conn.QueryAsync<CommonDropdownModel>(sql);
            }
            else
            {
                sql = "SELECT Id 'value', CampusName 'text' FROM LrnCampuses " +
                        "WHERE CountryId=@CountryId AND Status=1";
                var param = new DynamicParameters();
                param.Add("CountryId", id, DbType.Int32);
                using var conn = db.CreateConnection();
                return await conn.QueryAsync<CommonDropdownModel>(sql, param);
            }
           
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetLearningMethods()
        {
            var sql = $@"SELECT Id 'value', LearningMethodName + ' - ' + Description 'text', Description FROM LrnLearningMethods WHERE Id NOT IN (5,6)";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql);
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetMaritalStatus()
        {
            var sql = $@"SELECT Id 'value', MaritalStatusName 'text' FROM MaritalStatus";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql); 
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetReligions()
        {
            var sql = $@"SELECT Id 'value', ReligionName 'text' FROM Religions";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql); 
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetNationality()
        {
            var sql = $@"SELECT Id 'value', Nationality 'text', Emoji 'code' FROM Countries ORDER BY Nationality asc";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql); 
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetPhoneCodes()
        {
            var sql = $@"SELECT Id 'value', CountryName + ' (' + PhoneCode + ')' 'text', Emoji 'code' FROM Countries ORDER BY PhoneCode asc";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql); 
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetDocumentTypes()
        {
            var sql = $@"SELECT Id 'value', DocumentName 'text' FROM SysDocumentTypes ORDER BY DocumentName asc";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql); 
        }

        public async Task<decimal> GetDocumentAmount(int id)
        {
            var sql = $@"SELECT DocumentAmount FROM SysDocumentTypes WHERE Id=" + id;
            using var conn = db.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<decimal>(sql);
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetAvailableCoursesByProgram(int? id)
        {
            var sql = $@"SELECT a.Id 'value', b.CourseCode + ' - ' + b.CourseTitle 'text'
                        FROM LrnProgramTermCourses a 
                        LEFT JOIN LrnCourses b 
                        ON a.CourseId = b.Id ";
            if(id != null || id != 0)
            {
                sql = sql + "AND a.ProgramId = " + id; 
            }

            sql += " ORDER BY b.CourseTitle ASC";
                       
            var param = new DynamicParameters();
            param.Add("ProgramId", id, DbType.Int32);
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql, param);
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetCoursesByTermsProgram(string? terms, int program)
        {
            var sql = $@"SELECT a.Id 'value', b.CourseCode + ' - ' + b.CourseTitle 'text'
                        FROM LrnProgramTermCourses a 
                        LEFT JOIN LrnCourses b 
                        ON a.CourseId = b.Id 
                        AND a.ProgramId = @ProgramId
                        WHERE a.ProgramId = @ProgramId
                        AND a.Terms = @Terms
                        ORDER BY b.CourseTitle ASC";
            var param = new DynamicParameters();
            param.Add("ProgramId", program, DbType.Int32);
            param.Add("Terms", terms, DbType.String);
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql, param);
        }

        public async Task<IEnumerable<CommonDropdownModel>> GetProgramsByCategoryId(int? id)
        {
            var sql = $@"SELECT Id 'value', 
                      ProgramTitle 'text' 
                      FROM LrnPrograms 
                      WHERE Status = 1 ";
            if(id != null || id != 0)
            {
                sql += "AND ProgramCategoryId=" + id;
            }
                      
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CommonDropdownModel>(sql);
        }
        public async Task<IEnumerable<UploadedCoursesDetailViewModel>> LoadUploadedCourses(string? search)
        {
            var sql = $@"EXEC sp_LoadUploadedCourses @Search";
            var param = new DynamicParameters();
            param.Add("Search", search, DbType.String);
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<UploadedCoursesDetailViewModel>(sql, param);
        } 

        public async Task<ProgramCoursesViewModel> GetProgramDetails(int id)
        {
            var sql = $@"SELECT Id, ProgramId, ProgramCode, ProgramTitle, ProgramDescription, Revision, RevisionDate,
                                EstimatedCost, TotalCredits, NoOfCourses, Semesters, AdmissionApplicationFee, TuitionPerUnit,
                                MiscellaneousPerUnit, CreditTransferFee, DocumentRequestFee, ExpediteFee
                         FROM LrnProgramDetails 
                         WHERE ProgramId=" + id;
            using var conn = db.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<ProgramCoursesViewModel>(sql);
        }

        public async Task<IEnumerable<ProgramCoursesViewModel>> GetProgramWithDetails()
        {
            var sql = $@"SELECT Id, ProgramId, ProgramCode, ProgramTitle, ProgramDescription, Revision, RevisionDate,
                                EstimatedCost, TotalCredits, NoOfCourses, Semesters, AdmissionApplicationFee, TuitionPerUnit,
                                MiscellaneousPerUnit, CreditTransferFee, DocumentRequestFee, ExpediteFee
                         FROM LrnProgramDetails";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<ProgramCoursesViewModel>(sql);
        }

        public async Task<IEnumerable<CoursesDetailsViewModel>> LoadProgramSemesterCourses(int id)
        {

            var sql = $@"SELECT Id, ProgramDetailsId, ProgramId, Semester, TermId, CourseId, 
                                CourseCode, CourseTitle, CourseDescription, LongDescription,
                                Revision, RevisionDate, PreRequisites, Credits, 
                                Programs, Tuition, Miscellaneous
                         FROM LrnProgramCoursesDetails
                         WHERE ProgramId=" + id;
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<CoursesDetailsViewModel>(sql);
        }
    }
}
