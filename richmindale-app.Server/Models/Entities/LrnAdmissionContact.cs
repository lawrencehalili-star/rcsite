using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnAdmissionContact
{
    public int Id { get; set; }

    public Guid AdmissionRequestId { get; set; }

    public int? ContactTypeId { get; set; }

    public string? StudentCode { get; set; }

    public string GivenName { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string? MaidenName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? Gender { get; set; }

    public int? MaritalStatus { get; set; }

    public int? ReligionId { get; set; }

    public int? NationalityId { get; set; }

    public string? Email1 { get; set; }

    public string? Email2 { get; set; }

    public int? PhoneCode1 { get; set; }

    public string? PhoneNo1 { get; set; }

    public int? PhoneCode2 { get; set; }

    public string? PhoneNo2 { get; set; }

    public string? Address { get; set; }

    public int? CountryId { get; set; }

    public int? StateId { get; set; }

    public int? CityId { get; set; }

    public string? ZipCode { get; set; }
}
