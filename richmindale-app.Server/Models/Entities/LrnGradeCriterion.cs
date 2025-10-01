using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnGradeCriterion
{
    public int Id { get; set; }

    public int GradingSystemId { get; set; }

    public string GradeText { get; set; } = null!;

    public double? GradeValue { get; set; }

    public double? RatingFrom { get; set; }

    public double? RatingTo { get; set; }

    public int? RatingIsPass { get; set; }

    public string? Descr { get; set; }

    public string? Criteria { get; set; }

    public int? Status { get; set; }

    public long? LastWorkFlowId { get; set; }
}
