namespace richmindale_app.Server.Models.ViewModels
{
    public class AgreementCoursesViewModel
    {
        
        public int Id { get; set; }
        public int Programid { get; set; }
        public int Sequence { get; set; }
        public string? Term { get; set; }
        public string? TermName { get; set; }
        public List<TermCourses>? TermCourses { get; set; }
        
    }
    public class TermCourses
    {
        public int Id { get; set; }
        public string? TermName { get; set; }
        public string? CourseCode { get; set; }
        public string? CourseTitle { get; set; }
        public int? PreRequisite { get; set; }
        public string? PreRequisiteCode { get; set; }
        public string? PreRequisiteTitle { get; set; }
        public decimal? CreditUnits { get; set; }
    }
}