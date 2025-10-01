using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class Area
{
    public int Id { get; set; }

    public int? CityId { get; set; }

    public string AreaName { get; set; } = null!;

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public int? Status { get; set; }

    public int? LastWorkFlowId { get; set; }
}
