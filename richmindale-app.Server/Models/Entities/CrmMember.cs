using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmMember
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string MembershipNo { get; set; } = null!;

    public int ParentMemberId { get; set; }

    public int ReferredByMemberId { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public int MemberClassId { get; set; }

    public int Level1MemberCount { get; set; }

    public int Level2MemberCount { get; set; }

    public int Level3MemberCount { get; set; }

    public int Level4MemberCount { get; set; }

    public int Status { get; set; }

    public string? StatusReason { get; set; }
}
