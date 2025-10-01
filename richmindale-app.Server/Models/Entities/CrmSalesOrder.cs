using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmSalesOrder
{
    public int Id { get; set; }

    public string SalesOrderNo { get; set; } = null!;

    public DateTime SalesOrderDate { get; set; }

    public int SalesQuotationId { get; set; }

    public int OrderId { get; set; }

    public decimal? TotalAmountPaid { get; set; }

    public string? Notes { get; set; }

    public string? SalesOrderDocFilename { get; set; }

    public string? SalesOrderDocFile { get; set; }

    public int Status { get; set; }

    public string? StatusReason { get; set; }
}
