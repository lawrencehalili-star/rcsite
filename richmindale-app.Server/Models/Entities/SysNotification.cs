using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class SysNotification
{
    public Guid Id { get; set; }

    public int? WorkflowId { get; set; }

    public string? ReturnUrl { get; set; }

    public string? ReferenceId { get; set; }

    public Guid? UserId { get; set; }

    public string? Description { get; set; }

    public bool? IsRead { get; set; }

    public DateTime? NotificationDate { get; set; }

    public bool? IsActive { get; set; }
}
