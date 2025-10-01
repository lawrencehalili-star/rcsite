using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class SysStatus
{
    public int Id { get; set; }

    public int? ParentStatusId { get; set; }

    public int? StatusRefId { get; set; }

    public string StatusGroup { get; set; } = null!;

    public string StatusName { get; set; } = null!;

    public string? StatusDesc { get; set; }

    public bool? IsActive { get; set; }
}
