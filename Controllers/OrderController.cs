using IztekTestCase.Dtos.OrderDtos;
using IztekTestCase.Services.OrderServices;
using Microsoft.AspNetCore.Mvc;

namespace IztekTestCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderList()
        {
            try
            {
                var values = await _orderService.GetOrderListAsync();

                return Ok(values);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message} - {ex.InnerException}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            try
            {
                var value = await _orderService.GetOrderByIdAsync(id);

                return Ok(value);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message} - {ex.InnerException}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            try
            {
                await _orderService.DeleteOrderAsync(id);
                return Ok("Sipariş başarılı bir şekilde silindi");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message} - {ex.InnerException}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            try
            {
                await _orderService.CreateOrderAsync(createOrderDto);
                return Ok("Sipariş başarılı bir şekilde oluşturuldu");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message} - {ex.InnerException}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            try
            {
                await _orderService.UpdateOrderAsync(updateOrderDto);
                return Ok("Sipariş başarılı bir şekilde güncellendi");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message} - {ex.InnerException}");
            }
        }
    }
}