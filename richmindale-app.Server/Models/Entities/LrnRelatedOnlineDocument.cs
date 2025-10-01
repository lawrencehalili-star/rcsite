using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnRelatedOnlineDocument
{
    public int Id { get; set; }

    public int? LrnOnlneDocumentId { get; set; }

    public int? RelatedDocumentId { get; set; }

    public bool? IsActive { get; set; }
}
