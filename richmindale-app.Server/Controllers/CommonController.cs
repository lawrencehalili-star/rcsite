using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Hosting;
using richmindale_app.Server.Repositories;

namespace richmindale_app.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {

        private readonly ICommonRepository service;

        public CommonController(ICommonRepository _service)
        {
            service = _service;
        }

        [HttpGet]
        [Route("GetCountries")]
        public async Task<JsonResult> GetCountries()
        {
            return new JsonResult(await service.GetCountryDropdown(), new JsonSerializerOptions());
        }


#region FOR US USED ONLY

        [HttpGet]
        [Route("GetUSCountry")]
        public async Task<JsonResult> GetUSCountry()
        {
            return new JsonResult(await service.GetUSCountry(), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetDegreeCategory")]
        public async Task<JsonResult> GetDegreeCategory()
        {
            return new JsonResult(await service.GetDegreeCategory(), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetUsLearningMethod")]
        public async Task<JsonResult> GetUsLearningMethod()
        {
            return new JsonResult(await service.GetUsLearningMethod(), new JsonSerializerOptions());
        }

#endregion

        [HttpGet]
        [Route("GetCampusCountries")]
        public async Task<JsonResult> GetCampusCountries()
        {
            return new JsonResult(await service.GetCampusCountries(), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetStatesByCountryId")]
        public async Task<JsonResult> GetStatesByCountryId(int? id)
        {
            return new JsonResult(await service.GetStateCityById("States", "StateName", "CountryId", Convert.ToInt32(id)), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetCitiesByStateId")]
        public async Task<JsonResult> GetCitiesByStateId(int? id)
        {
            return new JsonResult(await service.GetStateCityById("Cities", "CityName", "StateId", Convert.ToInt32(id)), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetCommonDropdown")]
        public async Task<JsonResult> GetCommonDropdown(string grp)
        {
            return new JsonResult(await service.GetCommonDropdown(grp), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetProgramsWithCode")]
        public async Task<JsonResult> GetProgramsWithCode(string grp)
        {
            return new JsonResult(await service.GetProgramsWithCode(grp), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetProgramByCategoryId")]
        public async Task<JsonResult> GetProgramByCategoryId(int id)
        {
            return new JsonResult(await service.GetProgramByCategoryId(id), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetCommonDropdownByParent")]
        public async Task<JsonResult> GetCommonDropdownByParent(int id)
        {
            return new JsonResult(await service.GetCommonDropdownByParent(id), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetStatusDropdown")]
        public async Task<JsonResult> GetStatusDropdown(string grp)
        {
            return new JsonResult(await service.GetStatusDropdown(grp), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetCampusByCountry")]
        public async Task<JsonResult> GetCampusByCountry(int? id)
        {
            return new JsonResult(await service.GetCampusByCountry(id), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetLearningMethods")]
        public async Task<JsonResult> GetLearningMethods()
        {
            return new JsonResult(await service.GetLearningMethods(), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetRelationships")]
        public async Task<JsonResult> GetRelationships()
        {
            return new JsonResult(await service.GetRelationships(), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetMaritalStatus")]
        public async Task<JsonResult> GetMaritalStatus()
        {
            return new JsonResult(await service.GetMaritalStatus(), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetReligions")]
        public async Task<JsonResult> GetReligions()
        {
            return new JsonResult(await service.GetReligions(), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetNationality")]
        public async Task<JsonResult> GetNationality()
        {
            return new JsonResult(await service.GetNationality(), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetPhoneCodes")]
        public async Task<JsonResult> GetPhoneCodes()
        {
            return new JsonResult(await service.GetPhoneCodes(), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetDocumentTypes")]
        public async Task<JsonResult> GetDocumentTypes()
        {
            return new JsonResult(await service.GetDocumentTypes(), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetDocumentAmount")]
        public async Task<JsonResult> GetDocumentAmount(int id)
        {
            return new JsonResult(await service.GetDocumentAmount(id), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetAvailableCoursesByProgram")]
        public async Task<JsonResult> GetAvailableCoursesByProgram(int id)
        {
            return new JsonResult(await service.GetAvailableCoursesByProgram(id), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetProgramsByCategoryId")]
        public async Task<JsonResult> GetProgramsByCategoryId(int? id)
        {
            return new JsonResult(await service.GetProgramsByCategoryId(id), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetGradeLevelPrograms")]
        public async Task<JsonResult> GetGradeLevelPrograms()
        {
            return new JsonResult(await service.GetGradeLevelPrograms(), new JsonSerializerOptions());

        }

        [HttpGet]
        [Route("GetGradeLevelPeriods")]
        public async Task<JsonResult> GetGradeLevelPeriods()
        {
            return new JsonResult(await service.GetGradeLevelPeriods(), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetGradeLevelCampuses")]
        public async Task<JsonResult> GetGradeLevelCampuses()
        {
            return new JsonResult(await service.GetGradeLevelCampuses(), new JsonSerializerOptions());
        }
        [HttpGet]
        [Route("GetGradeLevelCredentials")]
        public async Task<JsonResult> GetGradeLevelCredentials()
        {
            return new JsonResult(await service.GetGradeLevelCredentials(), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetCoursesByTermsProgram")]
        public async Task<JsonResult> GetCoursesByTermsProgram(string terms, int program)
        {
            return new JsonResult(await service.GetCoursesByTermsProgram(terms, program), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("LoadUploadedCourses")]
        public async Task<JsonResult> LoadUploadedCourses(string? search)
        {
            return new JsonResult(await service.LoadUploadedCourses(search), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetProgramDetails")]
        public async Task<JsonResult> GetProgramDetails(int id)
        {
            return new JsonResult(await service.GetProgramDetails(id), new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("GetProgramWithDetails")]
        public async Task<JsonResult> GetProgramWithDetails()
        {
            return new JsonResult(new {data = await service.GetProgramWithDetails()}, new JsonSerializerOptions());
        }

        [HttpGet]
        [Route("LoadProgramSemesterCourses")]
        public async Task<JsonResult> LoadProgramSemesterCourses(int id)
        {
            return new JsonResult(new { data = await service.LoadProgramSemesterCourses(id)}, new JsonSerializerOptions());
        }

    }
}
