using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class SysWorkflowAssignment
{
    public int Id { get; set; }

    public int WorkflowId { get; set; }

    public bool? IsReplacement { get; set; }

    public Guid? RoleId { get; set; }

    public Guid? UserId { get; set; }

    public int? Interval { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }
}
