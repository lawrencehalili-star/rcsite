namespace richmindale_app.Server.Models.StoredProcedures
{

    public class MasterListViewModel
    {
        public Guid Id { get; set; }
        public string? StudentCode { get; set; }
        public string? Lastname { get; set; }
        public string? GivenName { get; set; }
        public string? EnrollmentDate { get; set; }
        public string? LearningMethod { get; set; }
        public string? Status { get; set; }
        
    }

}