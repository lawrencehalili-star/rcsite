using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnStudentDocumentRequest
{
    public int Id { get; set; }

    public string? RequestNumber { get; set; }

    public DateTime? RequestDate { get; set; }

    public Guid? StudentId { get; set; }

    public int? DocumentTypeId { get; set; }

    public decimal? Amount { get; set; }

    public string? PaymentRefNo { get; set; }

    public string? Purpose { get; set; }

    public string? DocumentNumber { get; set; }

    public int? IssuingOrgId { get; set; }

    public Guid? IssuedBy { get; set; }

    public DateTime? IssuedDate { get; set; }

    public int? StatusId { get; set; }

    public DateTime? ChangeStatusDate { get; set; }

    public string? Reason { get; set; }

    public bool? IsValid { get; set; }
}
