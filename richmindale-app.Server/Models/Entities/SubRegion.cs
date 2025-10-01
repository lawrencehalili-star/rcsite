using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class SubRegion
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int RegionId { get; set; }

    public decimal WikiDataId { get; set; }
}
