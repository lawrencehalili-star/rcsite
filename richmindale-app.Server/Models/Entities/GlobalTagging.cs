using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class GlobalTagging
{
    public long Id { get; set; }

    public string Tag { get; set; } = null!;

    public string? TagIdentifier { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? AddedBy { get; set; }
}
