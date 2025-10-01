namespace richmindale_app.Server.Model.ViewModels.ExpenseTracker
{
    public class PasswordResetViewModel
    {
        public string? Username { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Message { get; set; }
    }

}