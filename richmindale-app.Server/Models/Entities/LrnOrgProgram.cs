using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnOrgProgram
{
    public long Id { get; set; }

    public long ProgramId { get; set; }

    public long OrgId { get; set; }

    public int? SequenceNo { get; set; }

    public bool? IsVisible { get; set; }

    public int? Status { get; set; }

    public long? LastWorkFlowId { get; set; }
}
