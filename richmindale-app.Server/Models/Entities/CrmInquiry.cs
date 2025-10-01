using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmInquiry
{
    public Guid Id { get; set; }

    public int? InquirySourceId { get; set; }

    public DateTime? InquiryDate { get; set; }

    public string? Fullname { get; set; }

    public string? EmailAddress { get; set; }

    public string? ContactNumber { get; set; }

    public string? Subject { get; set; }

    public string? Message { get; set; }

    public string? Remarks { get; set; }

    public int? Status { get; set; }

    public int? LastWorkFlowId { get; set; }
}
