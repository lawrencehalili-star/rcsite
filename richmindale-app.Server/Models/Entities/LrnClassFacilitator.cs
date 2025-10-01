using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnClassFacilitator
{
    public long Id { get; set; }

    public long ClassId { get; set; }

    public long ContactId { get; set; }

    public long RoleId { get; set; }

    public int? Status { get; set; }

    public long? LastWorkFlowId { get; set; }
}
