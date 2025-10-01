using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnClassSection
{
    public int Id { get; set; }

    public int? ProgramId { get; set; }

    public string? SectionName { get; set; }

    public string? IdNumber { get; set; }

    public string? Description { get; set; }

    public int? DescriptionFormat { get; set; }

    public int? ParentSectionId { get; set; }

    public int? SortOrder { get; set; }

    public long? CourseCount { get; set; }

    public bool? Visible { get; set; }

    public bool? VisibleOld { get; set; }

    public long? TimeModified { get; set; }

    public int? Depth { get; set; }

    public string? Path { get; set; }

    public string? Theme { get; set; }
}
