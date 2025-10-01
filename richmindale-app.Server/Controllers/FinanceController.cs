using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using richmindale_app.Server.Repositories;

namespace richmindale_app.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceController : ControllerBase
    {

        private readonly IFinanceRepository service;

        public FinanceController(IFinanceRepository _service)
        {
            service = _service;
        }

        [HttpGet]
        [Route("LoadPaypalPaymentTransactions")]
        public async Task<JsonResult> LoadPaypalPaymentTransactions()
        {
            return new JsonResult(await service.LoadPaypalPaymentTransactions(), new JsonSerializerOptions());
        }
    }
}
