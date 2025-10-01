using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using richmindale_app.Server.Helpers;
using richmindale_app.Server.Models.ViewModels;
using richmindale_app.Server.Repositories;

namespace richmindale_app.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController : ControllerBase
    {

        private readonly IPublicRepository service;

        public PublicController(IPublicRepository _service)
        {
            service = _service;
        }

        [HttpPost]
        [Route("VerifyEmail")]
        public async Task<JsonResult> VerifyEmail(string EmailAddress)
        {
            try
            {
               string code =  await service.VerifyEmail(EmailAddress);
               if(code.Length > 8)
               {
                    return new JsonResult(new {status = "error", msg = code}, new JsonSerializerOptions());
               }
               else
               {
                    return new JsonResult(new {status = "success", passkey = code, msg = "Passkey was sent to your provided email for verification."}, new JsonSerializerOptions());
               }
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }

        [HttpPost]
        [Route("ValidatePasskey")]
         public async Task<JsonResult> ValidatePasskey(string email, string passkey)
        {
            try
            {
                string stat = await service.ValidatePasskey(email, passkey);
                if(stat == "success")
                {
                    return new JsonResult(new {status = stat, msg = "Successfully verified."}, new JsonSerializerOptions());
                }
                else
                {
                    return new JsonResult(new {status = stat, msg = stat}, new JsonSerializerOptions());
                }
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }

        [HttpPost]
        [Route("SubmitGrievance")]
        public async Task<JsonResult> SubmitGrievance(GrievanceViewModel model)
        {
            try
            {
                await service.SubmitGrievance(model);
                return new JsonResult(new {status = "success", msg = "Grievance Report successfully submitted for review and investigation."}, new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "Unable to process your Grievance Report due to error. ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }

        [HttpPost]
        [Route("SaveEnrollmentRequest")]
        public async Task<JsonResult> SaveEnrollmentRequest(EnrollmentRequestViewModel model)
        {
            try
            {
                await service.SaveEnrollmentRequest(model);
                return new JsonResult(new {status = "success", msg = "Enrollment request successfully saved."}, new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "Unable to save enrollment request due to error. ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }

        [HttpPost]
        [Route("SendMultipleEmails")]
        public async Task<JsonResult> SendMultipleEmails(string Sender, string[] SendTo, string Subject, string Body)
        {
            try
            {
                EmailSender mail = new EmailSender();
                mail.SendBulkMail(Sender, SendTo, Subject, Body);
                return new JsonResult(new {status = "success", msg = "Mail successfully delivered."}, new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "unable to send mail due to error. ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }

        [HttpPost]
        [Route("SavePaypalPayment")]
        public async Task<JsonResult> SavePaypalPayment(PaypalPaymentsViewModels model)
        {
            try 
            {
                await service.SavePaypalPayment(model);
                return new JsonResult(new {status = "success", msg = "Paypal Payment successfuly submitted."}, new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "unable to send mail due to error. ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }

    }
}
