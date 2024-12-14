using IztekTestCase.Dtos.OrderItemDtos;

namespace IztekTestCase.Dtos.OrderDtos
{
    public class CreateOrderDto
    {
        public int TableId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public List<CreateOrderItemDto> OrderItems { get; set; }
    }
}