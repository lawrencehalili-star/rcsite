using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmPaymentTermApply
{
    public int Id { get; set; }

    public int PaymentTermId { get; set; }

    public int? ItemId { get; set; }

    public int Status { get; set; }
}
