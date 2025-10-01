using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class UserLogin
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public DateTime? LoginDate { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public string? Remarks { get; set; }
}
