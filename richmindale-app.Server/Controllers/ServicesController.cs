using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using richmindale_app.Server.Models.ViewModels;
using richmindale_app.Server.Repositories;

namespace richmindale_app.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {

        private readonly IServicesRepository service;

        public ServicesController(IServicesRepository _service)
        {
            service = _service;
        }

        [HttpGet]
        [Route("LoadStudentDocumentRequest")]
        public async Task<JsonResult> LoadStudentDocumentRequest(Guid id)
        {
            return new JsonResult(new {data = await service.LoadStudentDocumentRequest(id)}, new JsonSerializerOptions());
        }

        [HttpPost]
        [Route("SaveDocumentRequest")]
        public async Task<JsonResult> SaveDocumentRequest(DocumentRequestViewModel model)
        {
            try
            {
                await service.SaveDocumentRequest(model);
                return new JsonResult(new {status = "success", msg = "Request successfully submitted for review."}, new JsonSerializerOptions());
               
            }
            catch(Exception ex)
            {
                return new JsonResult(new {status = "error", msg = "An error occured while saving your request. ERROR: " + ex.Message.ToString()}, new JsonSerializerOptions());
            }
        }

    }
}
