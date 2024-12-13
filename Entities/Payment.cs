using System;
using System.Collections.Generic;

namespace IztekTestCase.Entities;

public partial class Payment
{
    public Guid PaymentId { get; set; }

    public Guid OrderId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int PaymentStatusId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual PaymentStatus PaymentStatus { get; set; } = null!;
}
