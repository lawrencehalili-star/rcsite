using Dapper;
using System.Data;
using richmindale_app.Server.DapperContext;
using richmindale_app.Server.Models.ViewModels;
using richmindale_app.Server.Helpers;

namespace richmindale_app.Server.Repositories
{
    public class ServicesRepository : IServicesRepository
    {

        private readonly DapperDbContext db;

        public ServicesRepository(DapperDbContext _db)
        {
            db = _db;
        }

        #region Document Requests
        public async Task<IEnumerable<DocumentRequestViewModel>> LoadStudentDocumentRequest(Guid id)
        {
            var sql = $@"EXEC sp_LoadStudentDocumentRequest @StudentId";
            var param = new DynamicParameters();
            param.Add("StudentId", id, DbType.Guid);
            using var conn = db.CreateConnection();
            return await conn.ExecuteScalarAsync<IEnumerable<DocumentRequestViewModel>>(sql, param);
        }

        public async Task SaveDocumentRequest(DocumentRequestViewModel model)
        {
            var sql = $@"SELECT COUNT(Id) FROM LrnStudentDocumentRequests WHERE YEAR(RequestDate)=YEAR(GETDATE())";
            using var conn = db.CreateConnection();
            int cnt = await conn.ExecuteScalarAsync<int>(sql);

            sql =  $@"INSERT INTO LrnStudentDocumentRequests (RequestNumber, RequestDate, StudentId, DocumentTypeId, Amount, Purpose ) VALUES (" +
                       "@RequestNumber, GETDATE(), @StudentId, @DocumentTypeId, @Amount, @Purpose)";
            var param = new DynamicParameters();
            param.Add("RequestNumber", CodeGenerator.RequestNumber(cnt), DbType.String);
            param.Add("StudentId", model.StudentId, DbType.Guid);
            param.Add("DocumentTypeId", model.DocumentTypeId, DbType.Int32);
            param.Add("Amount", model.Amount, DbType.Decimal);
            param.Add("Purpose", model.Purpose, DbType.String);
            await conn.ExecuteScalarAsync(sql, param);
                       
        }


        #endregion


    }
}