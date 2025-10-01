using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnOnlineDocumentSection
{
    public int Id { get; set; }

    public int? LrnOnlineDocumentId { get; set; }

    public int? SectionTypeId { get; set; }

    public int? SequenceNo { get; set; }

    public string? SectionNo { get; set; }

    public string? SectionTitle { get; set; }

    public string? SectionContent { get; set; }

    public DateTime? DateCreated { get; set; }

    public Guid? CreatedBy { get; set; }

    public bool? IsActive { get; set; }
}
