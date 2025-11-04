using System;
using System.Collections.Generic;

namespace Dal_Repository.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Phone { get; set; }

    public string Email { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
