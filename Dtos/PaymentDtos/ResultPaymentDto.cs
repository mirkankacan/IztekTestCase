using IztekTestCase.Dtos.OrderDtos;

namespace IztekTestCase.Dtos.PaymentDtos
{
    public class ResultPaymentDto
    {
        public Guid PaymentId { get; set; }
        public decimal PaidAmount { get; set; }


        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public ResultOrderDto Order { get; set; }

    }
}