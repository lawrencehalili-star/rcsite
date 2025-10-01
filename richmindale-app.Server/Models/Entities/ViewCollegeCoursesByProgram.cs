using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class ViewCollegeCoursesByProgram
{
    public string Program { get; set; } = null!;

    public int? Programid { get; set; }

    public string? Code { get; set; }

    public string? Origtitle { get; set; }

    public string? Coursetitle { get; set; }

    public string? Sectioname { get; set; }

    public int? Credit { get; set; }

    public string? Prerequisite { get; set; }
}
