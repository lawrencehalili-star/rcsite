using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class State
{
    public int Id { get; set; }

    public string? StateCode { get; set; }

    public string StateName { get; set; } = null!;

    public int CountryId { get; set; }

    public string? CountryCode { get; set; }

    public string? StateType { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public int? Status { get; set; }
}
