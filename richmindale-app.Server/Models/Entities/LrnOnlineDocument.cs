using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnOnlineDocument
{
    public int Id { get; set; }

    public int? DocumentTypeId { get; set; }

    public string? Title { get; set; }

    public string? DocumentCode { get; set; }

    public int? ParentDocumentId { get; set; }

    public string? VersionNo { get; set; }

    public bool? Purpose { get; set; }

    public string? PurposeNo { get; set; }

    public string? PurposeTitle { get; set; }

    public string? PurposeContent { get; set; }

    public bool? Scope { get; set; }

    public string? ScopeNo { get; set; }

    public string? ScopeTitle { get; set; }

    public string? ScopeContent { get; set; }

    public bool? Main { get; set; }

    public string? MainNo { get; set; }

    public string? MainTitle { get; set; }

    public string? MainContent { get; set; }

    public bool? Definition { get; set; }

    public bool? Reference { get; set; }

    public string? DocumentUrl { get; set; }

    public bool? IsDownloadable { get; set; }

    public bool? IsPublic { get; set; }

    public DateTime? DateCreated { get; set; }

    public int? FunctionId { get; set; }

    public Guid? CreatedBy { get; set; }

    public int? WorkFlowId { get; set; }

    public DateTime? NextReviewDate { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public bool? IsActive { get; set; }
}
