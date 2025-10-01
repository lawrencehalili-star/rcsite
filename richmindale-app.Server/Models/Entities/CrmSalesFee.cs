using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmSalesFee
{
    public int Id { get; set; }

    public int? CampusId { get; set; }

    public string? SchoolYear { get; set; }

    public int? ProgramId { get; set; }

    public int? FeeTypeId { get; set; }

    public decimal? Tradition { get; set; }

    public decimal? Blended { get; set; }

    public decimal? Virtual { get; set; }

    public decimal? Hybrid { get; set; }

    public decimal? Distance { get; set; }

    public decimal? TraditionMisc { get; set; }

    public decimal? BlendedMisc { get; set; }

    public decimal? VirtualMisc { get; set; }

    public decimal? HybridMisc { get; set; }

    public decimal? DistanceMisc { get; set; }

    public DateTime? EffectivityDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public bool? IsActive { get; set; }
}
