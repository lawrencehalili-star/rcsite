using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmGroup
{
    public int Id { get; set; }

    public string? GroupName { get; set; }

    public string? GroupDescr { get; set; }

    public int? Status { get; set; }

    public long? LastWorkFlowId { get; set; }
}
