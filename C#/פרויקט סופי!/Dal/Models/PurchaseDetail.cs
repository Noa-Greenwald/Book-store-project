using System;
using System.Collections.Generic;

namespace Dal_Repository.Models;

public partial class PurchaseDetail
{
    public int PurchaseDetailsId { get; set; }

    public int PurchaseId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Purchase Purchase { get; set; } = null!;
}
