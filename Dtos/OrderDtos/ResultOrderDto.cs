using IztekTestCase.Dtos.OrderItemDtos;
using IztekTestCase.Dtos.TableDtos;

namespace IztekTestCase.Dtos.OrderDtos
{
    public class ResultOrderDto
    {
        public Guid OrderId { get; set; }

        public ResultTableDto Table { get; set; }

        public int OrderStatusId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public decimal Amount { get; set; }
        public List<ResultOrderItemDto> OrderItems { get; set; }
    }
}