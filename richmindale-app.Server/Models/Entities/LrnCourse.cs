using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnCourse
{
    public int Id { get; set; }

    public string CourseCode { get; set; } = null!;

    public string CourseTitle { get; set; } = null!;

    public int ParentCourseId { get; set; }

    public int SubjectId { get; set; }

    public string? CourseDesc { get; set; }

    public string? CourseGoals { get; set; }

    public string? LearningOutcomes { get; set; }

    public string? CreditUnits { get; set; }

    public int? DurationYears { get; set; }

    public int? DurationMonths { get; set; }

    public int? DurationWeeks { get; set; }

    public int? DurationHours { get; set; }

    public string? PrerequisitesCourseId { get; set; }

    public string? CorequisitesCourseId { get; set; }

    public int? ItemId { get; set; }

    public int Status { get; set; }

    public int IsGeneral { get; set; }
}
