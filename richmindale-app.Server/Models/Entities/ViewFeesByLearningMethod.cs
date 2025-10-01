using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class ViewFeesByLearningMethod
{
    public int Id { get; set; }

    public string? SchoolYear { get; set; }

    public string? CategoryName { get; set; }

    public string? CategoryCode { get; set; }

    public string LearningMethod { get; set; } = null!;

    public decimal? Fee { get; set; }

    public decimal? MiscFee { get; set; }

    public DateTime? EffectivityDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public bool? IsActive { get; set; }
}
