using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmPriceListItem
{
    public int Id { get; set; }

    public int PriceListId { get; set; }

    public int ItemId { get; set; }

    public string PriceName { get; set; } = null!;

    public int? PriceType { get; set; }

    public decimal Amount { get; set; }

    public decimal? Rate { get; set; }

    public double? MinOrderQuantity { get; set; }

    public string? UnitCode { get; set; }

    public int? SequenceNo { get; set; }

    public string? Notes { get; set; }

    public int? Status { get; set; }

    public long? LastWorkFlowId { get; set; }
}
