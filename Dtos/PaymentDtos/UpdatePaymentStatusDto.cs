namespace IztekTestCase.Dtos.PaymentDtos
{
    public class UpdatePaymentStatusDto
    {
        public Guid PaymentId { get; set; }
        public int PaymentStatusId { get; set; }
    }
}