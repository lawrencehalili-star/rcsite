using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class ViewCollegeCourse
{
    public string Date { get; set; } = null!;

    public string Semester { get; set; } = null!;

    public string Program { get; set; } = null!;

    public string? Code { get; set; }

    public string? Title { get; set; }

    public int? Credit { get; set; }

    public string? Prerequisite { get; set; }
}
