using IztekTestCase.Dtos.OrderItemDtos;
using IztekTestCase.Services.OrderItemServices;
using Microsoft.AspNetCore.Mvc;

namespace IztekTestCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderItemList()
        {
            try
            {
                var values = await _orderItemService.GetOrderItemListAsync();

                return Ok(values);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message} - {ex.InnerException}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItemById(int id)
        {
            try
            {
                var value = await _orderItemService.GetOrderItemByIdAsync(id);

                return Ok(value);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message} - {ex.InnerException}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            try
            {
                await _orderItemService.DeleteOrderItemAsync(id);
                return Ok("Sipariş ürünü başarılı bir şekilde silindi");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message} - {ex.InnerException}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderItem(Guid orderId, List<CreateOrderItemDto> createOrderItemDto)
        {
            try
            {
                await _orderItemService.CreateOrderItemAsync(orderId, createOrderItemDto);
                return Ok("Sipariş ürünü başarılı bir şekilde oluşturuldu");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message} - {ex.InnerException}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderItem(List<UpdateOrderItemDto> updateOrderItemDto)
        {
            try
            {
                await _orderItemService.UpdateOrderItemAsync(updateOrderItemDto);
                return Ok("Sipariş ürünü başarılı bir şekilde güncellendi");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message} - {ex.InnerException}");
            }
        }
    }
}