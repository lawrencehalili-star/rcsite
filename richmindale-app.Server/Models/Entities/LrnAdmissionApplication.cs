using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnAdmissionApplication
{
    public Guid Id { get; set; }

    public string ApplicationRefNo { get; set; } = null!;

    public int? AdmissionTypeId { get; set; }

    public int? RequestTypeId { get; set; }

    public bool? CreditTransfer { get; set; }

    public string? EmailAddress { get; set; }

    public bool? ApplyDiscount { get; set; }

    public int? DiscountTypeId { get; set; }

    public string? DiscountCode { get; set; }

    public string? StudentCode { get; set; }

    public int? LearningMethodsId { get; set; }

    public int? LrnCampusId { get; set; }

    public int? ProgramCategoryId { get; set; }

    public int? ProgramId { get; set; }

    public DateTime ApplicationDate { get; set; }

    public int? ApplicationAccountContactId { get; set; }

    public int? ApplicantContactId { get; set; }

    public string? ApplicationDetails { get; set; }

    public int? ApplicationOptions { get; set; }

    public int? Status { get; set; }

    public bool? Paid { get; set; }

    public decimal? Amount { get; set; }

    public string? InvoiceNumber { get; set; }

    public string? PaymentRefNo { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? StudentGivenName { get; set; }

    public string? StudentLastname { get; set; }

    public string? StudentMiddleName { get; set; }

    public string? StudentMaidenName { get; set; }

    public DateTime? StudentBirthDate { get; set; }

    public int? StudentGender { get; set; }

    public int? StudentMaritalStatus { get; set; }

    public int? StudentReligion { get; set; }

    public int? StudentNationality { get; set; }

    public int? StudentCountry { get; set; }

    public int? StudentState { get; set; }

    public int? StudentCity { get; set; }

    public string? StudentZipCode { get; set; }

    public string? StudentAddress { get; set; }

    public string? StudentEmail1 { get; set; }

    public string? StudentEmail2 { get; set; }

    public string? StudentPhoneCode1 { get; set; }

    public string? StudentPhone1 { get; set; }

    public string? StudentPhoneCode2 { get; set; }

    public string? StudentPhone2 { get; set; }

    public bool? SkipSchool { get; set; }

    public string? SchoolName { get; set; }

    public int? Qualifications { get; set; }

    public int? SchoolProgram { get; set; }

    public string? SchoolOtherProgram { get; set; }

    public string? SchoolEmail { get; set; }

    public int? SchoolCountry { get; set; }

    public string? SchoolAddress { get; set; }

    public string? SchoolContact { get; set; }

    public string? SchoolContactDesignation { get; set; }

    public string? SchoolContactEmail { get; set; }

    public string? SchoolPhoneCode { get; set; }

    public string? SchoolContactNumber { get; set; }

    public bool? SkipFather { get; set; }

    public string? FatherGivenName { get; set; }

    public string? FatherLastname { get; set; }

    public string? FatherMiddleName { get; set; }

    public DateTime? FatherBirthDate { get; set; }

    public int? FatherGender { get; set; }

    public int? FatherMaritalStatus { get; set; }

    public int? FatherReligion { get; set; }

    public int? FatherNationality { get; set; }

    public int? FatherCountry { get; set; }

    public int? FatherState { get; set; }

    public int? FatherCity { get; set; }

    public string? FatherZipCode { get; set; }

    public string? FatherAddress { get; set; }

    public string? FatherEmail1 { get; set; }

    public string? FatherEmail2 { get; set; }

    public string? FatherPhoneCode1 { get; set; }

    public string? FatherPhone1 { get; set; }

    public string? FatherPhoneCode2 { get; set; }

    public string? FatherPhone2 { get; set; }

    public bool? SkipMother { get; set; }

    public string? MotherGivenName { get; set; }

    public string? MotherLastname { get; set; }

    public string? MotherMiddleName { get; set; }

    public string? MotherMaidenName { get; set; }

    public DateTime? MotherBirthDate { get; set; }

    public int? MotherGender { get; set; }

    public int? MotherMaritalStatus { get; set; }

    public int? MotherReligion { get; set; }

    public int? MotherNationality { get; set; }

    public int? MotherCountry { get; set; }

    public int? MotherState { get; set; }

    public int? MotherCity { get; set; }

    public string? MotherZipCode { get; set; }

    public string? MotherAddress { get; set; }

    public string? MotherEmail1 { get; set; }

    public string? MotherEmail2 { get; set; }

    public string? MotherPhoneCode1 { get; set; }

    public string? MotherPhone1 { get; set; }

    public string? MotherPhoneCode2 { get; set; }

    public string? MotherPhone2 { get; set; }

    public bool? SkipGuardian { get; set; }

    public string? GuardianGivenName { get; set; }

    public string? GuardianLastname { get; set; }

    public string? GuardianMiddleName { get; set; }

    public string? GuardianMaidenName { get; set; }

    public DateTime? GuardianBirthDate { get; set; }

    public int? GuardianGender { get; set; }

    public int? GuardianMaritalStatus { get; set; }

    public int? GuardianReligion { get; set; }

    public int? GuardianNationality { get; set; }

    public int? GuardianCountry { get; set; }

    public int? GuardianState { get; set; }

    public int? GuardianCity { get; set; }

    public string? GuardianZipCode { get; set; }

    public string? GuardianAddress { get; set; }

    public string? GuardianEmail1 { get; set; }

    public string? GuardianEmail2 { get; set; }

    public string? GuardianPhoneCode1 { get; set; }

    public string? GuardianPhone1 { get; set; }

    public string? GuardianPhoneCode2 { get; set; }

    public string? GuardianPhone2 { get; set; }

    public int? LastWorkFlowId { get; set; }

    public string? Remarks { get; set; }
}
