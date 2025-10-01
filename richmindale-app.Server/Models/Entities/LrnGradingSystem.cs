using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnGradingSystem
{
    public int Id { get; set; }

    public string GradingName { get; set; } = null!;

    public string? Descr { get; set; }

    public int GradingType { get; set; }

    public bool Status { get; set; }

    public long? LastWorkFlowId { get; set; }
}
