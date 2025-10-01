using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnStudentProgramRequirement
{
    public int Id { get; set; }

    public int StudentProgramId { get; set; }

    public int CustomFieldId { get; set; }

    public int? SequenceNo { get; set; }

    public string? RequirementNotes { get; set; }

    public string? RequirementFileObject { get; set; }

    public string? RequirementScore { get; set; }

    public decimal? RequirementRating { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime? DateSubmitted { get; set; }

    public int? Status { get; set; }

    public string? StatusReason { get; set; }
}
