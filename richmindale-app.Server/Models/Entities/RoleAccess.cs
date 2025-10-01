using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class RoleAccess
{
    public int Id { get; set; }

    public Guid? RoleId { get; set; }

    public int? PageSectionId { get; set; }

    public DateTime? DateCreated { get; set; }

    public Guid? CreatedBy { get; set; }

    public bool? IsActive { get; set; }
}
