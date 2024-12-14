using IztekTestCase.Dtos.PaymentDtos;

namespace IztekTestCase.Services.PaymentServices
{
    public interface IPaymentService
    {
        Task<List<ResultPaymentDto>> GetPaymentListAsync();

        Task<ResultPaymentDto> GetPaymentByIdAsync(Guid id);

        Task CreatePaymentAsync(CreatePaymentDto createPaymentDto);

        Task DeletePaymentAsync(Guid id);

        Task UpdatePaymentAsync(UpdatePaymentDto updatePaymentDto);

        Task UpdatePaymentStatusAsync(UpdatePaymentStatusDto updatePaymentStatusDto);
    }
}