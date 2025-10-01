using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class SysDocumentType
{
    public int Id { get; set; }

    public string? Prefix { get; set; }

    public string? DocumentName { get; set; }

    public decimal? DocumentAmount { get; set; }

    public string? Description { get; set; }
}
