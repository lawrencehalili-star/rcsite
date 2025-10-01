using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnSchoolWeek
{
    public long Id { get; set; }

    public int? CampusId { get; set; }

    public string? SchoolYear { get; set; }

    public int? WeekNumber { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public Guid? GeneratedBy { get; set; }

    public DateTime? DateGenerated { get; set; }

    public bool? IsValid { get; set; }
}
