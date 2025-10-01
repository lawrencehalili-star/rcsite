using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class VwStudentMasterList
{
    public Guid Id { get; set; }

    public string StudentCode { get; set; } = null!;

    public string? CategoryName { get; set; }

    public string? LastName { get; set; }

    public string? GivenName { get; set; }

    public string? MiddleName { get; set; }

    public string? MaidenName { get; set; }

    public DateTime? EnrollmentDate { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public string CampusName { get; set; } = null!;

    public string LearningMethodName { get; set; } = null!;

    public string? SectionName { get; set; }

    public string? SchoolYear { get; set; }

    public string StatusName { get; set; } = null!;
}
