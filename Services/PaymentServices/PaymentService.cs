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
            var mappedPayment = _mapper.Map<Payment>(createPaymentDto);
            mappedPayment.PaymentId = Guid.NewGuid();
            mappedPayment.CreatedAt = DateTime.UtcNow;
            await _context.Payments.AddAsync(mappedPayment);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePaymentAsync(Guid id)
        {
            var payment = await _context.Payments.FindAsync(id);
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<ResultPaymentDto> GetPaymentByIdAsync(Guid id)
        {
            var payment = await _context.Payments.Include(x => x.PaymentStatus).Include(x => x.Order).FirstOrDefaultAsync(x => x.PaymentId == id);
            var mappedPayment = _mapper.Map<ResultPaymentDto>(payment);
            return mappedPayment;
        }

        public async Task<List<ResultPaymentDto>> GetPaymentListAsync()
        {
            var payments = await _context.Payments.Include(x => x.PaymentStatus).Include(x => x.Order).ToListAsync();
            var mappedPayments = _mapper.Map<List<ResultPaymentDto>>(payments);
            return mappedPayments;
        }

        public async Task UpdatePaymentAsync(UpdatePaymentDto updatePaymentDto)
        {
            var payment = await _context.Payments.FindAsync(updatePaymentDto.PaymentId);
            _mapper.Map(updatePaymentDto, payment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePaymentStatusAsync(UpdatePaymentStatusDto updatePaymentStatusDto)
        {
            var payment = await _context.Payments.FindAsync(updatePaymentStatusDto.PaymentId);
            _mapper.Map(updatePaymentStatusDto, payment);
            await _context.SaveChangesAsync();
        }
    }
}