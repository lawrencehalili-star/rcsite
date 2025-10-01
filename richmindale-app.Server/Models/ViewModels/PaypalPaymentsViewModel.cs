namespace richmindale_app.Server.Models.ViewModels
{
    public class PaypalPaymentsViewModels
    {
        public Guid Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? TransactionNumber { get; set; }
        public Guid? StudentId { get; set; }
        public string? StudentCode { get; set; }
        public string? EmailAddress { get; set; }
        public string? Fullname { get; set; }
        public string? PaymentFor { get; set; }
        public decimal? Amount { get; set; }
        public string? Currency { get; set; }
        public string? ShortMessage { get; set; }
        public string? TransactionMessage { get; set; }
        public string? Status { get; set; }

    }
}