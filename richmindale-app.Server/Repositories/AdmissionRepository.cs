using Dapper;
using System.Data;
using richmindale_app.Server.DapperContext;
using richmindale_app.Server.Helpers;
using richmindale_app.Server.Models.ViewModels;
using richmindale_app.Server.Models.StoredProcedures;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.OpenApi.Models;

namespace richmindale_app.Server.Repositories
{
    public class AdmissionRepository : IAdmission
    {

        private readonly DapperDbContext db;
        private readonly IEmailSender emailSender;

        public AdmissionRepository(DapperDbContext _db, IEmailSender _emailSender)

        {
            this.db = _db;
            this.emailSender = _emailSender;
        }
        public async Task<string> VerifyEmail(string EmailAddress)
        {
            try
            {
                string passkey = CodeGenerator.Passkey(8);
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
                if (conn.ExecuteScalar<int>(sql, param) > 0)
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
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public async Task<Guid> VerifyApplication(AdmissionVerificationModel model)
        {
            try
            {
                using var conn = db.CreateConnection();
                var sql = $@"SELECT COUNT(*) FROM LrnAdmissionApplications WHERE EmailAddress=@EmailAddress AND ProgramId=@ProgramId";
                var param = new DynamicParameters();
                param.Add("EmailAddress", model.EmailAddress, DbType.String);
                param.Add("ProgramId", model.ProgramId, DbType.Int32);
                if (conn.ExecuteScalar<int>(sql, param) > 0)
                {
                    sql = $@"SELECT Id FROM LrnAdmissionApplications WHERE EmailAddress=@EmailAddress AND ProgramId=@ProgramId AND Status != 15";
                    return await conn.ExecuteScalarAsync<Guid>(sql, param);
                }
                else
                {
                    Guid id = Guid.NewGuid();
                    sql = $@"SELECT COUNT(Id) FROM LrnAdmissionApplications WHERE YEAR(ApplicationDate) = YEAR(GETDATE())";
                    int count = conn.ExecuteScalar<int>(sql);

                    sql = $@"INSERT INTO LrnAdmissionApplications (Id, RequestTypeId, ApplicationRefNo, EmailAddress, ProgramCategoryId, ProgramId, ApplicationDate) " +
                          "SELECT @Id, @RequestTypeId, @ApplicationRefNo, @EmailAddress, @ProgramCategoryId, @ProgramId, @ApplicationDate";
                    var iParam = new DynamicParameters();
                    iParam.Add("Id", id, DbType.Guid);
                    iParam.Add("RequestTypeId", model.RequestTypeId, DbType.Int32);
                    iParam.Add("ApplicationRefNo", CodeGenerator.AdmissionNumber(count + 1), DbType.String);
                    iParam.Add("EmailAddress", model.EmailAddress, DbType.String);
                    iParam.Add("ProgramCategoryId", model.ProgramCategoryId, DbType.Int32);
                    iParam.Add("ProgramId", model.ProgramId, DbType.Int32);
                    iParam.Add("ApplicationDate", DateTime.Now, DbType.DateTime);
                    await conn.ExecuteScalarAsync(sql, iParam);
                    return id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());

            }


        }
        public async Task<AdmissionViewModel> LoadAdmissionSummaryDetails(Guid id)
        {
            {
                using var conn = db.CreateConnection();
                var sql = $@"EXEC sp_AdmissionSummaryDetails @Id";
                var param = new DynamicParameters();
                param.Add("Id", id, DbType.Guid);
                return await conn.QueryFirstOrDefaultAsync<AdmissionViewModel>(sql, param);
            }
        }

        public async Task<int> UpdateAdmissionApplication(AdmissionViewModel model)
        {
            var param = new DynamicParameters();
            var sql = $@"UPDATE LrnAdmissionApplications SET " +
                        "ProgramCategoryId=@ProgramCategoryId" +
                        ", TermId=@TermId" +
                        ", ProgramId=@ProgramId" +
                        ", CountryId=@CountryId" +
                        ", LrnCampusId=@LrnCampusId" +
                        ", LearningMethodsId=@LearningMethodsId" +
                        ", CreditTransfer=@CreditTransfer";
            param.Add("ProgramCategoryId", model.ProgramCategoryId, DbType.Int32);
            param.Add("TermId", model.TermId, DbType.Int32);
            param.Add("ProgramId", model.ProgramId, DbType.Int32);
            param.Add("CountryId", model.CountryId, DbType.Int32);
            param.Add("LrnCampusId", model.LrnCampusId, DbType.Int32);
            param.Add("LearningMethodsId", model.LearningMethodsId, DbType.Int32);
            param.Add("CreditTransfer", model.CreditTransfer, DbType.Boolean);
            if (model.ApplyDiscount)
            {
                sql = sql + ", ApplyDiscount=@ApplyDiscount" +
                            ", DiscountCode=@DiscountCode";
                param.Add("ApplyDiscount", model.ApplyDiscount, DbType.Boolean);
                param.Add("DiscountCode", model.DiscountCode, DbType.String);
            }

            // sql = sql + " WHERE Id=@Id";  // or whatever your primary key column is
            // param.Add("Id", model.Id, DbType.Guid);



            // Student Info
            sql = sql + ", StudentGivenName=@StudentGivenName" +
                        ", StudentLastname=@StudentLastname" +
                        ", StudentMiddleName=@StudentMiddleName" +
                        ", StudentMaidenName=@StudentMaidenName" +
                        ", StudentBirthDate=@StudentBirthDate" +
                        ", StudentGender=@StudentGender" +
                        ", StudentMaritalStatus=@StudentMaritalStatus" +
                        ", StudentReligion=@StudentReligion" +
                        ", StudentNationality=@StudentNationality" +
                        ", StudentCountry=@StudentCountry" +
                        ", StudentState=@StudentState" +
                        ", StudentCity=@StudentCity" +
                        ", StudentZipCode=@StudentZipCode" +
                        ", StudentAddress=@StudentAddress" +
                        ", StudentEmail1=@StudentEmail1" +
                        ", StudentEmail2=@StudentEmail2" +
                        ", StudentPhoneCode1=@StudentPhoneCode1" +
                        ", StudentPhone1=@StudentPhone1" +
                        ", StudentPhoneCode2=@StudentPhoneCode2" +
                        ", StudentPhone2=@StudentPhone2";
            param.Add("StudentGivenName", model.StudentGivenName, DbType.String);
            param.Add("StudentLastname", model.StudentLastname, DbType.String);
            param.Add("StudentMiddleName", model.StudentMiddleName, DbType.String);
            param.Add("StudentMaidenName", model.StudentMaidenName, DbType.String);
            param.Add("StudentBirthDate", model.StudentBirthDate, DbType.DateTime);
            param.Add("StudentGender", model.StudentGender, DbType.Int32);
            param.Add("StudentMaritalStatus", model.StudentMaritalStatus, DbType.Int32);
            param.Add("StudentReligion", model.StudentReligion, DbType.Int32);
            param.Add("StudentNationality", model.StudentNationality, DbType.Int32);
            param.Add("StudentCountry", model.StudentCountry, DbType.Int32);
            param.Add("StudentState", model.StudentState, DbType.Int32);
            param.Add("StudentCity", model.StudentCity, DbType.Int32);
            param.Add("StudentZipCode", model.StudentZipCode, DbType.String);
            param.Add("StudentAddress", model.StudentAddress, DbType.String);
            param.Add("StudentEmail1", model.StudentEmail1, DbType.String);
            param.Add("StudentEmail2", model.StudentEmail2, DbType.String);
            param.Add("StudentPhoneCode1", model.StudentPhone1, DbType.String);
            param.Add("StudentPhone1", model.StudentPhone1, DbType.String);
            param.Add("StudentPhoneCode2", model.StudentPhoneCode2, DbType.String);
            param.Add("StudentPhone2", model.StudentPhone2, DbType.String);
            // Previous School
            if (!model.SkipSchool)
            {
                sql = sql + ", SkipSchool=0" +
                            ", SchoolName=@SchoolName" +
                            ", Qualifications=@Qualifications" +
                            ", SchoolProgram=@SchoolProgram" +
                            ", SchoolOtherProgram=@SchoolOtherProgram" +
                            ", SchoolEmail=@SchoolEmail" +
                            ", SchoolCountry=@SchoolCountry" +
                            ", SchoolAddress=@SchoolAddress" +
                            ", SchoolContact=@SchoolContact" +
                            ", SchoolContactDesignation=@SchoolContactDesignation" +
                            ", SchoolContactEmail=@SchoolContactEmail" +
                            ", SchoolPhoneCode=@SchoolPhoneCode" +
                            ", SchoolContactNumber=@SchoolContactNumber";
                param.Add("SchoolName", model.SchoolName, DbType.String);
                param.Add("Qualifications", model.Qualifications, DbType.Int32);
                param.Add("SchoolProgram", model.SchoolProgram, DbType.Int32);
                param.Add("SchoolOtherProgram", model.SchoolOtherProgram, DbType.String);
                param.Add("SchoolEmail", model.SchoolEmail, DbType.String);
                param.Add("SchoolCountry", model.SchoolCountry, DbType.Int32);
                param.Add("SchoolAddress", model.SchoolAddress, DbType.String);
                param.Add("SchoolContact", model.SchoolContact, DbType.String);
                param.Add("SchoolContactDesignation", model.SchoolContactDesignation, DbType.String);
                param.Add("SchoolContactEmail", model.SchoolContactEmail, DbType.String);
                param.Add("SchoolPhoneCode", model.SchoolPhoneCode, DbType.String);
                param.Add("SchoolContactNumber", model.SchoolContactNumber, DbType.String);
            }
            // Father
            if (!model.SkipFather)
            {
                sql = sql + ", SkipFather=0" +
                        ", FatherGivenName=@FatherGivenName" +
                        ", FatherLastname=@FatherLastname" +
                        ", FatherMiddleName=@FatherMiddleName" +
                        ", FatherBirthDate=@FatherBirthDate" +
                        ", FatherGender=@FatherGender" +
                        ", FatherMaritalStatus=@FatherMaritalStatus" +
                        ", FatherReligion=@FatherReligion" +
                        ", FatherNationality=@FatherNationality" +
                        ", FatherCountry=@FatherCountry" +
                        ", FatherState=@FatherState" +
                        ", FatherCity=@FatherCity" +
                        ", FatherZipCode=@FatherZipCode" +
                        ", FatherAddress=@FatherAddress" +
                        ", FatherEmail1=@FatherEmail1" +
                        ", FatherEmail2=@FatherEmail2" +
                        ", FatherPhoneCode1=@FatherPhoneCode1" +
                        ", FatherPhone1=@FatherPhone1" +
                        ", FatherPhoneCode2=@FatherPhoneCode2" +
                        ", FatherPhone2=@FatherPhone2";
                param.Add("FatherGivenName", model.FatherGivenName, DbType.String);
                param.Add("FatherLastname", model.FatherLastname, DbType.String);
                param.Add("FatherMiddleName", model.FatherMiddleName, DbType.String);
                param.Add("FatherBirthDate", model.FatherBirthDate, DbType.DateTime);
                param.Add("FatherGender", model.FatherGender, DbType.Int32);
                param.Add("FatherMaritalStatus", model.FatherMaritalStatus, DbType.Int32);
                param.Add("FatherReligion", model.FatherReligion, DbType.Int32);
                param.Add("FatherNationality", model.FatherNationality, DbType.Int32);
                param.Add("FatherCountry", model.FatherCountry, DbType.Int32);
                param.Add("FatherState", model.FatherState, DbType.Int32);
                param.Add("FatherCity", model.FatherCity, DbType.Int32);
                param.Add("FatherZipCode", model.FatherZipCode, DbType.String);
                param.Add("FatherAddress", model.FatherAddress, DbType.String);
                param.Add("FatherEmail1", model.FatherEmail1, DbType.String);
                param.Add("FatherEmail2", model.FatherEmail2, DbType.String);
                param.Add("FatherPhoneCode1", model.FatherPhone1, DbType.String);
                param.Add("FatherPhone1", model.FatherPhone1, DbType.String);
                param.Add("FatherPhoneCode2", model.FatherPhoneCode2, DbType.String);
                param.Add("FatherPhone2", model.FatherPhone2, DbType.String);
            }
            // Mother
            if (!model.SkipMother)
            {
                sql = sql + ", SkipMother=0" +
                        ", MotherGivenName=@MotherGivenName" +
                        ", MotherLastname=@MotherLastname" +
                        ", MotherMiddleName=@MotherMiddleName" +
                        ", MotherMaidenName=@MotherMaidenName" +
                        ", MotherBirthDate=@MotherBirthDate" +
                        ", MotherGender=@MotherGender" +
                        ", MotherMaritalStatus=@MotherMaritalStatus" +
                        ", MotherReligion=@MotherReligion" +
                        ", MotherNationality=@MotherNationality" +
                        ", MotherCountry=@MotherCountry" +
                        ", MotherState=@MotherState" +
                        ", MotherCity=@MotherCity" +
                        ", MotherZipCode=@MotherZipCode" +
                        ", MotherAddress=@MotherAddress" +
                        ", MotherEmail1=@MotherEmail1" +
                        ", MotherEmail2=@MotherEmail2" +
                        ", MotherPhoneCode1=@MotherPhoneCode1" +
                        ", MotherPhone1=@MotherPhone1" +
                        ", MotherPhoneCode2=@MotherPhoneCode2" +
                        ", MotherPhone2=@MotherPhone2";
                param.Add("MotherGivenName", model.MotherGivenName, DbType.String);
                param.Add("MotherLastname", model.MotherLastname, DbType.String);
                param.Add("MotherMiddleName", model.MotherMiddleName, DbType.String);
                param.Add("MotherMaidenName", model.MotherMaidenName, DbType.String);
                param.Add("MotherBirthDate", model.MotherBirthDate, DbType.DateTime);
                param.Add("MotherGender", model.MotherGender, DbType.Int32);
                param.Add("MotherMaritalStatus", model.MotherMaritalStatus, DbType.Int32);
                param.Add("MotherReligion", model.MotherReligion, DbType.Int32);
                param.Add("MotherNationality", model.MotherNationality, DbType.Int32);
                param.Add("MotherCountry", model.MotherCountry, DbType.Int32);
                param.Add("MotherState", model.MotherState, DbType.Int32);
                param.Add("MotherCity", model.MotherCity, DbType.Int32);
                param.Add("MotherZipCode", model.MotherZipCode, DbType.String);
                param.Add("MotherAddress", model.MotherAddress, DbType.String);
                param.Add("MotherEmail1", model.MotherEmail1, DbType.String);
                param.Add("MotherEmail2", model.MotherEmail2, DbType.String);
                param.Add("MotherPhoneCode1", model.MotherPhone1, DbType.String);
                param.Add("MotherPhone1", model.MotherPhone1, DbType.String);
                param.Add("MotherPhoneCode2", model.MotherPhoneCode2, DbType.String);
                param.Add("MotherPhone2", model.MotherPhone2, DbType.String);
            }
            // Guardian
            if (!model.SkipGuardian)
            {
                sql = sql + ", SkipGuardian=0" +
                        ", GuardianGivenName=@GuardianGivenName" +
                        ", GuardianLastname=@GuardianLastname" +
                        ", GuardianMiddleName=@GuardianMiddleName" +
                        ", GuardianMaidenName=@GuardianMaidenName" +
                        ", GuardianBirthDate=@GuardianBirthDate" +
                        ", GuardianGender=@GuardianGender" +
                        ", GuardianMaritalStatus=@GuardianMaritalStatus" +
                        ", GuardianReligion=@GuardianReligion" +
                        ", GuardianNationality=@GuardianNationality" +
                        ", GuardianCountry=@GuardianCountry" +
                        ", GuardianState=@GuardianState" +
                        ", GuardianCity=@GuardianCity" +
                        ", GuardianZipCode=@GuardianZipCode" +
                        ", GuardianAddress=@GuardianAddress" +
                        ", GuardianEmail1=@GuardianEmail1" +
                        ", GuardianEmail2=@GuardianEmail2" +
                        ", GuardianPhoneCode1=@GuardianPhoneCode1" +
                        ", GuardianPhone1=@GuardianPhone1" +
                        ", GuardianPhoneCode2=@GuardianPhoneCode2" +
                        ", GuardianPhone2=@GuardianPhone2";
                param.Add("GuardianGivenName", model.GuardianGivenName, DbType.String);
                param.Add("GuardianLastname", model.GuardianLastname, DbType.String);
                param.Add("GuardianMiddleName", model.GuardianMiddleName, DbType.String);
                param.Add("GuardianMaidenName", model.GuardianMaidenName, DbType.String);
                param.Add("GuardianBirthDate", model.GuardianBirthDate, DbType.DateTime);
                param.Add("GuardianGender", model.GuardianGender, DbType.Int32);
                param.Add("GuardianMaritalStatus", model.GuardianMaritalStatus, DbType.Int32);
                param.Add("GuardianReligion", model.GuardianReligion, DbType.Int32);
                param.Add("GuardianNationality", model.GuardianNationality, DbType.Int32);
                param.Add("GuardianCountry", model.GuardianCountry, DbType.Int32);
                param.Add("GuardianState", model.GuardianState, DbType.Int32);
                param.Add("GuardianCity", model.GuardianCity, DbType.Int32);
                param.Add("GuardianZipCode", model.GuardianZipCode, DbType.String);
                param.Add("GuardianAddress", model.GuardianAddress, DbType.String);
                param.Add("GuardianEmail1", model.GuardianEmail1, DbType.String);
                param.Add("GuardianEmail2", model.GuardianEmail2, DbType.String);
                param.Add("GuardianPhoneCode1", model.GuardianPhone1, DbType.String);
                param.Add("GuardianPhone1", model.GuardianPhone1, DbType.String);
                param.Add("GuardianPhoneCode2", model.GuardianPhoneCode2, DbType.String);
                param.Add("GuardianPhone2", model.GuardianPhone2, DbType.String);
            }

            sql = sql + ", Status=32 WHERE Id=@Id";  // 999 - Draft
            param.Add("Id", model.Id, DbType.Guid);

            using var conn = db.CreateConnection();
            return await conn.ExecuteAsync(sql, param);


        }
        public async Task<int> UpdateGradeLevelAdmissionApplication(AdmissionViewModel model)
        {
            try
            {
                var sql = $@"UPDATE LrnAdmissionApplications SET ";
                var param = new DynamicParameters();

                switch (model.TabIndex)
                {
                    // Admission Details
                    case 0:
                        sql = sql + "ProgramCategoryId=2" +
                            ", SchoolYear=@SchoolYear" +
                            ", ProgramId=@ProgramId" +
                            ", CountryId=@CountryId" +
                            ", LrnCampusId=@LrnCampusId" +
                            ", LearningMethodsId=@LearningMethodsId ";
                        param.Add("SchoolYear", model.SchoolYear, DbType.Int32);
                        param.Add("ProgramId", model.ProgramId, DbType.Int32);
                        param.Add("CountryId", model.CountryId, DbType.Int32);
                        param.Add("LrnCampusId", model.LrnCampusId, DbType.Int32);
                        param.Add("LearningMethodsId", model.LearningMethodsId, DbType.Int32);
                        break;

                    // Student Info
                    case 1:
                        sql = sql + "StudentGivenName=@StudentGivenName" +
                            ", StudentLastname=@StudentLastname" +
                            ", StudentMiddleName=@StudentMiddleName" +
                            ", StudentBirthDate=@StudentBirthDate" +
                            ", StudentGender=@StudentGender" +
                            ", StudentMaritalStatus=@StudentMaritalStatus" +
                            ", StudentReligion=@StudentReligion" +
                            ", StudentNationality=@StudentNationality" +
                            ", StudentCountry=@StudentCountry" +
                            ", StudentState=@StudentState" +
                            ", StudentCity=@StudentCity" +
                            ", StudentZipCode=@StudentZipCode" +
                            ", StudentAddress=@StudentAddress" +
                            ", StudentEmail1=@StudentEmail1" +
                            ", StudentEmail2=@StudentEmail2" +
                            ", StudentPhoneCode1=@StudentPhoneCode1" +
                            ", StudentPhone1=@StudentPhone1" +
                            ", StudentPhoneCode2=@StudentPhoneCode2" +
                            ", StudentPhone2=@StudentPhone2 ";
                        param.Add("StudentGivenName", model.StudentGivenName, DbType.String);
                        param.Add("StudentLastname", model.StudentLastname, DbType.String);
                        param.Add("StudentMiddleName", model.StudentMiddleName, DbType.String);
                        param.Add("StudentBirthDate", model.StudentBirthDate, DbType.DateTime);
                        param.Add("StudentGender", model.StudentGender, DbType.Int32);
                        param.Add("StudentMaritalStatus", model.StudentMaritalStatus, DbType.Int32);
                        param.Add("StudentReligion", model.StudentReligion, DbType.Int32);
                        param.Add("StudentNationality", model.StudentNationality, DbType.Int32);
                        param.Add("StudentCountry", model.StudentCountry, DbType.Int32);
                        param.Add("StudentState", model.StudentState, DbType.Int32);
                        param.Add("StudentCity", model.StudentCity, DbType.Int32);
                        param.Add("StudentZipCode", model.StudentZipCode, DbType.String);
                        param.Add("StudentAddress", model.StudentAddress, DbType.String);
                        param.Add("StudentEmail1", model.StudentEmail1, DbType.String);
                        param.Add("StudentEmail2", model.StudentEmail2, DbType.String);
                        param.Add("StudentPhoneCode1", model.StudentPhone1, DbType.String);
                        param.Add("StudentPhone1", model.StudentPhone1, DbType.String);
                        param.Add("StudentPhoneCode2", model.StudentPhoneCode2, DbType.String);
                        param.Add("StudentPhone2", model.StudentPhone2, DbType.String);
                        break;

                    // School Info
                    case 2:
                        sql = sql + "SkipSchool=0" +
                                ", SchoolName=@SchoolName" +
                                ", PreviousLRN=@PreviousLRN" +
                                ", PreviousProgramId=@PreviousProgramId" +
                                ", YearAttended=@YearAttended" +
                                ", SchoolEmail=@SchoolEmail" +
                                ", SchoolCountry=@SchoolCountry" +
                                ", SchoolAddress=@SchoolAddress" +
                                ", SchoolContact=@SchoolContact" +
                                ", SchoolContactDesignation=@SchoolContactDesignation" +
                                ", SchoolContactEmail=@SchoolContactEmail" +
                                ", SchoolPhoneCode=@SchoolPhoneCode" +
                                ", SchoolContactNumber=@SchoolContactNumber ";
                        param.Add("SchoolName", model.SchoolName, DbType.String);
                        param.Add("PreviousLRN", model.PreviousLRN, DbType.String);
                        param.Add("PreviousProgramId", model.PreviousProgramId, DbType.Int32);
                        param.Add("YearAttended", model.YearAttended, DbType.String);
                        param.Add("SchoolEmail", model.SchoolEmail, DbType.String);
                        param.Add("SchoolCountry", model.SchoolCountry, DbType.Int32);
                        param.Add("SchoolAddress", model.SchoolAddress, DbType.String);
                        param.Add("SchoolContact", model.SchoolContact, DbType.String);
                        param.Add("SchoolContactDesignation", model.SchoolContactDesignation, DbType.String);
                        param.Add("SchoolContactEmail", model.SchoolContactEmail, DbType.String);
                        param.Add("SchoolPhoneCode", model.SchoolPhoneCode, DbType.String);
                        param.Add("SchoolContactNumber", model.SchoolContactNumber, DbType.String);
                        break;

                    // Father's Info
                    case 3:
                        if (model.SkipFather)
                        {
                            sql = sql + "SkipFather=1 ";
                        }
                        else
                        {
                            sql = sql + "SkipFather=0" +
                                    ", FatherGivenName=@FatherGivenName" +
                                    ", FatherLastname=@FatherLastname" +
                                    ", FatherMiddleName=@FatherMiddleName" +
                                    ", FatherBirthDate=@FatherBirthDate" +
                                    ", FatherGender=@FatherGender" +
                                    ", FatherMaritalStatus=@FatherMaritalStatus" +
                                    ", FatherReligion=@FatherReligion" +
                                    ", FatherNationality=@FatherNationality" +
                                    ", FatherCountry=@FatherCountry" +
                                    ", FatherState=@FatherState" +
                                    ", FatherCity=@FatherCity" +
                                    ", FatherZipCode=@FatherZipCode" +
                                    ", FatherAddress=@FatherAddress" +
                                    ", FatherEmail1=@FatherEmail1" +
                                    ", FatherEmail2=@FatherEmail2" +
                                    ", FatherPhoneCode1=@FatherPhoneCode1" +
                                    ", FatherPhone1=@FatherPhone1" +
                                    ", FatherPhoneCode2=@FatherPhoneCode2" +
                                    ", FatherPhone2=@FatherPhone2 ";
                            param.Add("FatherGivenName", model.FatherGivenName, DbType.String);
                            param.Add("FatherLastname", model.FatherLastname, DbType.String);
                            param.Add("FatherMiddleName", model.FatherMiddleName, DbType.String);
                            param.Add("FatherBirthDate", model.FatherBirthDate, DbType.DateTime);
                            param.Add("FatherGender", model.FatherGender, DbType.Int32);
                            param.Add("FatherMaritalStatus", model.FatherMaritalStatus, DbType.Int32);
                            param.Add("FatherReligion", model.FatherReligion, DbType.Int32);
                            param.Add("FatherNationality", model.FatherNationality, DbType.Int32);
                            param.Add("FatherCountry", model.FatherCountry, DbType.Int32);
                            param.Add("FatherState", model.FatherState, DbType.Int32);
                            param.Add("FatherCity", model.FatherCity, DbType.Int32);
                            param.Add("FatherZipCode", model.FatherZipCode, DbType.String);
                            param.Add("FatherAddress", model.FatherAddress, DbType.String);
                            param.Add("FatherEmail1", model.FatherEmail1, DbType.String);
                            param.Add("FatherEmail2", model.FatherEmail2, DbType.String);
                            param.Add("FatherPhoneCode1", model.FatherPhone1, DbType.String);
                            param.Add("FatherPhone1", model.FatherPhone1, DbType.String);
                            param.Add("FatherPhoneCode2", model.FatherPhoneCode2, DbType.String);
                            param.Add("FatherPhone2", model.FatherPhone2, DbType.String);
                        }
                        break;

                    // Mother's Info
                    case 4:
                        if (model.SkipMother)
                        {
                            sql = sql + "SkipMother=1 ";
                        }
                        else
                        {
                            sql = sql + "SkipMother=0" +
                                    ", MotherGivenName=@MotherGivenName" +
                                    ", MotherLastname=@MotherLastname" +
                                    ", MotherMiddleName=@MotherMiddleName" +
                                    ", MotherMaidenName=@MotherMaidenName" +
                                    ", MotherBirthDate=@MotherBirthDate" +
                                    ", MotherGender=@MotherGender" +
                                    ", MotherMaritalStatus=@MotherMaritalStatus" +
                                    ", MotherReligion=@MotherReligion" +
                                    ", MotherNationality=@MotherNationality" +
                                    ", MotherCountry=@MotherCountry" +
                                    ", MotherState=@MotherState" +
                                    ", MotherCity=@MotherCity" +
                                    ", MotherZipCode=@MotherZipCode" +
                                    ", MotherAddress=@MotherAddress" +
                                    ", MotherEmail1=@MotherEmail1" +
                                    ", MotherEmail2=@MotherEmail2" +
                                    ", MotherPhoneCode1=@MotherPhoneCode1" +
                                    ", MotherPhone1=@MotherPhone1" +
                                    ", MotherPhoneCode2=@MotherPhoneCode2" +
                                    ", MotherPhone2=@MotherPhone2 ";
                            param.Add("MotherGivenName", model.MotherGivenName, DbType.String);
                            param.Add("MotherLastname", model.MotherLastname, DbType.String);
                            param.Add("MotherMiddleName", model.MotherMiddleName, DbType.String);
                            param.Add("MotherMaidenName", model.MotherMaidenName, DbType.String);
                            param.Add("MotherBirthDate", model.MotherBirthDate, DbType.DateTime);
                            param.Add("MotherGender", model.MotherGender, DbType.Int32);
                            param.Add("MotherMaritalStatus", model.MotherMaritalStatus, DbType.Int32);
                            param.Add("MotherReligion", model.MotherReligion, DbType.Int32);
                            param.Add("MotherNationality", model.MotherNationality, DbType.Int32);
                            param.Add("MotherCountry", model.MotherCountry, DbType.Int32);
                            param.Add("MotherState", model.MotherState, DbType.Int32);
                            param.Add("MotherCity", model.MotherCity, DbType.Int32);
                            param.Add("MotherZipCode", model.MotherZipCode, DbType.String);
                            param.Add("MotherAddress", model.MotherAddress, DbType.String);
                            param.Add("MotherEmail1", model.MotherEmail1, DbType.String);
                            param.Add("MotherEmail2", model.MotherEmail2, DbType.String);
                            param.Add("MotherPhoneCode1", model.MotherPhone1, DbType.String);
                            param.Add("MotherPhone1", model.MotherPhone1, DbType.String);
                            param.Add("MotherPhoneCode2", model.MotherPhoneCode2, DbType.String);
                            param.Add("MotherPhone2", model.MotherPhone2, DbType.String);
                        }
                        break;

                    // Guardian's Info
                    case 5:
                        sql = sql + "SkipGuardian=0" +
                                    ", GuardianTypeId=@GuardianTypeId" +
                                    ", RelationshipId=@RelationshipId" +
                                    ", GuardianGivenName=@GuardianGivenName" +
                                    ", GuardianLastname=@GuardianLastname" +
                                    ", GuardianMiddleName=@GuardianMiddleName" +
                                    ", GuardianMaidenName=@GuardianMaidenName" +
                                    ", GuardianBirthDate=@GuardianBirthDate" +
                                    ", GuardianGender=@GuardianGender" +
                                    ", GuardianMaritalStatus=@GuardianMaritalStatus" +
                                    ", GuardianReligion=@GuardianReligion" +
                                    ", GuardianNationality=@GuardianNationality" +
                                    ", GuardianCountry=@GuardianCountry" +
                                    ", GuardianState=@GuardianState" +
                                    ", GuardianCity=@GuardianCity" +
                                    ", GuardianZipCode=@GuardianZipCode" +
                                    ", GuardianAddress=@GuardianAddress" +
                                    ", GuardianEmail1=@GuardianEmail1" +
                                    ", GuardianEmail2=@GuardianEmail2" +
                                    ", GuardianPhoneCode1=@GuardianPhoneCode1" +
                                    ", GuardianPhone1=@GuardianPhone1" +
                                    ", GuardianPhoneCode2=@GuardianPhoneCode2" +
                                    ", GuardianPhone2=@GuardianPhone2 ";
                        param.Add("GuardianTypeId", model.GuardianTypeId, DbType.Int32);
                        param.Add("RelationshipId", model.RelationshipId, DbType.Int32);
                        param.Add("GuardianGivenName", model.GuardianGivenName, DbType.String);
                        param.Add("GuardianLastname", model.GuardianLastname, DbType.String);
                        param.Add("GuardianMiddleName", model.GuardianMiddleName, DbType.String);
                        param.Add("GuardianMaidenName", model.GuardianMaidenName, DbType.String);
                        param.Add("GuardianBirthDate", model.GuardianBirthDate, DbType.DateTime);
                        param.Add("GuardianGender", model.GuardianGender, DbType.Int32);
                        param.Add("GuardianMaritalStatus", model.GuardianMaritalStatus, DbType.Int32);
                        param.Add("GuardianReligion", model.GuardianReligion, DbType.Int32);
                        param.Add("GuardianNationality", model.GuardianNationality, DbType.Int32);
                        param.Add("GuardianCountry", model.GuardianCountry, DbType.Int32);
                        param.Add("GuardianState", model.GuardianState, DbType.Int32);
                        param.Add("GuardianCity", model.GuardianCity, DbType.Int32);
                        param.Add("GuardianZipCode", model.GuardianZipCode, DbType.String);
                        param.Add("GuardianAddress", model.GuardianAddress, DbType.String);
                        param.Add("GuardianEmail1", model.GuardianEmail1, DbType.String);
                        param.Add("GuardianEmail2", model.GuardianEmail2, DbType.String);
                        param.Add("GuardianPhoneCode1", model.GuardianPhoneCode1, DbType.String);
                        param.Add("GuardianPhone1", model.GuardianPhone1, DbType.String);
                        param.Add("GuardianPhoneCode2", model.GuardianPhoneCode2, DbType.String);
                        param.Add("GuardianPhone2", model.GuardianPhone2, DbType.String);
                        break;
                }

                sql = sql + ", Status=32 WHERE Id=@Id";  // 999 - Draft
                param.Add("Id", model.Id, DbType.Guid);

                using var conn = db.CreateConnection();
                return await conn.ExecuteAsync(sql, param);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
        public async Task<int> SubmitAdmissionApplication(AdmissionViewModel model)
        {
            // Registrar Email

            // var subject = "Admission Application Receipt - " + model.StudentLastname + ", " + model.StudentGivenName + (model.StudentMiddleName != string.Empty ? " " + model.StudentMiddleName.Substring(0, 1) : "; ");
            var subject = "Admission Application Receipt - " + model.StudentLastname + ", " + model.StudentGivenName + (!string.IsNullOrEmpty(model.StudentMiddleName) ? " " + model.StudentMiddleName.Substring(0, 1) + "." : "") + ";";
            var body = "Dear Registrar,<br/><br/>" +
                          "A new <strong>Admission Application</strong> has been submitted using Richmindale Website with the following details:<br/>" +
                          "Application Ref. Number: " + model.ApplicationRefNo + "<br/>" +
                          "Program: " + model.ProgramCode + " - " + model.ProgramTitle + "<br/>" +
                          "School Year: " + model.SchoolYear + "<br/>" +
                          "Student Name: " + model.StudentGivenName + " " + model.StudentLastname + "<br/>" +
                          "Email: " + model.EmailAddress + "<br/>" +
                          "Contact Number: " + model.StudentPhoneCode1 + " " + model.StudentPhone1 + "<br/><br/>" +
                          "Whatsapp: " + model.StudentPhoneCode2 + " " + model.StudentPhone2 + "<br/><br/>" +
                          "To review and process the admission application, please click below link<br/>" +
                          "<a href='https://www.richmindale.com/admin/admissions/details/" + model.Id + "' target='_blank'>" + model.ApplicationRefNo + "</a>.<br/><br/>" +
                          "Richmindale Webmaster";

            // emailSender.SendMail("shimilalalala@gmail.com", subject, body);
            // emailSender.SendMail("admissions@richmindale.com", subject, body);
                            emailSender.SendMail("quoudoisseppanni-5052@yopmail.com", subject, body);


            //send mail to student if email address is not null or empty
            if (!string.IsNullOrEmpty(model.EmailAddress))
            {
                subject = "Admission Application Receipt - " + model.ApplicationRefNo;
                body = "Dear " + model.StudentGivenName + " " + model.StudentLastname + ",<br/><br/>" +
                       "This email confirms that you have successfully submitted your application for admission at <strong>Richmindale</strong> for " + model.TermName + ".<br/><br/>" +
                       "We'll review your application to make sure you have provided all of the information we asked for, uploaded all required documents, and paid the admission fees.<br/<br/>" +
                       "We'll send you a notification email of the admission application status to your registered email. Approval of the admission application takes a maximum of 10 business days from the " +
                       "date when all admission requirements are received.<br/><br/>" +
                       "Please note that we'll return your application to you if it is incomplete.<br/><br/><br/>" +
                       "Thank you,<br/><br/><br/>" +
                       "Richmindale<br/><br/><br/>" +
                       "This is an auto-generated mail message please do not reply.";

                emailSender.SendMail(model.EmailAddress, subject, body);
            }


            subject = "Admission Application Receipt - " + model.ApplicationRefNo;
            body = "Dear " + model.StudentGivenName + " " + model.StudentLastname + ",<br/><br/>" +
                   "This email confirms that you have successfully submitted your application for admission at <strong>Richmindale</strong> for " + model.TermName + ".<br/><br/>" +
                   "We'll review your application to make sure you have provided all of the information we asked for, uploaded all required documents, and paid the admission fees.<br/<br/>" +
                   "We'll send you a notification email of the admission application status to your registered email. Approval of the admission application takes a maximum of 10 business days from the " +
                   "date when all admission requirements are received.<br/><br/>" +
                   "Please note that we'll return your application to you if it is incomplete.<br/><br/><br/>" +
                   "Thank you,<br/><br/><br/>" +
                   "Richmindale<br/><br/><br/>" +
                   "This is an auto-generated mail message please do not reply.";


            emailSender.SendMail(model.EmailAddress, subject, body);

            using var conn = db.CreateConnection();
            var param = new DynamicParameters();
            param.Add("Id", model.Id, DbType.Guid);
            var sql = $@"UPDATE LrnAdmissionApplications SET Status=8 WHERE Id=@Id";
            return await conn.ExecuteAsync(sql, param);

        }
        public async Task<int> SubmitGradeLevelAdmissionApplication(AdmissionViewModel model)
        {
            // Registrar Email

            // var subject = "Admission Application Receipt - " + model.StudentLastname + ", " + model.StudentGivenName + (model.StudentMiddleName != string.Empty ? " " + model.StudentMiddleName.Substring(0, 1) : "; ");
            var subject = "Admission Application Receipt - " + model.StudentLastname + ", " + model.StudentGivenName + (!string.IsNullOrEmpty(model.StudentMiddleName) ? " " + model.StudentMiddleName.Substring(0, 1) + "." : "") + ";";
            var body = "Dear Registrar,<br/><br/>" +
                          "A new <strong>Admission Application</strong> has been submitted using Richmindale Website with the following details:<br/>" +
                          "Application Ref. Number: " + model.ApplicationRefNo + "<br/>" +
                          "Campus: " + model.CampusName + "<br/>" +
                          "Grade Level: " + model.ProgramCode + " - " + model.ProgramTitle + "<br/>" +
                          "School Year: " + model.SchoolYear + "<br/>" +
                          "Student Name: " + model.StudentGivenName + " " + model.StudentLastname + "<br/>" +
                          "Email: " + model.EmailAddress + "<br/>" +
                          "Contact Number: " + model.StudentPhoneCode1 + " " + model.StudentPhone1 + "<br/><br/>" +
                          "Whatsapp: " + model.StudentPhoneCode2 + " " + model.StudentPhone2 + "<br/><br/>" +
                          "To review and process the admission application, please click below link<br/>" +
                          "<a href='https://www.richmindale.me/admin/admissions/details/" + model.Id + "' target='_blank'>" + model.ApplicationRefNo + "</a>.<br/><br/>" +
                          "Richmindale Webmaster";
        
                          

            // emailSender.SendMail("info@richmindale.me", subject, body);
            emailSender.SendMail("quoudoisseppanni-5052@yopmail.com", subject, body);

            subject = "Admission Application Receipt - " + model.ApplicationRefNo;
            body = "Dear " + model.StudentGivenName + " " + model.StudentLastname + ",<br/><br/>" +
                   "This email confirms that you have successfully submitted your application for admission at <strong>Richmindale</strong> for " + model.SchoolYear + ".<br/><br/>" +
                   "We'll review your application to make sure you have provided all of the information we asked for, uploaded all required documents.<br/<br/>" +
                   "We'll send you a notification email of the admission application status to your registered email. Approval of the admission application takes a maximum of 10 business days from the " +
                   "date when all admission requirements are received.<br/><br/>" +
                   "Please note that we'll return your application to you if it is incomplete.<br/><br/><br/>" +
                   "Thank you,<br/><br/><br/>" +
                   "Richmindale<br/><br/><br/>" +
                   "This is an auto-generated mail message please do not reply.";


            emailSender.SendMail(model.EmailAddress, subject, body);

            using var conn = db.CreateConnection();
            var param = new DynamicParameters();
            param.Add("Id", model.Id, DbType.Guid);
            var sql = $@"UPDATE LrnAdmissionApplications SET Status=8 WHERE Id=@Id";
            return await conn.ExecuteAsync(sql, param);

        }
        public async Task UploadAdmissionDocuments(AdmissionDocsViewModel model)
        {
            var sql = $@"INSERT INTO LrnAdmissionDocs (LrnAdmissionApplicationId, SysDocumentTypeId, DocumentName, DocumentUrl, UploadDate) 
                         SELECT @LrnAdmissionApplicationId, @SysDocumentTypeId, @DocumentName, @DocumentUrl, GETDATE()";
            var param = new DynamicParameters();
            param.Add("LrnAdmissionApplicationId", model.LrnAdmissionApplicationId, DbType.Guid);
            param.Add("SysDocumentTypeId", model.DocumentTypeId, DbType.Int32);
            param.Add("DocumentName", model.DocumentName, DbType.String);
            param.Add("DocumentUrl", model.DocumentUrl, DbType.String);
            using var conn = db.CreateConnection();
            await conn.ExecuteScalarAsync(sql, param);
        }
        public async Task UpdateAdmissionPayment(AdmissionPaymentViewModel model)
        {

            if (model.Status != "error")
            {
               
                var subject = "Online Payment Receipt: " + model.PaymentRefNo;
                var body = "Dear " + model.StudentName + ",<br/><br/>" +
                        "We are pleased to acknowledge the receipt of your admission fee payment for Admission No.  " + model.ApplicationRefNo + " using our online payment " +
                        "with transaction number <strong>" + model.PaymentRefNo + "</strong>.<br/><br/>" +
                        "We will notify you for the next step of the admission process." +
                        "Thank you for choosing <strong>Richmindale</strong>. We look forward to potentially welcoming you into our school community. If you have any further questions or need assistance, please do not hesitate<br/><br/>" +
                        "Warm regards,<br/><br/>" +
                        "Richmindale<br/><br/><br/>" +
                        "This is an auto-generated mail message please do not reply.";

                emailSender.SendMail(model.EmailAddress, subject, body);

            
                body = "Dear Accounting,<br/><br/>" +
                        "An online payment has been made with the following details:<br/>" +
                        "Payment Ref. No.: " + model.PaymentRefNo + "<br/>" +
                        "Amount in USD: " + model.Amount + "<br/>" +
                        "Admission Ref. No. : " + model.ApplicationRefNo + "<br/>" +
                        "Student Name: " + model.StudentName + "<br/>" +
                        "Program Deatails: " + model.Program + "<br/><br/>" +
                        "Richmindale Webmaster";

                // emailSender.SendMail("finance@richmindale.com", subject, body);
                emailSender.SendMail("quoudoisseppanni-5052@yopmail.com", subject, body);


                var sql = $@"INSERT INTO FnPaypalPayments (Id, TransactionDate, TransactionNumber, EmailAddress, Fullname, PaymentFor, Amount, Currency, TransactionMessage, Status) " +
                            "SELECT NEWID(), GETDATE(), @TransactionNumber, @EmailAddress, @Fullname, @PaymentFor, @Amount, @Currency, @TransactionMessage, @Status";
                var par = new DynamicParameters();
                par.Add("TransactionNumber", model.PaymentRefNo, DbType.String);
                par.Add("EmailAddress", model.EmailAddress, DbType.String);
                par.Add("Fullname", model.StudentName, DbType.String);
                par.Add("PaymentFor", "Admission No. " + model.ApplicationRefNo, DbType.String);
                par.Add("Amount", model.Amount, DbType.Decimal);
                par.Add("Currency", "USD", DbType.String);
                par.Add("TransactionMessage", model.TransactionMessage, DbType.String);
                par.Add("Status", model.Status, DbType.String);
                using var conn = db.CreateConnection();
                await conn.ExecuteAsync(sql, par);


                sql = $@"UPDATE LrnAdmissionApplications 
                            SET Paid=1, PaymentMethod=115, PaymentRefNo=@PaymentRefNo, Amount=@Amount, PaymentDate=GETDATE() 
                            WHERE Id = @Id";
                var param = new DynamicParameters();
                param.Add("Id", model.Id, DbType.Guid);
                param.Add("PaymentRefNo", model.PaymentRefNo, DbType.String);
                param.Add("Amount", model.Amount, DbType.Decimal);
                await conn.ExecuteAsync(sql, param);


            }
            else
            {
                var sql = $@"INSERT INTO FnPaypalPayments (Id, TransactionDate, TransactionNumber, EmailAddress, Fullname, PaymentFor, Amount, Currency, TransactionMessage, Status) " +
                            "SELECT NEWID(), GETDATE(), @TransactionNumber, @EmailAddress, @Fullname, @PaymentFor, @Amount, @Currency, @TransactionMessage, @Status";
                var par = new DynamicParameters();
                par.Add("TransactionNumber", model.PaymentRefNo, DbType.String);
                par.Add("EmailAddress", model.EmailAddress, DbType.String);
                par.Add("Fullname", model.StudentName, DbType.String);
                par.Add("PaymentFor", "Admission No. " + model.ApplicationRefNo, DbType.String);
                par.Add("Amount", model.Amount, DbType.Decimal);
                par.Add("Currency", "USD", DbType.String);
                par.Add("TransactionMessage", model.TransactionMessage, DbType.String);
                par.Add("Status", model.Status, DbType.String);
                using var conn = db.CreateConnection();
                await conn.ExecuteAsync(sql, par);

            }


        }
        public async Task<IEnumerable<AdmissionDocsViewModel>> LoadAdmissionDocs(Guid id)
        {
            var sql = $@"EXEC sp_LoadAdmissionDocs @Id";
            var param = new DynamicParameters();
            param.Add("Id", id, DbType.Guid);
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<AdmissionDocsViewModel>(sql, param);
        }
        public async Task<IEnumerable<AgreementCoursesViewModel>> LoadAgreementCourses(int id)
        {
            var sql = $@"EXEC sp_LoadAgreementCourses @ProgramId";
            var param = new DynamicParameters();
            param.Add("ProgramId", id, DbType.Int32);

            using var conn = db.CreateConnection();
            return await conn.QueryAsync<AgreementCoursesViewModel>(sql, param);

        }

        // Updates for Grade Level Admission Process
        public async Task<IEnumerable<AdmissionStudentViewModel>> LoadAdmissionStudents(Guid id)
        {
            var sql = $@"EXEC sp_LoadAdmissionStudents @Id='" + id + "'";
            using var conn = db.CreateConnection();
            return await conn.QueryAsync<AdmissionStudentViewModel>(sql);
        }

        public async Task<AdmissionStudentViewModel> GetAdmissionStudentDetails(int id)
        {
            var sql = $@"EXEC sp_GetAdmissionStudentDetails @Id=" + id;
            using var conn = db.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<AdmissionStudentViewModel>(sql);
        }

        public async Task<int> SaveAdmissionStudent(AdmissionStudentViewModel model)
        {
            int id = 0;
            using var conn = db.CreateConnection();
            var sql = string.Empty;
            var param = new DynamicParameters();
            if (model.Id == 0)
            {
                sql = $@"INSERT INTO LrnAdmissionStudents
                             (AdmissionId, ProgramId, CampusId, LearningMethodId, SchoolYear) VALUES
                             (@AdmissionId, @ProgramId, @CampusId, LearningMethodId, SchoolYear)
                             SELECT IDENT_CURRENT('LrnAdmissionStudents') 
                        ";

                return await conn.QueryFirstOrDefaultAsync(sql);
            }
            else
            {
                sql = $@"UPDATE LrnAdmissionStudents 
                         SET
                            AdmissionId = @AdmissionId,
                            ProgramId = @ProgramId,
                            CampusId = @CampusId,
                            LearningMethodId = @LearningMethodId,
                            SchoolYear = @SchoolYear  
                        ";
                param.Add("AdmissionId", model.AdmissionId, DbType.Guid);
                param.Add("ProgramId", model.ProgramId, DbType.Int32);
                param.Add("CampusId", model.CampusId, DbType.Int32);
                param.Add("LearningMethodId", model.LearningMethodId, DbType.Int32);
                param.Add("SchoolYear", model.SchoolYear, DbType.String);

                // Student Details
                sql = sql + $@", StudentGivenName=@StudentGivenName
                               , StudentMiddleName=@StudentMiddleName
                               , StudentLastname=@StudentLastname
                               , StudentBirthdate=@StudentBirthdate
                               , StudentGender=@StudentGender
                               , StudentReligion=@StudentReligion
                               , StudentNationalilty=@StudentNationality
                               , StudetCountry=@StudentCountry
                               , StudentState=@StudentState
                               , StudentCity=@StudentCity
                               , StudentZipCode=@StudentZipCode
                               , StudentAddress=@StudentAddress
                               , StudentEmail1=@StudentEmail1
                               , StudentEmail2=@StudentEmail2
                               , StudentPhoneCode1=@StudentPhoneCode1
                               , StudentPhoe1=@StudentPhone1
                               , StudentPhoneCode2=@StudentPhoneCode2
                               , StudentPhone2=@StudentPhone2
                               ";
                param.Add("StudentGivenName", model.StudentGivenName, DbType.String);
                param.Add("StudentMiddleName", model.StudentMiddleName, DbType.String);
                param.Add("StudentLastname", model.StudentLastname, DbType.String);
                param.Add("StudenBirthdate", model.StudentBirthDate, DbType.DateTime);
                param.Add("StudentGender", model.StudentGender, DbType.String);
                param.Add("StudentReligion", model.StudentReligion, DbType.Int32);
                param.Add("StudentNationality", model.StudentNationality, DbType.Int32);
                param.Add("StudentCountry", model.StudentCountry, DbType.Int32);
                param.Add("StudentState", model.StudentState, DbType.Int32);
                param.Add("StudentCity", model.StudentCity, DbType.Int32);
                param.Add("StudentZipCode", model.StudentZipCode, DbType.String);
                param.Add("StudentAddress", model.StudentAddress, DbType.String);
                param.Add("StudentEmail1", model.StudentEmail1, DbType.String);
                param.Add("StudentEmail2", model.StudentEmail2, DbType.String);
                param.Add("StudentPhoneCode1", model.StudentPhoneCode1, DbType.String);
                param.Add("StudentPhone1", model.StudentPhone1, DbType.String);
                param.Add("StudentPhoneCode2", model.StudentPhoneCode2, DbType.String);
                param.Add("StudentPhone2", model.StudentPhone2, DbType.String);

                // Previous School
                sql = sql + $@", SchoolName=@SchoolName
                               , PreviousLrn=@PreviousLrn
                               , PreviousProgramId=@PreviousProgramId
                               , YearAttended=@YearAttended
                               , SchoolCountry=@SchoolCountry
                               , SchoolAddress=@SchoolAddress
                               , SchoolEmail=@SchoolEmail
                               , SchoolContact=@SchoolContact
                               , SchoolContactDesignation=@SchoolContactDesignation
                               , SchoolContactEmail=@SchoolContactEmail
                               , SchoolPhoneCode=@SchoolPhoneCode
                               , SchoolContactNumber=@SchoolContactNumber
                            ";
                param.Add("SchoolName", model.SchoolName, DbType.String);
                param.Add("PreviousLrn", model.PreviousLRN, DbType.String);
                param.Add("PreviousProgramId", model.PreviousProgramId, DbType.Int32);
                param.Add("YearAttended", model.YearAttended, DbType.String);
                param.Add("SchoolCountry", model.SchoolCountry, DbType.Int32);
                param.Add("SchoolAddress", model.SchoolAddress, DbType.String);
                param.Add("SchoolContact", model.SchoolContact, DbType.String);
                param.Add("SchoolContactDesignation", model.SchoolContactDesignation, DbType.String);
                param.Add("SchoolContactEmail", model.SchoolContactEmail, DbType.String);
                param.Add("SchoolContactPhoneCode", model.SchoolPhoneCode, DbType.String);
                param.Add("SchoolContatNumber", model.SchoolContactNumber, DbType.String);

                // Father Details
                sql = sql + $@", SkipFather=" + model.SkipFather + " ";
                if (!model.SkipFather)
                {
                    sql = sql + $@", FatherGivenName=@FatherGivenName
                                   , FatherMiddleName=@FatherMiddleName
                                   , FatherLastname=@FatherLastname
                                   , FatherBirthdate=@Fatherbirthdate
                                   , FatherMaritalStatus=@FatherMaritalStatus
                                   , FatherReligion=@FatherReligion
                                   , FatherNationality=@FatherNationality
                                   , FatherCountry=@FatherCountry
                                   , FatherState=@FatherState
                                   , FatherCity=@FatherCity
                                   , FatherZipCode==@FatherZipCode
                                   , FatherAddress=@FatherAddress
                                   , FatherEmail1=@FatherEmail1
                                   , FatherEmail2=@FatherEmail2
                                   , FatherPhoneCode1=@FatherPhoneCode1
                                   , FatherPhone1=@FatherPhone1
                                   , FatherPhoneCode2=@FatherPhoneCode2
                                   , FatherPhone2=@FatherPhone2
                                  ";
                    param.Add("FatherGivenName", model.FatherGivenName, DbType.String);
                    param.Add("FatherMiddleName", model.FatherMiddleName, DbType.String);
                    param.Add("FatherLastname", model.FatherLastname, DbType.String);
                    param.Add("FatherBirthdate", model.FatherBirthDate, DbType.String);
                    param.Add("FatherMaritalStatus", model.FatherMaritalStatus, DbType.Int32);
                    param.Add("FaTherReligion", model.FatherReligion, DbType.Int32);
                    param.Add("FatherNationality", model.FatherNationality, DbType.Int32);
                    param.Add("FatherCountry", model.FatherCountry, DbType.Int32);
                    param.Add("FatherState", model.FatherState, DbType.Int32);
                    param.Add("FatherCity", model.FatherCity, DbType.Int32);
                    param.Add("FatherZipCode", model.FatherZipCode, DbType.String);
                    param.Add("FatherAddress", model.FatherAddress, DbType.String);
                    param.Add("FatherEmail1", model.FatherEmail1, DbType.String);
                    param.Add("FatherEmail2", model.FatherEmail2, DbType.String);
                    param.Add("FatherPhonceCode1", model.FatherPhoneCode1, DbType.String);
                    param.Add("FatherPhone1", model.FatherPhone1, DbType.String);
                    param.Add("FatherPhoneCode2", model.FatherPhoneCode2, DbType.String);
                    param.Add("FatherPhone2", model.FatherPhone2, DbType.String);
                }

                // Mother Details
                sql = sql + $@", SkipMother=" + model.SkipMother + " ";
                if (!model.SkipMother)
                {
                    sql = sql + $@", MotherGivenName=@MotherGivenName
                                  , MotherMiddleName=@MotherMiddleName
                                  , MotherLastname=@MotherLastname
                                  , MotherMaidenName=@MotherMaidenName
                                  , MotherBirthdate=@MotherBirthdate
                                  , MotherMaritalStatus=@MotherMaritalStatus
                                  , MotherReligion=@MotherReligion
                                  , MotherNationality=@MotherNationality
                                  , MotherCountry=@MotherCountry
                                  , MotherState=@MotherState
                                  , MotherCity=@MotherCity
                                  , MotherZipCode=@MotherZipCode
                                  , MotherAddress=@MotherAddress
                                  , MotherEmail1=@MotherEmail1
                                  , MotherEmail2=@MotherEmail2
                                  , MotherPhoneCode1=@MotherPhoneCode1
                                  , MotherPhone1=@MotherPhone1
                                  , MotherPhoneCode2=@MotherPhoneCode2
                                  , MotherPhone2=@MotherPhone2
                                  ";
                    param.Add("MotherGivenName", model.MotherGivenName, DbType.String);
                    param.Add("MotherMiddleName", model.MotherMiddleName, DbType.String);
                    param.Add("MotherLastname", model.MotherLastname, DbType.String);
                    param.Add("MotherBirthdate", model.MotherBirthDate, DbType.String);
                    param.Add("MotherMaritalStatus", model.MotherMaritalStatus, DbType.Int32);
                    param.Add("MotherReligion", model.MotherReligion, DbType.Int32);
                    param.Add("MotherNationality", model.MotherNationality, DbType.Int32);
                    param.Add("MotherCountry", model.MotherCountry, DbType.Int32);
                    param.Add("MotherState", model.MotherState, DbType.Int32);
                    param.Add("MotherCity", model.MotherCity, DbType.Int32);
                    param.Add("MotherZipCode", model.MotherZipCode, DbType.String);
                    param.Add("MotherAddress", model.MotherAddress, DbType.String);
                    param.Add("MotherEmail1", model.MotherEmail1, DbType.String);
                    param.Add("MotherEmail2", model.MotherEmail2, DbType.String);
                    param.Add("MotherPhonceCode1", model.MotherPhoneCode1, DbType.String);
                    param.Add("MotherPhone1", model.MotherPhone1, DbType.String);
                    param.Add("MotherPhoneCode2", model.MotherPhoneCode2, DbType.String);
                    param.Add("MotherPhone2", model.MotherPhone2, DbType.String);
                }

                // Guardian Details
                sql = sql + $@", GuardiantypeId=@GuardianTypeId
                               , RelationshipId=@RelationshipId
                               , GuardianGivenName=@GuardianGivenName
                               , GuardianMiddleName=@GuardianMiddleName
                               , GuardianLastname=@GuardianLastname
                               , GuardianMaidenName=@GuardianMaidenname
                               , GuardianBirthdate=@GuardianBirthdate
                               , GuardianGender=@GuardianGender
                               , GuardianMaritalStatus=@GuardianMaritalStatus
                               , GuardianReligion=@GuardianReligion
                               , GuardianNationality=@GuardianNationality
                               , GuardianCountry=@GuardianCountry
                               , GuardianState=@GuardianState
                               , GuardianCity=@GuardianCity
                               , GuardianZipCode=@GuardianZipCode
                               , GuardianAddress=@GuardianAddress
                               , GuardianEmail1=@GuardianEmail1
                               , GuardianEmail2=@GuardianEmail2
                               , GuardianPhoneCode1=@GuardianPhoneCode1
                               , GuardianPhone1=@GuardianPhoned1
                               , GuardianPhoneCode2=@GuardianPhoneCode2
                               , GuardianPhone2=@GuardianPhone2
                               ";
                param.Add("GuardianTypeId", model.GuardianTypeId, DbType.Int32);
                param.Add("RelationshipId", model.RelationshipId, DbType.Int32);
                param.Add("GuardianGivenName", model.GuardianGivenName, DbType.String);
                param.Add("GuardianMiddleName", model.GuardianMiddleName, DbType.String);
                param.Add("GuardianLastname", model.GuardianLastname, DbType.String);
                param.Add("GuardianMaidenName", model.GuardianMaidenName, DbType.String);
                param.Add("GuardianBirthdate", model.GuardianBirthDate, DbType.String);
                param.Add("GuardianGender", model.GuardianGender, DbType.String);
                param.Add("GuardianMaritalStatus", model.GuardianMaritalStatus, DbType.Int32);
                param.Add("GuardianReligion", model.GuardianReligion, DbType.Int32);
                param.Add("GuardianNationality", model.GuardianNationality, DbType.Int32);
                param.Add("GuardianCountry", model.GuardianCountry, DbType.Int32);
                param.Add("GuardianState", model.GuardianState, DbType.Int32);
                param.Add("GuardianCity", model.GuardianCity, DbType.Int32);
                param.Add("GuardianZipCode", model.GuardianZipCode, DbType.String);
                param.Add("GuardianAddress", model.GuardianAddress, DbType.String);
                param.Add("GuardianEmail1", model.GuardianEmail1, DbType.String);
                param.Add("GuardianEmail2", model.GuardianEmail2, DbType.String);
                param.Add("GuardianPhoneCode1", model.GuardianPhoneCode1, DbType.String);
                param.Add("GuardianPhone1", model.GuardianPhone1, DbType.String);
                param.Add("GuardianPhoneCode2", model.GuardianPhoneCode2, DbType.String);
                param.Add("GuardianPhone2", model.GuardianPhone2, DbType.String);

                sql = sql + $@", Status = 32
                               WHERE Id=" + model.Id;

                return await conn.ExecuteAsync(sql);
            }


        }

        public async Task<int> UpdateAdmissionStudent(int id)
        {
            var sql = $@"UPDATE LrnAdmissionStudents SET Status=8 WHERE Id=" + id;
            using var conn = db.CreateConnection();
            return await conn.ExecuteAsync(sql);
        }

        // public Task<string> VerifyEmail(object emailAddress)
        // {
        //     throw new NotImplementedException();
        // }
    }
}
