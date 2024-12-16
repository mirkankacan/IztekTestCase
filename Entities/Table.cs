using System;
using System.Collections.Generic;

namespace IztekTestCase.Entities;

public partial class Table
{
    public int TableId { get; set; }

    public int TableNo { get; set; }

    public int TableStatusId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual TableStatus TableStatus { get; set; } = null!;
}
