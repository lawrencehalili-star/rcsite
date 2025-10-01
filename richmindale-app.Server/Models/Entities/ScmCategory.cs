using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class ScmCategory
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Descr { get; set; }

    public string? ParentCategoryName { get; set; }

    public int? Status { get; set; }

    public long? LastWorkFlowId { get; set; }
}
