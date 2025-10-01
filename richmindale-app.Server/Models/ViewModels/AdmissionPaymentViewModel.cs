namespace richmindale_app.Server.Models.ViewModels
{

    public class AdmissionPaymentViewModel
    {
        public Guid Id { get; set; }
        public string? ApplicationRefNo { get; set; }
        public string? StudentName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Program { get; set; }
        public string? TermName { get; set; }
        public int? PaymentMethod   { get; set; }
        public string? PaymentRefNo { get; set; }
        public decimal? Amount { get; set; }
        public string? Status { get; set; }
        public string? TransactionMessage { get; set; }
    }
}