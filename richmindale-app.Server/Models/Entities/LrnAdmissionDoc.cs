using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnAdmissionDoc
{
    public int Id { get; set; }

    public string? DocumentRefNo { get; set; }

    public Guid? LrnAdmissionApplicationId { get; set; }

    public int? SysDocumentTypeId { get; set; }

    public string? DocumentName { get; set; }

    public string? DocumentUrl { get; set; }

    public DateTime? UploadDate { get; set; }
}
