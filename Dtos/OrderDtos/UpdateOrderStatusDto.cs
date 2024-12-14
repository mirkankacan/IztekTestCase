namespace IztekTestCase.Dtos.OrderDtos
{
    public class UpdateOrderStatusDto
    {
        public Guid OrderId { get; set; }
        public int OrderStatusId { get; set; }
    }
}