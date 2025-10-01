using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class ScmItemCategory
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public int CategoryId { get; set; }

    public int? Status { get; set; }

    public long? LastWorkFlowId { get; set; }
}
