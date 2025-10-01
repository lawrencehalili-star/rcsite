using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class ViewCollegeCoursesDistinct
{
    public string? Code { get; set; }

    public string? Coursetitle { get; set; }

    public int? Credit { get; set; }

    public string? Prerequisite { get; set; }
}
