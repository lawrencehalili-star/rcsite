using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmSalesOrderItem
{
    public long Id { get; set; }

    public int SalesOrderId { get; set; }

    public int OrderItemId { get; set; }

    public int SequenceNo { get; set; }

    public decimal? AmountPaid { get; set; }

    public string? Remarks { get; set; }
}
