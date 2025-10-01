using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using richmindale_app.Server.Models.ViewModels;
using richmindale_app.Server.Repositories;

namespace richmindale_app.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrarController : ControllerBase
    {

        private readonly IRegistrarRepository service;

        public RegistrarController(IRegistrarRepository _service)
        {
            service = _service;
        }

        [HttpPost]
        [Route("LoadPaginatedMasterlist")]
        public async Task<JsonResult> LoadPaginatedMasterlist(FilterViewModel model)
        {
            return new JsonResult(new { data = await service.LoadPaginatedMasterlist(model)}, new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("LoadAllAdmissionRequests")]
        public async Task<JsonResult> LoadAllAdmissionRequests(FilterViewModel model)
        {
            return new JsonResult(new {data = await service.LoadAllAdmissionRequests(model)}, new JsonSerializerOptions());
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
                return new JsonResult(new {status = "success", msbg = "Admission status successfully updated!"}, new JsonSerializerOptions());
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "Unable to update Admission Status due to error. ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }


    }
}
