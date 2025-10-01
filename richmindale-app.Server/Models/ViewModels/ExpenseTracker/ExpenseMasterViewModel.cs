namespace richmindale_app.Server.Models.ViewModels.ExpenseTracker
{
    public class ExpenseMasterViewModel
    {
        public Guid Id { get;  set; }
        public string? ExpenseCode { get; set; }
        public int? ActivityId { get; set; }
        public string? ActivityName { get; set; }
        public int? LocationId { get; set; }
        public string? LocationName { get; set; }
        public int? AssetId { get; set; }
        public string? AssetName { get; set; }
        public decimal? CreditAmount { get; set; }
        public decimal? DebitAmount { get; set; }
        public decimal? Amount { get; set; }
        public bool? IsDebit { get; set; }
        public int? CurrencyId { get; set; }
        public string? Currency { get; set; }
        public string? CurrencyName { get; set; }
        public string? CurrencySymbol { get; set; }
        public string? Emoji { get; set; }
        public string? EmojiUI { get; set; }
        public int? BankId { get; set; }
        public string? BankCode { get; set; }
        public string? BankName { get; set; }
        public string? Branch { get; set; }
        public int? BankAccountId { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountName { get; set; }
        public string? ExpenseDate { get; set; }
        public string? TransactionDate { get; set; }
        public string? Comments { get; set; }
        public string? ShortComments { get; set; }

    }

}