using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnStudentProgram
{
    public long Id { get; set; }

    public Guid? StudentId { get; set; }

    public int? StudentIdOld { get; set; }

    public int? ProgramId { get; set; }

    public int? CredentialProviderId { get; set; }

    public string? CredentialProviderNotes { get; set; }

    public int? SalesOrderId { get; set; }

    public DateTime? EnrollmentDate { get; set; }

    public string? SchoolYear { get; set; }

    public int? SchoolCampusId { get; set; }

    public int? LearningMethodId { get; set; }

    public string? EnrollmentReferenceNo { get; set; }

    public string? EnrollmentAgreementFileObject { get; set; }

    public string? EnrollmentAcceptanceFileObject { get; set; }

    public int? AdmissionPaymentStatus { get; set; }

    public int? DownPaymentStatus { get; set; }

    public string? Notes { get; set; }

    public int? Status { get; set; }

    public string? StatusReason { get; set; }
}
