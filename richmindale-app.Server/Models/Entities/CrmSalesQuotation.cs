using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmSalesQuotation
{
    public int Id { get; set; }

    public string QuotationNo { get; set; } = null!;

    public DateTime QuotationDate { get; set; }

    public string? DocumentRef { get; set; }

    public int OrderId { get; set; }

    public string? Notes { get; set; }

    public int Status { get; set; }

    public string? StatusReason { get; set; }
}
