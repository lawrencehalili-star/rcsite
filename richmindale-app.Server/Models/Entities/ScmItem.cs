using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class ScmItem
{
    public int Id { get; set; }

    public string? ItemCode { get; set; }

    public string ItemName { get; set; } = null!;

    public string? Descr { get; set; }

    public int ItemType { get; set; }

    public int? ItemTypeUse { get; set; }

    public int? ItemTypeClass { get; set; }

    public int? IsInventory { get; set; }

    public decimal? ListPrice { get; set; }

    public decimal? CostPrice { get; set; }

    public string? CurrencyCode { get; set; }

    public int Status { get; set; }

    public long? LastWorkFlowId { get; set; }
}
