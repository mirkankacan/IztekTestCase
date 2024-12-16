using IztekTestCase.Dtos.OrderItemDtos;

namespace IztekTestCase.Services.OrderItemServices
{
    public interface IOrderItemService
    {
        Task<List<ResultOrderItemDto>> GetOrderItemListAsync();

        Task<ResultOrderItemDto> GetOrderItemByIdAsync(int id);

        Task<decimal> CreateOrderItemAsync(Guid orderId, List<CreateOrderItemDto> createOrderItemDto);

        Task DeleteOrderItemAsync(int id);

        Task<decimal> UpdateOrderItemAsync(List<UpdateOrderItemDto> updateOrderItemDto);
    }
}