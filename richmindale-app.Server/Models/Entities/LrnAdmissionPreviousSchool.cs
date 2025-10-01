using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnAdmissionPreviousSchool
{
    public int Id { get; set; }

    public Guid? LrnAdmissionApplicationId { get; set; }

    public int? QualificationId { get; set; }

    public int? ProgramId { get; set; }

    public string? OtherProgram { get; set; }

    public string? SchoolName { get; set; }

    public string? SchoolEmail { get; set; }

    public int? CountryId { get; set; }

    public string? SchoolAddress { get; set; }

    public string? ContactPerson { get; set; }

    public string? ContactPersonJob { get; set; }

    public string? ContactPersonEmail { get; set; }

    public int? PhoneCode { get; set; }

    public string? ContactPersonNumber { get; set; }
}
