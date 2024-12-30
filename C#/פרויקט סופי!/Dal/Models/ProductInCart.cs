using System;
using System.Collections.Generic;

namespace Dal_Repository.Models;

public partial class ProductInCart
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int CategoryId { get; set; }

    public int CompanyId { get; set; }

    public string? Description { get; set; }

    public int? MatchAge { get; set; }

    public decimal? Price { get; set; }

    public string? Picture { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public int Quantity { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;
}
