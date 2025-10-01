using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using richmindale_app.Server.Repositories;
using richmindale_app.Server.Models.ViewModels;
using richmindale_app.Server.Models.StoredProcedures;
using System.Text.Json;

namespace richmindale_app.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolAdminController : ControllerBase
    {
        private readonly ISchoolAdminRepository service;

        public SchoolAdminController(ISchoolAdminRepository _service)
        {
            service = _service;
        }

        [HttpPost]
        [Route("LoadAllAdmissionRequests")]
        public async Task<JsonResult> LoadAllAdmissionRequests(FilterViewModel model)
        {
            return new JsonResult(new {data = await service.LoadAllAdmissionRequests(model)}, new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("LoadCollegeAdmissionRequests")]
        public async Task<JsonResult> LoadCollegeAdmissionRequests(FilterViewModel model)
        {
            return new JsonResult(new {data = await service.LoadCollegeAdmissionRequests(model)}, new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("LoadGradeLevelAdmissionRequests")]
        public async Task<JsonResult> LoadGradeLevelAdmissionRequests(FilterViewModel model)
        {
            return new JsonResult(new {data = await service.LoadGradeLevelAdmissionRequests(model)}, new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("LoadAdmissionSummaryDetails")]
        public async Task<JsonResult> LoadAdmissionSummaryDetails(Guid id)
        {
            return new JsonResult(await service.LoadAdmissionSummaryDetails(id), new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("UpdateAdmissionStatus")]
        public async Task<JsonResult> UpdateAdmissionStatus(Guid id, int status, string? reason)
        {
            try
            {
                await service.UpdateAdmissionStatus(id, status, reason);
                return new JsonResult(new {status = "success", msg = "Admission status successfully updated!"}, new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "Unable to update Admission Status due to error. ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }

        [HttpGet]
        [Route("LoadAgreementCourses")]
        public async Task<JsonResult> LoadAgreementCourses(int id)
        {
            return new JsonResult(await service.LoadAgreementCourses(id), new JsonSerializerOptions());
        }


    }
}
