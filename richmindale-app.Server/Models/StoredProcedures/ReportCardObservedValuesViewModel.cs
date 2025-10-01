namespace richmindale_app.Server.Models.StoredProcedures
{
    public class ReportCardObservedValuesViewModel
    {
        public Guid? EnrollmentId { get; set; }
        public int? CoreValues { get; set; }
        public string? FirstQuarter { get; set; }
        public string? SecondQuarter { get; set; }
        public string? ThirdQuarter { get; set; }
        public string? FourthQuarter { get; set; }
    }
}