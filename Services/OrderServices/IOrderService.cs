using IztekTestCase.Dtos.OrderDtos;
using IztekTestCase.Dtos.OrderStatusDto;

namespace IztekTestCase.Services.OrderServices
{
    public interface IOrderService
    {
        Task<List<ResultOrderDto>> GetOrderListAsync();

        Task<ResultOrderDto> GetOrderByIdAsync(Guid id);

        Task CreateOrderAsync(CreateOrderDto createOrderDto);

        Task DeleteOrderAsync(Guid id);

        Task UpdateOrderAsync(UpdateOrderDto updateOrderDto);

        Task UpdateOrderStatusAsync(UpdateOrderStatusDto updateOrderStatusDto);
    }
}