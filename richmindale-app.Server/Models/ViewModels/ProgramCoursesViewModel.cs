namespace richmindale_app.Server.Models.ViewModels
{

    public class ProgramCoursesViewModel
    {
        public int? Id { get; set; }
        public int? ProgramId { get; set; }
        public string? ProgramCode { get; set; }
        public string? ProgramTitle { get; set; }
        public string? ProgramDescription { get; set; }
        public decimal? Revision { get; set; }
        public DateTime? RevisionDate { get; set; }
        public decimal? EstimatedCost { get; set; }
        public decimal? TotalCredits { get; set; }
        public int? NoOfCourses { get; set; }
        public int? Semesters { get; set; }
        public decimal? AdmissionApplicationFee { get; set; }
        public decimal? TuitionPerUnit { get; set; }
        public decimal? MiscellaneousPerUnit { get; set; }
        public decimal? CreditTransferFee { get; set; }
        public decimal? DocumentRequestFee { get; set; }
        public decimal? ExpediteFee { get; set; }
        public List<CoursesDetailsViewModel>? CourseDetails { get; set; }

    }

    

}