using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public int? OrgId { get; set; }

    public string Username { get; set; } = null!;

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public string? ExitPassword { get; set; }

    public int AdminLevel { get; set; }

    public int? OldRoleId { get; set; }

    public Guid? RoleIds { get; set; }

    public int? ContactId { get; set; }

    public string DisplayName { get; set; } = null!;

    public string? ProfilePhoto { get; set; }

    public string? Locale { get; set; }

    public string? PaperSize { get; set; }

    public int? MaxDisplayRows { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public string? LastLoginInfo { get; set; }

    public string? Theme { get; set; }

    public string? Username2 { get; set; }

    public int Status { get; set; }

    public int? LastWorkFlowId { get; set; }
}
