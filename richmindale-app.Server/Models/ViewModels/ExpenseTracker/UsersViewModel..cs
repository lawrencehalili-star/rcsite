namespace richmindale_app.Server.Models.ViewModels.ExpenseTracker
{
    public class UsersViewModel
    {
        public Guid? Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? DisplayName { get; set; }
        public string? EmailAddress { get; set; }
        public string? MobileNumber { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public Guid? RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? LastLoginTime { get; set; }
        public string? Status { get; set; }
        public bool? IsAdmin { get; set; }
    }
}