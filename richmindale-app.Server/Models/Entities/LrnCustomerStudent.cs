using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnCustomerStudent
{
    public int Id { get; set; }

    public Guid StudentId { get; set; }

    public int? StudentIdOld { get; set; }

    public int CustomerId { get; set; }

    public int Status { get; set; }
}
