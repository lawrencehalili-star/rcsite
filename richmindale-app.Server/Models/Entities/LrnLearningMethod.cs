using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnLearningMethod
{
    public int Id { get; set; }

    public string LearningMethodCode { get; set; } = null!;

    public string LearningMethodName { get; set; } = null!;

    public string? Description { get; set; }

    public int? LearningMethodType { get; set; }

    public int? Status { get; set; }

    public int? LastWorkFlowId { get; set; }
}
