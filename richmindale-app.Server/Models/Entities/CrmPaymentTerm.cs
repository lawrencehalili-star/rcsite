using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmPaymentTerm
{
    public int Id { get; set; }

    public string PaymentTermName { get; set; } = null!;

    public string Descr { get; set; } = null!;

    public decimal? ExcludeAmount { get; set; }

    public int? Period { get; set; }

    public int? PeriodCount { get; set; }

    public int? PeriodDueDateType { get; set; }

    public int? PeriodWorkingDaysOnly { get; set; }

    public string? Notes { get; set; }

    public int? Status { get; set; }

    public long? LastWorkFlowId { get; set; }
}
