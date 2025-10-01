using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnCourseActivityTest
{
    public int Id { get; set; }

    public int CourseActivityId { get; set; }

    public int TestId { get; set; }

    public string? DurationMins { get; set; }

    public int? SequenceNo { get; set; }

    public bool? IsShowTestAnswer { get; set; }

    public bool? IsShowAfterLecture { get; set; }

    public string? BreakAfterMins { get; set; }

    public int Status { get; set; }
}
