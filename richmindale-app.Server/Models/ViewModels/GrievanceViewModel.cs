namespace richmindale_app.Server.Models.ViewModels
{
    public class GrievanceViewModel
    {
        public Guid? Id { get; set; }
        public string? GrievanceCode { get; set; }
        public int? CategoryId { get; set; }
        public string? EmailAddress { get; set; }
        public string? Complainant { get; set; }
        public bool HideComplainant { get; set; }
        public string? Respondents { get; set; }
        public string? Message { get; set; }
    }
}