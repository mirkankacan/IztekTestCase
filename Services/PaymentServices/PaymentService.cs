using AutoMapper;
using IztekTestCase.Context;
using IztekTestCase.Dtos.PaymentDtos;
using IztekTestCase.Entities;
using Microsoft.EntityFrameworkCore;

namespace IztekTestCase.Services.PaymentServices
{
    public class PaymentService : IPaymentService
    {
        private readonly TestCaseDbContext _context;
        private readonly IMapper _mapper;

        public PaymentService(TestCaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreatePaymentAsync(CreatePaymentDto createPaymentDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var mappedPayment = _mapper.Map<Payment>(createPaymentDto);
                mappedPayment.PaymentId = Guid.NewGuid();
                mappedPayment.CreatedAt = DateTime.UtcNow;
                await _context.Payments.AddAsync(mappedPayment);

                var order = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == createPaymentDto.OrderId);
                order.OrderStatusId = 2; // Ödeme yapıldı
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<ResultPaymentDto> GetPaymentByIdAsync(Guid id)
        {
            try
            {
                var payment = await _context.Payments.Include(x => x.Order).FirstOrDefaultAsync(x => x.PaymentId == id);
                var mappedPayment = _mapper.Map<ResultPaymentDto>(payment);
                return mappedPayment;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ResultPaymentDto>> GetPaymentListAsync()
        {
            try
            {
                var payments = await _context.Payments.Include(x => x.Order).ToListAsync();
                var mappedPayments = _mapper.Map<List<ResultPaymentDto>>(payments);
                return mappedPayments;
            }
            catch
            {
                throw;
            }
        }
    }
}