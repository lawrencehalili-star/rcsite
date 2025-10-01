namespace richmindale_app.Server.Models.StoredProcedures
{
    public class ReportCardsViewModel
    {
        public Guid? StudentId { get; set; }
        public string? GivenName { get; set; }
        public string? Lastname { get; set; }
        public string? MiddleName { get; set; }
        public string? StudentCode { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Age { get; set; }
        public string? GradeLevel { get; set; }
        public string? Gender { get; set; }
        public string? TeacherRegistrar { get; set; }
        public string? TeacherRegistrarSign { get; set; }
        public string? Principal { get; set; }
        public string? PrincipalSign { get; set; }
        public string? AdmittedToGrade { get; set; }
        public string? AdmittedToSection { get; set; }
        public string? EligibleForAdmission { get; set; }
        public string? CancelAdmissionToGrade { get; set; }
        public string? CancelAdmissionDate { get; set; }
        public string? ParentComment1Q { get; set; }
        public string? ParentComment2Q { get; set; }
        public string? ParentComment3Q { get; set; }
        public string? ParentComment4Q { get; set; }
        public IEnumerable<ReportCardsGradesViewModel>? Grades { get; set; }
        public IEnumerable<ReportCardAttendanceViewModel>? Attendance { get; set; }
        public IEnumerable<ReportCardObservedValuesViewModel>? Values { get; set; }
    }

}