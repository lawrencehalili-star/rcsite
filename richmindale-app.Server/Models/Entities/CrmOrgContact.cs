using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmOrgContact
{
    public int Id { get; set; }

    public int OrgId { get; set; }

    public int ContactId { get; set; }

    public bool? IsMainContact { get; set; }

    public string? PhoneNo1 { get; set; }

    public string? PhoneNo2 { get; set; }

    public string? Email { get; set; }

    public int Status { get; set; }

    public string? StatusReason { get; set; }
}
