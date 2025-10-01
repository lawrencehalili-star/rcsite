namespace richmindale_app.Server.Models.StoredProcedures
{
    public class ReportCardsGradesViewModel
    {
        public Guid? EnrollmentId { get; set; }
        public string? Course { get; set; }
        public decimal? FirstQuarter { get; set; }
        public decimal? SecondQuarter { get; set; }
        public decimal? ThirdQuarter { get; set; }
        public decimal? FinalRating { get; set; }
        public string? FinalGrade { get; set; }
        public string? Remarks { get; set; }
    }
}