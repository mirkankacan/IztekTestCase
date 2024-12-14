namespace IztekTestCase.Dtos.OrderDtos
{
    public class UpdateOrderDto
    {
        public Guid OrderId { get; set; }
        public int TableId { get; set; }
        public int OrderStatusId { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public decimal Amount { get; set; }
    }
}