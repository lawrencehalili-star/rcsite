using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnSubject
{
    public int Id { get; set; }

    public string SubjectCode { get; set; } = null!;

    public string SubjectTitle { get; set; } = null!;

    public string? Description { get; set; }

    public int? Status { get; set; }

    public int? LastWorkFlowId { get; set; }
}
