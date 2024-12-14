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

                var order = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == createPaymentDto.OrderId);
                var oldAmounts = await _context.Payments.Where(x => x.OrderId == createPaymentDto.OrderId).SumAsync(x => x.PaidAmount);
                var totalPaidAmount = createPaymentDto.PaidAmount + oldAmounts;
                if (totalPaidAmount < order.Amount)
                {
                    order.OrderStatusId = 4; // Tamamı ödenmedi
                }
                else if (totalPaidAmount == order.Amount)
                {
                    order.OrderStatusId = 2; // Tamamı ödendi
                }
                else
                {
                    throw new Exception("Tutarın üstünde tahsil edildi");
                }
                await _context.Payments.AddAsync(mappedPayment);
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