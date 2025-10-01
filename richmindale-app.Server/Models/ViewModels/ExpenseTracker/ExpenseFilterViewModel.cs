namespace richmindale_app.Server.Models.ViewModels.ExpenseTracker
{
    public class ExpenseFilterViewModel
    {
        public Guid? UserId { get; set; }
        public string? Search { get; set; }
        public string? SortName { get; set; }
        public string? SortDirection { get; set; }
        public int? StartIndex { get; set; }
        public int? PageSize { get; set; }

    }
}