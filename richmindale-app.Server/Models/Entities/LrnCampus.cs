using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnCampus
{
    public int Id { get; set; }

    public string CampusCode { get; set; } = null!;

    public string CampusName { get; set; } = null!;

    public string? Prefix { get; set; }

    public int? OrgId { get; set; }

    public string? CampusOfOrgCode { get; set; }

    public int? CountryId { get; set; }

    public int? CityId { get; set; }

    public int? Status { get; set; }

    public int? LastWorkFlowId { get; set; }
}
