using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class ViewCourseCodeToIdMap
{
    public int Id { get; set; }

    public string CourseCode { get; set; } = null!;
}
