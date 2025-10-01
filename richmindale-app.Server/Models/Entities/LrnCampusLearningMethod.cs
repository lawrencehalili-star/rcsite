using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnCampusLearningMethod
{
    public int Id { get; set; }

    public int? CampusId { get; set; }

    public int? LearningMethodId { get; set; }

    public string? Descriptions { get; set; }

    public int? Status { get; set; }
}
