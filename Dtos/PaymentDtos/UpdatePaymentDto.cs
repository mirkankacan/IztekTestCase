namespace IztekTestCase.Dtos.PaymentDtos
{
    public class UpdatePaymentDto
    {
        public Guid PaymentId { get; set; }

        public Guid OrderId { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int PaymentStatusId { get; set; }
    }
}