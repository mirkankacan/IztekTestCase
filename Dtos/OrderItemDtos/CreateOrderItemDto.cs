namespace IztekTestCase.Dtos.OrderItemDtos
{
    public class CreateOrderItemDto
    {
        public int OrderItemId { get; set; }

        public Guid OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }
    }
}