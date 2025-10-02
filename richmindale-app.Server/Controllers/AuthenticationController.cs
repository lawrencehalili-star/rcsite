using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using richmindale_app.Server.Repositories;
using richmindale_app.Server.Helpers;
namespace richmindale_app.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication service;

        public AuthenticationController(IAuthentication _service)
        {
            service = _service;
        }

        [HttpPost]
        [Route("AuthenticateAdmin")]
        public async Task<JsonResult> AuthenticateAdmin(string username, string password)
        {
            try
            {
               return new JsonResult(new {status = "success", info = await service.AuthenticateAdmin(username, password), msg = ""}, new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "An error occured while authenticating admin. ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }

        // [HttpPost]
        // [Route("AuthenticateStudent")]
        // public async Task<JsonResult> AuthenticateStudent(string? username)
        // {
        //     try
        //     {
        //        return new JsonResult(new {status = "success", passkey = await service.AuthenticateStudent(username), msg = "Passkey was sent to your registered email to access the portal."}, new JsonSerializerOptions());
        //     }
        //     catch(Exception ex)
        //     {
        //         return new JsonResult(new {status = "error", msg = "An error occured while authenticating student. ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
        //     }
        // }

        [HttpPost]
        [Route("AuthenticateStudent")]
        public async Task<JsonResult> AuthenticateStudent(string? username)
        {
            try
            {
                // Add logging
                Console.WriteLine($"Attempting to authenticate student: {username}");

                if (string.IsNullOrEmpty(username))
                {
                    return new JsonResult(new { status = "error", msg = "Username is required" }, new JsonSerializerOptions());
                }

                var passkey = await service.AuthenticateStudent(username);

                Console.WriteLine($"Passkey generated successfully");

                return new JsonResult(new { status = "success", passkey = passkey, msg = "Passkey was sent to your registered email to access the portal." }, new JsonSerializerOptions());
            }
            catch (Exception ex)
            {
                // Log the full exception with stack trace
                Console.WriteLine($"Full Error: {ex.ToString()}");
                return new JsonResult(new { status = "error", msg = "An error occured while authenticating student. ERROR: " + ex.Message.ToString(), stackTrace = ex.StackTrace }, new JsonSerializerOptions());
            }
        }

        [HttpPost]
        [Route("ValidatePasskey")]
        public async Task<JsonResult> ValidatePasskey(string username, string passkey)
        {
            try
            {
                return new JsonResult(new {status = "success", info = await service.ValidatePasskey(username, passkey), msg = "Successfully authenticated."}, new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "An error occured while authenticating student. ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }
    
        [HttpGet]
        [Route("GetUserInfo")]
        public async Task<JsonResult> GetUserInfo(Guid id)
        {
            return new JsonResult(await service.GetUserInfo(id), new JsonSerializerOptions());
        }
    }
}
