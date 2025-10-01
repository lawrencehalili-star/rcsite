using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class SysPasskey
{
    public Guid Id { get; set; }

    public string? Email { get; set; }

    public string? StudentNumber { get; set; }

    public string Passkey { get; set; } = null!;

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public DateTime? GeneratedDate { get; set; }

    public DateTime? ExpiryDate { get; set; }
}
