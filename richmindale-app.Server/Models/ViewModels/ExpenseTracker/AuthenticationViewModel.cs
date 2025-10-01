namespace richmindale_app.Server.Models.ViewModels.ExpenseTracker
{

    public class AuthenticationViewModel
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? DisplayName { get; set; }
        public Guid? RoleId { get; set; }
        public string? RoleName { get; set; }
        public int? IsAdmin { get; set; }
    }
}