using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class Religion
{
    public int Id { get; set; }

    public string ReligionCode { get; set; } = null!;

    public string ReligionName { get; set; } = null!;

    public int? Status { get; set; }

    public int? LastWorkFlowId { get; set; }
}
