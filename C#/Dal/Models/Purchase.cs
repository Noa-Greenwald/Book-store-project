using System;
using System.Collections.Generic;

namespace Dal_Repository.Models;

public partial class Purchase
{
    public int PurchaseId { get; set; }

    public int CustomerId { get; set; }

    public DateTime PurchaseDate { get; set; }

    public decimal AmountPay { get; set; }

    public string? Remark { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
}
