using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class AccessMatrix
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public int PageSectionId { get; set; }

    public int PageModuleId { get; set; }

    public bool? CanCreate { get; set; }

    public bool? CanRead { get; set; }

    public bool? CanUpdate { get; set; }

    public bool? CanDelete { get; set; }

    public DateTime? DateCreated { get; set; }

    public Guid? CreatedBy { get; set; }

    public bool? IsActive { get; set; }
}
