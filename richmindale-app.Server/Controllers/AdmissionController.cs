using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using richmindale_app.Server.Models.ViewModels;
using richmindale_app.Server.Repositories;
using richmindale_app.Server.Helpers;

namespace richmindale_app.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionController : ControllerBase
    {
        private readonly IAdmission service;
        private readonly IEmailSender _emailSender;

        public AdmissionController(IAdmission Service, IEmailSender emailSender)
        {
            this.service = Service;
            this._emailSender = emailSender;
        }

        [HttpPost]
        [Route("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail([FromBody] EmailAddress model)
        {
            try
            {
                string code = await service.VerifyEmail(model.Email); 
                if (code.Length < 8)
                {
                    return new JsonResult(new { status = "error", msg = code }, new JsonSerializerOptions());
                }
                else
                {
                    string subject = "Richmindale Email Verification";
                    string body = $"<p>Your verification code is:</p><h2>{code}</h2>";

                    _emailSender.SendMail(model.Email, subject, body); 

                    return new JsonResult(new
                    {
                        status = "success",
                        passkey = code,
                        msg = "Passkey was sent to your provided email for verification."
                    }, new JsonSerializerOptions());
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { status = "error", msg = ex.Message.ToString() }, new JsonSerializerOptions());
            }
        }

        [HttpPost]
        [Route("ValidatePasskey")]
        public async Task<JsonResult> ValidatePasskey(string email, string passkey)
        {
            try
            {
                string stat = await service.ValidatePasskey(email, passkey);
                if (stat == "success")
                {
                    return new JsonResult(new { status = stat, msg = "Successfully verified." }, new JsonSerializerOptions());
                }
                else
                {
                    return new JsonResult(new { status = stat, msg = stat }, new JsonSerializerOptions());
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { status = "error", msg = ex.Message.ToString() }, new JsonSerializerOptions());
            }
        }

        [HttpPost]
        [Route("VerifyApplication")]
        public async Task<JsonResult> VerifyApplication(AdmissionVerificationModel model)
        {
            try
            {
                return new JsonResult(new { status = "success", id = await service.VerifyApplication(model), msg = "Application successfuly created" }, new JsonSerializerOptions());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { status = "success", msg = "Unable to create Admission Application due to error. ERROR: " + ex.Message.ToString() }, new JsonSerializerOptions());
            }
        }

        [HttpGet]
        [Route("LoadAdmissionSummaryDetails")]
        public async Task<JsonResult> LoadAdmissionSummaryDetails(Guid id)
        {
            return new JsonResult(await service.LoadAdmissionSummaryDetails(id), new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("UpdateAdmissionApplication")]
        public async Task<JsonResult> UpdateAdmissionApplication(AdmissionViewModel model)
        {
            try
            {
                if (await service.UpdateAdmissionApplication(model) > 0)
                {
                    return new JsonResult(new { status = "success", msg = "Successfully updated." }, new JsonSerializerOptions());
                }
                else
                {
                    return new JsonResult(new { status = "error", msg = "No changes has been made." }, new JsonSerializerOptions());
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { status = "error", msg = "Unable to update Admission Application due to error. ERROR: " + ex.Message.ToString() }, new JsonSerializerOptions());
            }
        }

        [HttpPost]
        [Route("UpdateGradeLevelAdmissionApplication")]
        public async Task<JsonResult> UpdateGradeLevelAdmissionApplication(AdmissionViewModel model)
        {
            try
            {
                await service.UpdateGradeLevelAdmissionApplication(model);
                return new JsonResult(new { status = "success", msg = "Successfully updated." }, new JsonSerializerOptions());

            }
            catch (Exception ex)
            {
                return new JsonResult(new { status = "error", msg = "Unable to update Admission Application due to error. ERROR: " + ex.Message.ToString() }, new JsonSerializerOptions());
            }
        }

        [HttpPost]
        [Route("SubmitAdmissionApplication")]
        public async Task<JsonResult> SubmitAdmissionApplication(AdmissionViewModel model)
        {
            try
            {
                if (await service.SubmitAdmissionApplication(model) > 0)
                {
                    return new JsonResult(new { status = "success", msg = "Successfully submitted." }, new JsonSerializerOptions());
                }
                else
                {
                    return new JsonResult(new { status = "error", msg = "No changes has been made." }, new JsonSerializerOptions());
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { status = "error", msg = "Unable to Submit Admission Application due to error. ERROR: " + ex.Message.ToString() }, new JsonSerializerOptions());
            }
        }

        [HttpPost]
        [Route("UpdateAdmissionPayment")]
        public async Task<JsonResult> UpdateAdmissionPayment(AdmissionPaymentViewModel model)
        {
            try
            {
                await service.UpdateAdmissionPayment(model);
                return new JsonResult(new { status = "success", msg = "Admission payment successfully submitted." }, new JsonSerializerOptions());

            }
            catch (Exception ex)
            {
                return new JsonResult(new { status = "error", msg = "Unable to Submit Admission Payment details due to error. ERROR: " + ex.Message.ToString() }, new JsonSerializerOptions());
            }
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadAdmissionFiles")]
        public async Task<JsonResult> UploadAdmissionFiles(AdmissionDocsViewModel model)
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var folderName = Path.Combine("Admissions", "Uploads/" + model.LrnAdmissionApplicationId.ToString());
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName?.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    model.DocumentUrl = dbPath;
                    await service.UploadAdmissionDocuments(model);
                    return new JsonResult(new { status = "success", msg = "Successfully uploaded." }, new JsonSerializerOptions());
                }
                else
                {
                    return new JsonResult(new { status = "error", msg = "No selected file to upload." }, new JsonSerializerOptions());
                }


            }
            catch (Exception ex)
            {
                return new JsonResult(new { status = "error", msg = "Unable to upload file(s) due to error. ERROR: " + ex.Message.ToString() }, new JsonSerializerOptions());
            }
        }

        [HttpGet]
        [Route("LoadAdmissionDocs")]
        public async Task<JsonResult> LoadAdmissionDocs(Guid id)
        {
            return new JsonResult(new { data = await service.LoadAdmissionDocs(id) }, new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("LoadAdmissionStudents")]
        public async Task<JsonResult> LoadAdmissionStudents(Guid id)
        {
            return new JsonResult(new { data = await service.LoadAdmissionStudents(id) }, new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetAdmissionStudentDetails")]
        public async Task<JsonResult> GetAdmissionStudentDetails(int id)
        {
            return new JsonResult(await service.GetAdmissionStudentDetails(id), new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("SaveAdmissionStudent")]
        public async Task<JsonResult> SaveAdmissionStudent(AdmissionStudentViewModel model)
        {
            try
            {
                await service.SaveAdmissionStudent(model);
                return new JsonResult(new { status = "success", msg = "Admission Student Successfully added." }, new JsonSerializerOptions());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { status = "error", msg = "Unable to save admissio student due to error. ERROR: " + ex.Message.ToString() }, new JsonSerializerOptions());
            }
        }

        [HttpPost]
        [Route("UpdateAdmissionStudent")]
        public async Task<JsonResult> UpdateAdmissionStudent(int id)
        {
            try
            {
                await service.UpdateAdmissionStudent(id);
                return new JsonResult(new { }, new JsonSerializerOptions());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { status = "error", msg = "Unable to update student details due to error. ERROR: " + ex.Message.ToString() }, new JsonSerializerOptions());
            }
        }
    }
}