using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class Region
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal WikiDataId { get; set; }
}
