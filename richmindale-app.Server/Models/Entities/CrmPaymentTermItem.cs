using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmPaymentTermItem
{
    public int Id { get; set; }

    public int PaymentTermId { get; set; }

    public string PaymentTitle { get; set; } = null!;

    public int SequenceNo { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? DueDate { get; set; }

    public int? DueDays { get; set; }

    public string? Notes { get; set; }

    public int Status { get; set; }
}
