using System;
using System.Collections.Generic;

namespace Dal_Repository.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<ProductInCart> ProductInCarts { get; set; } = new List<ProductInCart>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
