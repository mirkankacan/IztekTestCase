﻿using System;
using System.Collections.Generic;

namespace IztekTestCase.Entities;

public partial class PaymentStatus
{
    public int PaymentStatusId { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
