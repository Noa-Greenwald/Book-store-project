using System;
using System.Collections.Generic;

namespace Dal_Repository.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int CategoryId { get; set; }

    public int CompanyId { get; set; }

    public string? Description { get; set; }

    public int? MatchAge { get; set; }

    public double? Price { get; set; }

    public string? Picture { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
}
