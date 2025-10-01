namespace richmindale_app.Server.Models.ViewModels.ExpenseTracker
{
    public class ExpenseViewModel
    {
        public Guid? Id { get; set; }
        public string? ExpenseDate { get; set; }
        public string? TransactionDate { get; set; }
        public int? ActivityId { get; set; }
        public int? AssetId { get; set; }
        public int? LocationId { get; set; }
        public decimal? CreditAmount { get; set; }
        public decimal? DebitAmount { get; set; }
        public decimal? Amount { get; set; }
        public bool? IsDebit { get; set; }
        public int? CurrencyId { get; set; }
        public int? BankId { get; set; }
        public int? BankAccountId { get; set; }
        public string? AccountNumber { get; set; }
        public string? ShortComments { get; set; }
        public string? Comments { get; set; }
        public Guid? UserId { get; set; }

    }
}