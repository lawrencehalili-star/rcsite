using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmGrievanceDetail
{
    public int Id { get; set; }

    public Guid? GrievanceId { get; set; }

    public bool? IsAppeal { get; set; }

    public string? Response { get; set; }

    public DateTime? ResponseDate { get; set; }

    public Guid? ResponseBy { get; set; }

    public bool? IsValid { get; set; }
}
