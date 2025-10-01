using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmOrg
{
    public int Id { get; set; }

    public string? OrgCode { get; set; }

    public string OrgName { get; set; } = null!;

    public string? OfficeName { get; set; }

    public int OrgType { get; set; }

    public int? SchoolCredentialLevel { get; set; }

    public int? ParentOrgId { get; set; }

    public string? RegNo { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public string? TaxNo { get; set; }

    public string? AddressDetails { get; set; }

    public string? District { get; set; }

    public int? CityId { get; set; }

    public int? StateId { get; set; }

    public string? ZipCode { get; set; }

    public int? CountryId { get; set; }

    public string? PhoneNo1 { get; set; }

    public string? PhoneNo2 { get; set; }

    public string? PhoneNo3 { get; set; }

    public string? PhoneNo4 { get; set; }

    public string? Email1 { get; set; }

    public string? Email2 { get; set; }

    public string? Website { get; set; }

    public int Status { get; set; }

    public string? StatusReason { get; set; }
}
