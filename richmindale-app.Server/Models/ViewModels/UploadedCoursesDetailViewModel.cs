namespace richmindale_app.Server.Models.ViewModels
{
    public class UploadedCoursesDetailViewModel
    {
        public int? Id { get; set; }
        //public int? UploadedCourseId { get; set; }
        public string? CourseCode   { get; set; }
        public string? RevNo    { get; set; }
        public DateTime? RevDate { get; set; }
        public string? CourseTitle { get; set; }
        public string? CourseDescription { get; set; }
        public string? PreRequisite { get; set; }
        public decimal? Credits { get; set; }
        public string? Programs { get; set; }
        public decimal? Tuition { get; set;}
        public decimal? Miscellaneous { get; set; }
    }
}