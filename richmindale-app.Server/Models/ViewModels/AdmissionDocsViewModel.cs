namespace richmindale_app.Server.Models.ViewModels
{
    public class AdmissionDocsViewModel
    {
        public Guid Id { get; set; }
        public Guid? LrnAdmissionApplicationId { get; set; }
        public string? AdmissionRefNo { get; set; }
        public int? DocumentTypeId { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentUrl { get; set; }
        public string? UploadDate { get; set; }
        public IFormFile? File { get; set; }
    }
}