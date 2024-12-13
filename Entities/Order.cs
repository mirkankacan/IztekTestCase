using System;
using System.Collections.Generic;

namespace IztekTestCase.Entities;

public partial class Order
{
    public Guid OrderId { get; set; }

    public int TableId { get; set; }

    public int OrderStatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public decimal Amount { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual OrderStatus OrderStatus { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Table Table { get; set; } = null!;
}
