using System;
using System.Collections.Generic;

namespace Dal_Repository.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string CompanyName { get; set; } = null!;

    public virtual ICollection<ProductInCart> ProductInCarts { get; set; } = new List<ProductInCart>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
