namespace richmindale_app.Server.Models.ViewModels
{
    public class EnrollmentRequestViewModel
    {
        public Guid? Id { get; set; }
        public string? EmailAddress { get; set; }
        public int? CountryId { get; set; }
        public int? CampusId { get; set; }
        public int? LearningMethodId { get; set; }
        public int? ProgramCategoryId { get; set; }
        public int? ProgramId { get; set; }
        public string? Terms { get; set; }
        public string? SchoolYear { get; set; }
        public int? EnrollmentStatus { get; set; }
    }
}