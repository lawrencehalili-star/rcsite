using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmContactAddress
{
    public int Id { get; set; }

    public int ContactId { get; set; }

    public bool? IsDefault { get; set; }

    public int? AddressTypeId { get; set; }

    public string? AddressName { get; set; }

    public string? AddressDetails { get; set; }

    public string? Room { get; set; }

    public string? Building { get; set; }

    public string? Street { get; set; }

    public string? Area { get; set; }

    public int? CityId { get; set; }

    public int? StateId { get; set; }

    public string? ZipCode { get; set; }

    public int? CountryId { get; set; }

    public string? PhoneNo1 { get; set; }

    public string? PhoneNo2 { get; set; }

    public int? Status { get; set; }
}
