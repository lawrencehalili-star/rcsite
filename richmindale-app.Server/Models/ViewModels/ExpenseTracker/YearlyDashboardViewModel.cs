namespace richmindale_app.Server.Models.ViewModels.ExpenseTracker
{
    public class YearlyDashboardViewModel
    {
        public string? TransactionType { get; set; }
        public int? TransactionYear { get; set; }
        public decimal? January { get; set; }
        public decimal? February  { get; set; }
        public decimal? March  { get; set; }
        public decimal? April  { get; set; }
        public decimal? May  { get; set; }
        public decimal? June  { get; set; }
        public decimal? July { get; set; }
        public decimal? August { get; set; }
        public decimal? September { get; set; }
        public decimal? October { get; set; }
        public decimal? November { get; set; }
        public decimal? December  { get; set; }

    }
}