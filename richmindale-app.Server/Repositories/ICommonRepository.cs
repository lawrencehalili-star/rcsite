using richmindale_app.Server.Models.ViewModels;

namespace richmindale_app.Server.Repositories
{
    public interface ICommonRepository
    {
        Task<IEnumerable<CommonDropdownModel>> GetCountryDropdown();
        Task<IEnumerable<CommonDropdownModel>> GetCampusCountries();

   #region FOR US ONLY
        Task<IEnumerable<CommonDropdownModel>> GetUSCountry();
        Task<IEnumerable<CommonDropdownModel>> GetDegreeCategory();
        Task<IEnumerable<CommonDropdownModel>> GetUsLearningMethod();
        
    #endregion
        Task<IEnumerable<CommonDropdownModel>> GetStateCityById(string tbl, string textCol, string? cond,  int id);
        Task<IEnumerable<CommonDropdownModel>> GetCommonDropdown(string grp);
        Task<IEnumerable<CommonDropdownModel>> GetProgramsWithCode(string grp);
        Task<IEnumerable<CommonDropdownModel>> GetProgramByCategoryId(int? id);
        Task<IEnumerable<CommonDropdownModel>> GetGradeLevelPrograms();
        Task<IEnumerable<CommonDropdownModel>> GetGradeLevelPeriods();
        Task<IEnumerable<CommonDropdownModel>> GetGradeLevelCampuses();
        Task<IEnumerable<CommonDropdownModel>> GetGradeLevelCredentials();
        Task<IEnumerable<CommonDropdownModel>> GetCommonDropdownByParent(int? id);
        Task<IEnumerable<CommonDropdownModel>> GetStatusDropdown(string grp);
        Task<IEnumerable<CommonDropdownModel>> GetCampusByCountry(int? id);
        Task<IEnumerable<CommonDropdownModel>> GetLearningMethods();
        Task<IEnumerable<CommonDropdownModel>> GetRelationships();
        Task<IEnumerable<CommonDropdownModel>> GetMaritalStatus();
        Task<IEnumerable<CommonDropdownModel>> GetReligions();
        Task<IEnumerable<CommonDropdownModel>> GetNationality();
        Task<IEnumerable<CommonDropdownModel>> GetPhoneCodes();
        Task<IEnumerable<CommonDropdownModel>> GetDocumentTypes();
        Task<decimal> GetDocumentAmount(int id);
        Task<IEnumerable<CommonDropdownModel>> GetProgramsByCategoryId(int? id);
        Task<IEnumerable<CommonDropdownModel>> GetAvailableCoursesByProgram(int? id);
        Task<IEnumerable<CommonDropdownModel>> GetCoursesByTermsProgram(string? terms, int program);
        Task<IEnumerable<UploadedCoursesDetailViewModel>> LoadUploadedCourses(string? search);
        Task<ProgramCoursesViewModel> GetProgramDetails(int id);
        Task<IEnumerable<ProgramCoursesViewModel>> GetProgramWithDetails();
        Task<IEnumerable<CoursesDetailsViewModel>> LoadProgramSemesterCourses(int id);
    }

}
