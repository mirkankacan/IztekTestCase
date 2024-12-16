using System;
using System.Collections.Generic;

namespace IztekTestCase.Entities;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public Guid OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Total { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
