using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnIssuedDocument
{
    public int Id { get; set; }

    public int? RequestId { get; set; }

    public string DocumentNumber { get; set; } = null!;

    public int? DocumentTypeId { get; set; }

    public Guid? IssuedTo { get; set; }

    public DateTime? IssuedDate { get; set; }

    public Guid? IssuedBy { get; set; }

    public int? IssuingOrgId { get; set; }

    public bool? IsValid { get; set; }
}
