using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnExaminationPermit
{
    public Guid Id { get; set; }

    public string PermitCode { get; set; } = null!;

    public Guid StudentId { get; set; }

    public int? PromisoryNoteId { get; set; }

    public int? SubjectId { get; set; }

    public int? ExamId { get; set; }

    public DateOnly? ExaminationDate { get; set; }

    public int? PermitCategoryId { get; set; }

    public decimal? Outstandingbalance { get; set; }

    public DateTime? GeneratedDate { get; set; }

    public Guid? IssuedBy { get; set; }

    public string? Remarks { get; set; }

    public bool? IsValid { get; set; }
}
