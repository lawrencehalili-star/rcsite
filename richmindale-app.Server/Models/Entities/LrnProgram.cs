using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnProgram
{
    public int Id { get; set; }

    public int? ProgramCategoryId { get; set; }

    public string? ProgramCode { get; set; }

    public string? RevisionNo { get; set; }

    public DateTime? EffectiveDateStart { get; set; }

    public DateTime? EffectiveDateEnd { get; set; }

    public string? ProgramTitle { get; set; }

    public int? ProgramType { get; set; }

    public int? ParentId { get; set; }

    public Guid? ProgramHeadContactId { get; set; }

    public int? SequenceNo { get; set; }

    public string? Description { get; set; }

    public string? Mission { get; set; }

    public string? Goals { get; set; }

    public string? LearningOutcomes { get; set; }

    public int Qualification { get; set; }

    public decimal? CreditUnits { get; set; }

    public decimal? DurationTerms { get; set; }

    public decimal? DurationYears { get; set; }

    public decimal? DurationMonths { get; set; }

    public decimal? DurationWeeks { get; set; }

    public decimal? DurationDays { get; set; }

    public int? DurationHours { get; set; }

    public int? GradingSystemId { get; set; }

    public int? CoursesAutoEnroll { get; set; }

    public int? ItemId { get; set; }

    public string? Notes { get; set; }

    public int? Status { get; set; }

    public int? LastWorkFlowId { get; set; }
}
