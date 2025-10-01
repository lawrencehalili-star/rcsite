namespace richmindale_app.Server.Models.ViewModels
{
    public class UserMenuViewModel
    {
        public int SectionId { get; set; }
        public string? SectionTitle { get; set; }
        public string? SectionClass { get; set; }
        public string? SectionIcon { get; set; }
        public string? SubElementId { get; set; }
        public string? SectionUrl { get; set; }
        public IEnumerable<SubMenuViewModel>? SubMenu { get; set; }
   
    }

    public class SubMenuViewModel 
    {
        public int ModuleId { get; set; }
        public string? ModuleTitle { get; set; }
        public string? ModuleClass { get; set; }
        public string? TargetUrl { get; set; }
    }
}
