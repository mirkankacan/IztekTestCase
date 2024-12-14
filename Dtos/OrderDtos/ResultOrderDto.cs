using IztekTestCase.Dtos.OrderItemDtos;
using IztekTestCase.Dtos.OrderStatusDto;
using IztekTestCase.Dtos.TableDtos;

namespace IztekTestCase.Dtos.OrderDtos
{
    public class ResultOrderDto
    {
        public Guid OrderId { get; set; }



        public ResultOrderStatusDto OrderStatus { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public decimal Amount { get; set; }
        public ResultTableDto Table { get; set; }
        public List<ResultOrderItemDto> OrderItems { get; set; }
    }
}