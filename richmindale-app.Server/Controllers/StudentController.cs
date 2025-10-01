using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using richmindale_app.Server.Repositories;

namespace richmindale_app.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentRepository service;

        public StudentController(IStudentRepository _service)
        {
            service = _service;
        }

        [HttpGet]
        [Route("LoadReportCardDetails")]
        public async Task<JsonResult> LoadReportCardDetails(Guid StudentId)
        {
            return new JsonResult(await service.LoadReportCardDetails(StudentId), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("LoadStudentPaypalPayments")]
        public async Task<JsonResult> LoadStudentPaypalPayments(Guid id)
        {
            return new JsonResult(await service.LoadStudentPaypalPayments(id), new JsonSerializerOptions());
        }

    }
}
