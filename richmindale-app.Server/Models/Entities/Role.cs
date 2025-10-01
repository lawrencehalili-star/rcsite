using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class Role
{
    public Guid Id { get; set; }

    public int? OldRoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public string? Description { get; set; }

    public int Status { get; set; }

    public int? LastWorkFlowId { get; set; }
}
