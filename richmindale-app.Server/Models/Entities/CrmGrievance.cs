using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmGrievance
{
    public Guid Id { get; set; }

    public string? GrievanceCode { get; set; }

    public int? CategoryId { get; set; }

    public string? EmailAddress { get; set; }

    public string? Message { get; set; }

    public DateTime? DateCreated { get; set; }

    public int? Status { get; set; }
}
