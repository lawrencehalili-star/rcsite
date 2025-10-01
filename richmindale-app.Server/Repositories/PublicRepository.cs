using System.Data;
using Dapper;
using richmindale_app.Server.DapperContext;
using richmindale_app.Server.Helpers;
using richmindale_app.Server.Models.ViewModels;

namespace richmindale_app.Server.Repositories
{

    public class PublicRepository : IPublicRepository
    {

        private readonly DapperDbContext db;

        public PublicRepository(DapperDbContext _db)
        {
            db = _db;
        }

        public async Task<string> VerifyEmail(string EmailAddress)
        {
            try
            {
                string passkey = CodeGenerator.Passkey(8);
                EmailSender sender = new EmailSender();
                string Subject = "Verification Code - Richmindale";
                string Body = "Dear Customer,<br/><br/>" +
                              "Your verification code is: " + passkey;
                sender.SendMail(EmailAddress, Subject, Body);
                
                using var conn = db.CreateConnection();
                var sql = "INSERT INTO SysPassKey (Id, Email, Passkey, GeneratedDate) VALUES ( @Id, @EmailAddress, @Passkey, @GeneratedDate)";
                var param = new DynamicParameters();
                param.Add("Id", Guid.NewGuid(), DbType.Guid);
                param.Add("EmailAddress", EmailAddress, DbType.String);
                param.Add("Passkey", passkey, DbType.String);
                param.Add("GeneratedDate", DateTime.Now, DbType.DateTime);
                await conn.ExecuteScalarAsync(sql, param);
                conn.Close();
                return passkey;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public async Task<string> ValidatePasskey(string email, string passkey)
        {
            try
            {
                using var conn = db.CreateConnection();
                var sql = $@"SELECT COUNT(Passkey) FROM SysPasskey WHERE Email=@Email AND Passkey=@Passkey";
                var param = new DynamicParameters();
                param.Add("Email", email, DbType.String);
                param.Add("Passkey", passkey, DbType.String);
                //param.Add("GeneratedDate", DateTime.Now, DbType.DateTime);
                if(conn.ExecuteScalar<int>(sql, param) > 0)
                {
                    sql = $@"DELETE FROM SysPasskey WHERE Email='" + email + "'";
                    await conn.ExecuteAsync(sql);
                    return "success";
                }
                else
                {
                    return "Invalid Passkey";
                }
            }
            catch(Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public async Task SubmitGrievance(GrievanceViewModel model)
        {
            var sql = $@"SELECT COUNT(*) + 1 FROM CrmGrievances WHERE YEAR(DateCreated)=YEAR(GETDATE())";
            using var conn = db.CreateConnection();
            int cnt = await conn.ExecuteScalarAsync<int>(sql);
            string code = CodeGenerator.GrievanceCode(cnt);
            

            EmailSender sender = new EmailSender();
            string subject = "Richmindale Grievance No.: " + code;
            string body = "Dear " + model.Complainant + ",<br/><br/>" +
                          "Your Grievance Report Number: " + code + " successfully for submitted to our office " +
                          "for further review and investigation.<br/><br/>" +
                          "You will be notified by the School Admin for clarification and investigation regarding your report.<br/><br/>" +
                          "Sincerely,<br/><br/>" +
                          "Resolution Team";
            sender.SendMail(model.EmailAddress, subject, body);

            Guid id = Guid.NewGuid();
            string hide =  model.HideComplainant == true ? "The Complainant requested to hide his/her identity for privacy purposes.<br/>" : "";
            body = "Dear School Admin,<br/><br/>" +
                   "A Grievance Report No.: " + code + " was submitted by a complainant <strong>" + model.Complainant + "</strong> with below details: <br/><br/>" +
                   "Complaint: " + model.Message + "<br/><br/>" + hide +
                   "To update and create a resolution, please click below link:<br/>" +
                   "<a href='https://www.richmindale.me/admin/grievances/details/" + id.ToString() + "'>" + code + "</a>";      
                         
            sender.SendMail("complaints@richmindale.com", subject, body);
            
            
            sql = $@"INSERT INTO CrmGrievances (Id, GrievanceCode, CategoryId, EmailAddress, Complainant, Respondents, Message, DateCreated, Status ) VALUES
                        (@Id, @GrievanceCode, @CategoryId, @EmailAddress, @Complainant, @Respondents, @Message, GETDATE(), 25)";
            var param = new DynamicParameters();
            param.Add("Id", id, DbType.Guid);
            param.Add("GrievanceCode", code, DbType.String);
            param.Add("CategoryId", model.CategoryId, DbType.Int32);
            param.Add("EmailAddress", model.EmailAddress, DbType.String);
            param.Add("Complainant", model.Complainant, DbType.String);
            param.Add("Respondents", model.Respondents, DbType.String);
            param.Add("Message", model.Message, DbType.String);
            await conn.ExecuteScalarAsync(sql, param);

        }
        public async Task SaveEnrollmentRequest(EnrollmentRequestViewModel model)
        {
            var sql = $@"INSERT INTO LrnEnrollment 
                         (Id, RequestDate, EmailAddress, CountryId, CampusId, LearningMethodId, ProgramId, Terms, SchoolYear, EnrollmentStatus) VALUES 
                         (NEWID(), GETDATE(), @EmailAddress, @CountryId, @CampusId, @LearningMethod, @ProgramId, @Terms, @SchoolYear, 31)";
            var param = new DynamicParameters();
            param.Add("EmailAddress", model.EmailAddress, DbType.String);
            param.Add("CountryId", model.CountryId, DbType.Int32);
            param.Add("CampusId", model.CampusId, DbType.Int32);
            param.Add("LearningmethodId", model.LearningMethodId, DbType.Int32);
            param.Add("ProgramId", model.ProgramId, DbType.Int32);
            param.Add("Terms", model.Terms, DbType.String);
            param.Add("SchoolYear", model.SchoolYear, DbType.String);
            
            using var conn = db.CreateConnection();
            await conn.ExecuteScalarAsync(sql, param);
        }
        public async Task SavePaypalPayment(PaypalPaymentsViewModels model)
        {
            var sql = $@"INSERT INTO FnPaypalPayments (Id, TransactionDate, TransactionNumber, EmailAddress, Fullname, PaymentFor, Amount, Currency, TransactionMessage, Status) " +
                        "SELECT NEWID(), GETDATE(), @TransactionNumber, @EmailAddress, @Fullname, @PaymentFor, @Amount, @Currency, @TransactionMessage, @Status";
            var param = new DynamicParameters();
            param.Add("TransactionNumber", model.TransactionNumber, DbType.String);
            param.Add("EmailAddress", model.EmailAddress, DbType.String);
            param.Add("Fullname", model.Fullname, DbType.String);
            param.Add("PaymentFor", model.PaymentFor, DbType.String);
            param.Add("Amount", model.Amount, DbType.Decimal);
            param.Add("Currency", model.Currency, DbType.String);
            param.Add("TransactionMessage", model.TransactionMessage, DbType.String);
            param.Add("Status", model.Status, DbType.String);
            using var conn = db.CreateConnection();
            await conn.ExecuteAsync(sql, param);

        }
        

    }

}