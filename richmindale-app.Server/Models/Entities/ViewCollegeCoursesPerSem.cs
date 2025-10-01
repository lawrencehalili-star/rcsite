using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class ViewCollegeCoursesPerSem
{
    public string Date { get; set; } = null!;

    public string Semester { get; set; } = null!;

    public string Program { get; set; } = null!;

    public int? Programid { get; set; }

    public string? Code { get; set; }

    public string? Origtitle { get; set; }

    public string? Coursetitle { get; set; }

    public string? Sectioname { get; set; }

    public int? Credit { get; set; }

    public string? Prerequisite { get; set; }
}
