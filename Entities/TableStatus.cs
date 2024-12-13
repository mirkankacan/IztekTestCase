using System;
using System.Collections.Generic;

namespace IztekTestCase.Entities;

public partial class TableStatus
{
    public int TableStatusId { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Table> Tables { get; set; } = new List<Table>();
}
