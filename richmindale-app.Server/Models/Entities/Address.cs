using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class Address
{
    public int Id { get; set; }

    public int? ContactId { get; set; }

    public int? CountryId { get; set; }

    public int? StateId { get; set; }

    public string? ZipCode { get; set; }

    public int? CityId { get; set; }

    public int? AreaId { get; set; }

    public string? Street { get; set; }

    public string? Building { get; set; }

    public string? Room { get; set; }

    public string? AddressDetails { get; set; }

    public string? Phone1 { get; set; }

    public string? Phone2 { get; set; }

    public int? Status { get; set; }

    public int? LastWorkFlowId { get; set; }
}
