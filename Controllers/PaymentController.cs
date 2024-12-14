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
            var values = await _paymentService.GetPaymentListAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(Guid id)
        {
            var value = await _paymentService.GetPaymentByIdAsync(id);

            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(CreatePaymentDto createPaymentDto)
        {
            await _paymentService.CreatePaymentAsync(createPaymentDto);
            return Ok();
        }
    }
}