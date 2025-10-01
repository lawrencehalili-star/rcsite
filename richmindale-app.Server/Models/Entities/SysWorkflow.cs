using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class SysWorkflow
{
    public int Id { get; set; }

    public int? DomainId { get; set; }

    public int WorkFlowCategoryId { get; set; }

    public int SequenceNo { get; set; }

    public string WorkflowName { get; set; } = null!;

    public string? WorkflowDesc { get; set; }

    public int StatusId { get; set; }

    public Guid? AssignedToRoleId { get; set; }

    public bool? IsActive { get; set; }
}
