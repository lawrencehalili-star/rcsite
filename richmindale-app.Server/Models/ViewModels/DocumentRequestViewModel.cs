namespace richmindale_app.Server.Models.ViewModels
{
    public class DocumentRequestViewModel
    {
        public int Id { get; set; }
        public string? RequestNumber { get; set; }
        public string? RequestDate { get; set; }
        public Guid? StudentId { get; set; }
        public string? Lastname { get; set; }
        public string? MiddleName { get; set; }
        public string? GivenName { get; set; }
        public int? DocumentTypeId { get; set; }
        public string? DocumentType { get; set; }
        public decimal? Amount { get; set; }
        public string? Purpose { get; set; }
        public string? DocumentNumber { get; set; }
        public int? IssuingOrgId { get; set; }
        public string? OrgName { get; set; }
        public Guid? IssuedBy { get; set; }
        public string? IssuedByName { get; set; }
        public string? IssuedDate { get; set; }
        public int? StatusId { get; set; }
        public string? StatusName { get; set; }
        public string? ChangeStatusDate { get; set; }
        public string? Reason { get; set; }


    }
}