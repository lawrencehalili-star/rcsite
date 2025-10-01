using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnClass
{
    public long Id { get; set; }

    public long ProgramId { get; set; }

    public long CourseId { get; set; }

    public string CourseCode { get; set; } = null!;

    public string OrgCode { get; set; } = null!;

    public long? ClassSectionId { get; set; }

    public long? GroupId { get; set; }

    public string? SectionName { get; set; }

    public string TermName { get; set; } = null!;

    public string LearningMethodCode { get; set; } = null!;

    public string CampusCode { get; set; } = null!;

    public long FacilitatorContactId { get; set; }

    public int? SequenceNo { get; set; }

    public bool? IsStarted { get; set; }

    public bool? IsFinished { get; set; }

    public DateTime? PlannedStartDate { get; set; }

    public DateTime? PlannedEndDate { get; set; }

    public int? PlannedDurationDays { get; set; }

    public string? PlannedSessionStartTime { get; set; }

    public string? PlannedSessionEndTime { get; set; }

    public int? PlannedSessionDurationMins { get; set; }

    public DateTime? ActualStartDate { get; set; }

    public DateTime? ActualEndDate { get; set; }

    public int? ActualDurationDays { get; set; }

    public string? ActualSessionStartTime { get; set; }

    public string? ActualSessionEndTime { get; set; }

    public int? ActualSessionDurationMins { get; set; }

    public int? IsOpenTime { get; set; }

    public int? Status { get; set; }

    public long? LastWorkFlowId { get; set; }
}
