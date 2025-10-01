using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmPriceList
{
    public int Id { get; set; }

    public string PriceListName { get; set; } = null!;

    public string? Descr { get; set; }

    public string? CurrencyCode { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int Status { get; set; }

    public long? LastWorkFlowId { get; set; }
}
