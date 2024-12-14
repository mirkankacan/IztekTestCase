namespace IztekTestCase.Dtos.OrderDtos
{
    public class CreateOrderDto
    {
        public int TableId { get; set; }

        public int OrderStatusId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public decimal Amount { get; set; }
    }
}