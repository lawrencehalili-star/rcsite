using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class SysDomain
{
    public int Id { get; set; }

    public string? DomainName { get; set; }

    public int? CampusId { get; set; }

    public string? DomainUrl { get; set; }

    public string? DomainDescription { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateAdded { get; set; }
}
