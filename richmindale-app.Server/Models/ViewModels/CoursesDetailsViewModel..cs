namespace richmindale_app.Server.Models.ViewModels
{
    public class CoursesDetailsViewModel
    {
        public int? Id { get; set; }
        public int? ProgramDetailsId { get; set; }
        public int? ProgramId { get; set; }
        public int? Semester { get; set; }
        public int? TermId { get; set; }
        public int? CourseId { get; set; }
        public string? CourseCode { get; set; }
        public string? CourseTitle { get; set; }
        public string? CourseDescription { get; set; }
        public string? LongDescription { get; set; }
        public decimal? Revision { get; set; }
        public DateTime? RevisionDate { get; set; }
        public string? PreRequisites { get; set; }
        public decimal? Credits { get; set; }
        public string? Programs { get; set; }
        public decimal? Tuition { get; set; }
        public decimal? Miscellaneous { get; set; } 
    }
}