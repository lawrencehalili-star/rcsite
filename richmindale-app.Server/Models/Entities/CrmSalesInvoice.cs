using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmSalesInvoice
{
    public Guid Id { get; set; }

    public int? SalesInvoiceOdOld { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public DateTime InvoiceDate { get; set; }

    public int CustomerId { get; set; }

    public int CurrencyId { get; set; }

    public string? CurrencyExchangeRate { get; set; }

    public string InvoiceDesc { get; set; } = null!;

    public int SalesOrderId { get; set; }

    public DateTime? DueDate { get; set; }

    public int? DueDays { get; set; }

    public decimal? TotalInterestPercent { get; set; }

    public decimal? TotalInterestAmount { get; set; }

    public decimal? TotalDiscountPercent { get; set; }

    public decimal? TotalDiscountAmount { get; set; }

    public decimal? TotalNetAmount { get; set; }

    public decimal? TotalAmountPaid { get; set; }

    public string? Notes { get; set; }

    public int Status { get; set; }

    public string? StatusReason { get; set; }
}
