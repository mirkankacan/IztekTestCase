using System;
using System.Collections.Generic;

namespace IztekTestCase.Entities;

public partial class VwPaymentWithOrder
{
    public Guid PaymentId { get; set; }

    public DateTime? PaymentCreatedAt { get; set; }

    public DateTime? PaymentUpdatedAt { get; set; }

    public decimal PaidAmount { get; set; }

    public Guid OrderId { get; set; }

    public int TableId { get; set; }

    public int TableNo { get; set; }

    public int OrderStatusId { get; set; }

    public string OrderStatus { get; set; } = null!;

    public DateTime? OrderCreatedAt { get; set; }

    public DateTime? OrderUpdatedAt { get; set; }

    public decimal TotalAmount { get; set; }
}
