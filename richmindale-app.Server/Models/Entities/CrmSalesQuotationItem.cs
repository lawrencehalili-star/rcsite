using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmSalesQuotationItem
{
    public int Id { get; set; }

    public int SalesQuotationId { get; set; }

    public int OrderItemId { get; set; }

    public int SequenceNo { get; set; }

    public string? Remarks { get; set; }
}
