using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnClassActivityTest
{
    public int Id { get; set; }

    public int ClassActivityId { get; set; }

    public int TestId { get; set; }

    public decimal? DurationMins { get; set; }

    public bool? IsShowTestAnswer { get; set; }

    public bool? IsShowAfterLecture { get; set; }

    public string? BreakAfterMins { get; set; }

    public int Status { get; set; }
}
