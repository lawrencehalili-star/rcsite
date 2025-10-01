namespace richmindale_app.Server.Models.ViewModels
{
    public class UserInfoViewModel
    {
        public Guid Id { get; set; }
        public string? DisplayName { get; set; }
        public Guid? StudentId { get; set; }
        public Guid RoleId { get; set; }
        public string? RoleName { get; set;  }
        public int? CurrentCampusId { get; set; }
        public int? CurrentProgramId { get; set; }

    }
}