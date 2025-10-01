using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmPromo
{
    public int Id { get; set; }

    public string PromoCode { get; set; } = null!;

    public string? Descr { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public double? DiscountRate { get; set; }

    public decimal? DiscountAmount { get; set; }

    public long? UseThisPriceListId { get; set; }

    public decimal? UseThisPrice { get; set; }

    public decimal? EarnValue { get; set; }

    public string? Notes { get; set; }

    public int Status { get; set; }

    public long? LastWorkFlowId { get; set; }
}
