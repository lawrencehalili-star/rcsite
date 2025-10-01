namespace richmindale_app.Server.Models.StoredProcedures
{
    public class LoadAllAdmissionsViewModel
    {
        public Guid? Id  { get; set; }
        public string? ApplicationRefNo  { get; set; }
        public int? RequestTypeId { get; set; }
        public string? RequestType { get; set; }
        public int? CredentialId { get; set; }
        public string? Credential { get; set; }
        public string? ApplicationDate { get; set; }
        public string? EmailAddress { get; set; }
        public string? StudentGivenName { get; set; }
        public string? StudentLastname { get; set; }
        public string? StudentMiddleName { get; set; }
        public string? StudentMaidenName { get; set; }
        public int? ProgramcategoryId { get; set; }
        public string? ProgramTitle { get; set; }
        public bool? CreditTransfer { get; set; }
        public bool? ApplyDiscount { get; set; }
        public int? DiscountTypeId { get; set; }
        public string? DiscountType { get; set; }
        public string? DiscountCode { get; set; }
        public int? CountryId { get; set; }
        public string? CountryName { get; set; }
        public int? LearningMethodsId { get; set; }
        public string? LearningmethodName { get; set; }
        public int? LrnCampusId { get; set; }
        public string? CampusName { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public string? StatusName { get; set; }

    }
}
 