namespace richmindale_app.Server.Models.ViewModels
{
    public class FilterViewModel
    {
        public string? Search { get; set; }
        public string? SortName { get; set; }
        public string? SortDirection { get; set; }
        public int? StartIndex { get; set; }
        public int? PageSize { get; set; }
    }
}