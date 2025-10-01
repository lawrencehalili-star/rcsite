using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnStudent
{
    public Guid Id { get; set; }

    public int? StudentIdOld { get; set; }

    public string? StudentOldCode { get; set; }

    public string StudentCode { get; set; } = null!;

    public string? DepEdLrn { get; set; }

    public int? StudentTypeId { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public int? ContactId { get; set; }

    public int? FatherContactId { get; set; }

    public int? MotherContactId { get; set; }

    public int? GuardianContactId { get; set; }

    public int? SponsorContactId { get; set; }

    public int? SiblingOrdinalNo { get; set; }

    public int Status { get; set; }

    public string? StatusReason { get; set; }
}
