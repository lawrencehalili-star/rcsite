using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmReceipt
{
    public Guid Id { get; set; }

    public int? ReceiptIdOld { get; set; }

    public string ReceiptNo { get; set; } = null!;

    public DateTime ReceiptDate { get; set; }

    public int CustomerId { get; set; }

    public int CurrencyId { get; set; }

    public decimal? CurrencyExchangeRate { get; set; }

    public string ReceiptDesc { get; set; } = null!;

    public int PaymentMethod { get; set; }

    public string? PaymentDetails { get; set; }

    public decimal? TotalDiscountPercent { get; set; }

    public decimal? TotalDiscountAmount { get; set; }

    public decimal? TotalAmountPaid { get; set; }

    public Guid ReceivedByUserId { get; set; }

    public int? ReceivedByUserIdOld { get; set; }

    public string? Notes { get; set; }

    public int Status { get; set; }

    public string? StatusReason { get; set; }
}
