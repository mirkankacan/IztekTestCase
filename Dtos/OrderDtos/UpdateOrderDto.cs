using IztekTestCase.Dtos.OrderItemDtos;

namespace IztekTestCase.Dtos.OrderDtos
{
    public class UpdateOrderDto
    {
        public Guid OrderId { get; set; }
        public int TableId { get; set; }
        public int OrderStatusId { get; set; }
        public List<UpdateOrderItemDto> OrderItems { get; set; } = new List<UpdateOrderItemDto>();
    }
}