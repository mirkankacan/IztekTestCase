using IztekTestCase.Dtos.PaymentDtos;
using IztekTestCase.Services.PaymentServices;
using Microsoft.AspNetCore.Mvc;

namespace IztekTestCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService PaymentService)
        {
            _paymentService = PaymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentList()
        {
            try
            {
                var values = await _paymentService.GetPaymentListAsync();

                return Ok(values);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message} - {ex.InnerException}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(Guid id)
        {
            try
            {
                var value = await _paymentService.GetPaymentByIdAsync(id);

                return Ok(value);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message} - {ex.InnerException}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(CreatePaymentDto createPaymentDto)
        {
            try
            {
                await _paymentService.CreatePaymentAsync(createPaymentDto);
                return Ok("Ödeme başarılı bir şekilde yapıldı");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message} - {ex.InnerException}");
            }
        }
    }
}