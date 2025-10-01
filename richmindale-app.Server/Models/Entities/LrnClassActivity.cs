using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnClassActivity
{
    public int Id { get; set; }

    public int ClassId { get; set; }

    public int ActivityId { get; set; }

    public int ActivityResourceId { get; set; }

    public int SequenceNo { get; set; }

    public int Status { get; set; }
}
