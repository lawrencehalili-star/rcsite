using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmSalesInvoiceItem
{
    public int Id { get; set; }

    public Guid SalesInvoiceId { get; set; }

    public int? SalesInvoiceIdOld { get; set; }

    public string? InvoiceItemDesc { get; set; }

    public int SalesOrderItemId { get; set; }

    public int? PaymentTermItemId { get; set; }

    public int? UnitId { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? DiscountPercent { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal? InterestPercent { get; set; }

    public decimal? InterestAmount { get; set; }

    public decimal LineTotal { get; set; }

    public decimal? AmountPaid { get; set; }

    public int SequenceNo { get; set; }

    public string? Remarks { get; set; }

    public int Status { get; set; }

    public string? StatusReason { get; set; }
}
