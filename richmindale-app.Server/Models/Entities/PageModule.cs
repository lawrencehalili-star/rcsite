using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class PageModule
{
    public int Id { get; set; }

    public int PageSectionId { get; set; }

    public int? SequenceNo { get; set; }

    public int? ParentModuleId { get; set; }

    public string? ModuleName { get; set; }

    public string? Title { get; set; }

    public string? TargetUrl { get; set; }

    public string? CssClass { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }
}
