namespace richmindale_app.Server.Models.ViewModels
{
    public class StudentInfoViewModel
    {
        public Guid? Id { get; set; }
        public string? StudentCode { get; set; }
        public string? GivenName { get; set; }
        public string? Lastname { get; set; }
        public string? MiddleName { get; set; }
        public string? MaidenName { get; set; }
        public string? BirthDate { get; set; }
        public int? Gender { get; set; }
        public int? NationalityId { get; set; }
        public int? ReligionId { get; set; }
        public int? ProgramId { get; set; }
        public int? LearningMethodId { get; set; }
        public DateTime? LastEnrollmentDate { get; set; }
        public string? Password { get; set; }
        public string? Status { get; set; } 

    }
}