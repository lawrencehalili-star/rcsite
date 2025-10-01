using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnStudentClass
{
    public long Id { get; set; }

    public int? ClassId { get; set; }

    public int? ReferredById { get; set; }

    public Guid StudentId { get; set; }

    public int? CampusId { get; set; }

    public int? LearningMethodId { get; set; }

    public int? FeeTypeId { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public DateTime? AdmissionDate { get; set; }

    public DateTime? EnrollmentDate { get; set; }

    public string? SchoolYear { get; set; }

    public string? GroupName { get; set; }

    public int NextActivitySequenceNo { get; set; }

    public int? SalesOrderId { get; set; }

    public int SequenceNo { get; set; }

    public int? CredentialProviderId { get; set; }

    public decimal? FinalScore { get; set; }

    public decimal? FinalRating { get; set; }

    public decimal? FinalAverage { get; set; }

    public string? FinalRemarks { get; set; }

    public int Status { get; set; }

    public string? StatusReason { get; set; }
}
