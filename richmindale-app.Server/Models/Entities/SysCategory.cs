using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class SysCategory
{
    public int Id { get; set; }

    public int? ParentCategoryId { get; set; }

    public string? CategoryGroup { get; set; }

    public string? CategoryCode { get; set; }

    public string CategoryName { get; set; } = null!;

    public int? ReferenceId { get; set; }

    public string? CategoryDesc { get; set; }

    public string? IconUrl { get; set; }

    public string? Alias { get; set; }

    public int? Status { get; set; }

    public bool? IsActive { get; set; }
}
