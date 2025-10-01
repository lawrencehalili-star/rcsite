using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmContact
{
    public int Id { get; set; }

    public string? ContactHashValue { get; set; }

    public int? SiblingId { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public string? ContactCode { get; set; }

    public int? ContactType { get; set; }

    public string? LastName { get; set; }

    public string? GivenName { get; set; }

    public string? MiddleName { get; set; }

    public string? MaidenName { get; set; }

    public string? Suffix { get; set; }

    public string? FullName { get; set; }

    public string? DisplayName { get; set; }

    public DateTime? BirthDate { get; set; }

    public int? Gender { get; set; }

    public int? MaritalStatus { get; set; }

    public int? NationalityId { get; set; }

    public int? ReligionId { get; set; }

    public string? PhotoFilename { get; set; }

    public string? Photo { get; set; }

    public int? PhoneCode1 { get; set; }

    public string? PhoneNo1 { get; set; }

    public int? PhoneCode2 { get; set; }

    public string? PhoneNo2 { get; set; }

    public string? Email1 { get; set; }

    public string? Email2 { get; set; }

    public string? EmployerName { get; set; }

    public int? Status { get; set; }

    public string? StatusReason { get; set; }
}
