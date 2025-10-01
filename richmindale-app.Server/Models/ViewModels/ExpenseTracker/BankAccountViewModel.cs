namespace richmindale_app.Server.Models.ViewModels.ExpenseTracker
{
    public class BankAccountViewModel
    {
        public int? Id { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountName { get; set; }
        public int? BankId { get; set; }
        public string? BankCode { get; set; }
        public string? BankName { get; set; }
        public string? Branch { get; set; }

    }
}