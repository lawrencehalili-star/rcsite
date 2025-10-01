using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class LrnAdmissionHistory
{
    public int Id { get; set; }

    public Guid AdmissionApplicationId { get; set; }

    public int? WorkflowId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public Guid? ModifiedBy { get; set; }

    public Guid? AssignedTo { get; set; }

    public string? Remarks { get; set; }

    public int? StatusId { get; set; }
}
