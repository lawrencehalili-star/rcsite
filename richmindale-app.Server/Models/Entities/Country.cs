using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class Country
{
    public int Id { get; set; }

    public string? Iso3 { get; set; }

    public string? CountryCode { get; set; }

    public string CountryName { get; set; } = null!;

    public int? NumericCode { get; set; }

    public string? PhoneCode { get; set; }

    public string? Capital { get; set; }

    public string? Currency { get; set; }

    public string? CurrencyName { get; set; }

    public string? CurrencySymbol { get; set; }

    public string? Native { get; set; }

    public int? RegionId { get; set; }

    public string? Region { get; set; }

    public int? SubRegionId { get; set; }

    public string? SubRegion { get; set; }

    public string? Nationality { get; set; }

    public string? Timezone { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public string? Emoji { get; set; }

    public string? EmojiUi { get; set; }

    public string? WebDomain { get; set; }

    public int? Status { get; set; }

    public int? LastWorkFlowId { get; set; }
}
