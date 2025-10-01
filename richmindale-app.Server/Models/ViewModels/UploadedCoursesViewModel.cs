namespace richmindale_app.Server.Models.ViewModels
{
    public class UploadedCoursesViewModel
    {
        public int? Id { get; set; }
        public string? Filename { get; set; }
        public int? NoOfRecords { get; set; }
        public DateTime DateUploaded { get; set; }
        public string? Remarks { get; set; }
        public bool? IsSuccess { get; set;}
        public List<UploadedCoursesDetailViewModel>? UploadedCoursesDetails { get; set; }
    }
}