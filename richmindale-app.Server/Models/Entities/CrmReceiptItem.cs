using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmReceiptItem
{
    public long Id { get; set; }

    public Guid ReceiptId { get; set; }

    public int? ReceiptIdOld { get; set; }

    public string? ReceiptItemDesc { get; set; }

    public int SalesOrderItemId { get; set; }

    public int? SalesInvoiceItemId { get; set; }

    public int? PaymentTermItemId { get; set; }

    public decimal Quantity { get; set; }

    public decimal? DiscountPercent { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal? AmountPaid { get; set; }

    public int SequenceNo { get; set; }

    public string? Remarks { get; set; }

    public int Status { get; set; }

    public string? StatusReason { get; set; }
}
