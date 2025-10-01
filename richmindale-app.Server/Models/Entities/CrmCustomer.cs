using System;
using System.Collections.Generic;

namespace richmindale_app.Server.Models.Entities;

public partial class CrmCustomer
{
    public long Id { get; set; }

    public string CustomerCode { get; set; } = null!;

    public int? CustomerOfOrgId { get; set; }

    public int? OrgId { get; set; }

    public int ContactId { get; set; }

    public string? DefaultOrgCode { get; set; }

    public string DefaultCurrencyCode { get; set; } = null!;

    public string? DefaultPromoCode { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public string? DefaultPriceListName { get; set; }

    public string? DefaultPaymentTermName { get; set; }

    public decimal? TotalOrderAmount { get; set; }

    public decimal? TotalUnpaidAmount { get; set; }

    public string? CurrencyCode { get; set; }

    public int? ReferrerContactId { get; set; }

    public int? Status { get; set; }

    public string? StatusReason { get; set; }

    public string? Notes { get; set; }

    public int? LastWorkFlowId { get; set; }
}
