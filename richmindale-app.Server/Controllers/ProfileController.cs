using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using richmindale_app.Server.Repositories;

namespace richmindale_app.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        private readonly IProfileRepository service;

        public ProfileController(IProfileRepository _service)
        {
            service = _service;
        }

        [HttpGet]
        [Route("GetStudentProfile")]
        public async Task<JsonResult> GetStudentProfile(Guid id)
        {
            return new JsonResult(await service.GetStudentProfile(id), new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("UpdatePassword")]
        public async Task<JsonResult> UpdatePassword(Guid id, string pass)
        {
            try
            {
                await service.UpdatePassword(id, pass);
                return new JsonResult(new {status = "success", msg = "Password successfully updated!"} , new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "Unable to update password due to error. ERROR: " + ex.Message.ToString() } , new JsonSerializerOptions());
            }
        }

    }
}
