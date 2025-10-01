using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnPromisoryNote
{
    public int Id { get; set; }

    public Guid? StudentId { get; set; }

    public DateOnly? PromisoryDate { get; set; }

    public decimal? OutstandingBalance { get; set; }

    public int? ExamId { get; set; }

    public DateTime? ExaminationDate { get; set; }

    public string? Notes { get; set; }

    public Guid? ExaminationPermitId { get; set; }

    public bool? IsValid { get; set; }
}
