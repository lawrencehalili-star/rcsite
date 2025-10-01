using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnProgramCategory
{
    public int Id { get; set; }

    public int ProgramId { get; set; }

    public int CategoryId { get; set; }

    public int? Status { get; set; }

    public int? LastWorkFlowId { get; set; }
}
