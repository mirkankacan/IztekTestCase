namespace IztekTestCase.Entities;

public partial class Payment
{
    public Guid PaymentId { get; set; }

    public Guid OrderId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public decimal PaidAmount { get; set; }

    public virtual Order Order { get; set; } = null!;
}