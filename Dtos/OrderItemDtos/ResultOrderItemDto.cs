using IztekTestCase.Dtos.ProductDto;

namespace IztekTestCase.Dtos.OrderItemDtos
{
    public class ResultOrderItemDto
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }

        public decimal Total { get; set; }
        public ResultProductDto Product { get; set; }
    }
}