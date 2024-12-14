namespace IztekTestCase.Dtos.PaymentDtos
{
    public class CreatePaymentDto
    {
        public Guid OrderId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int PaymentStatusId { get; set; }
    }
}