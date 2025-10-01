using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class PageSection
{
    public int Id { get; set; }

    public int? SectionType { get; set; }

    public int? SequenceNo { get; set; }

    public int? ParentPageSectionId { get; set; }

    public string? PageSectionName { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Icon { get; set; }

    public string? TargetUrl { get; set; }

    public string? SubElementId { get; set; }

    public string? CssClass { get; set; }

    public bool? IsActive { get; set; }
}
