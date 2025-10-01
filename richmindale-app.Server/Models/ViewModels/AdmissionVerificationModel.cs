namespace richmindale_app.Server.Models.ViewModels
{
    public class AdmissionVerificationModel
    {
        public int? RequestTypeId { get; set; }
        public int ProgramCategoryId { get; set; }
        public int ProgramId { get; set; }
        public string? EmailAddress { get; set; }
        
    }
}
