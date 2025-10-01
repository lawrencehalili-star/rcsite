using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class City
{
    public int Id { get; set; }

    public string? CityCode { get; set; }

    public string CityName { get; set; } = null!;

    public string? PhoneCode { get; set; }

    public int StateId { get; set; }

    public string? StateCode { get; set; }

    public string? StateName { get; set; }

    public int CountryId { get; set; }

    public string? CountryCode { get; set; }

    public string? CountryName { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public int? Status { get; set; }

    public int? LastWorkFlowId { get; set; }
}
