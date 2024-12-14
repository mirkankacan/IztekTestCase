using AutoMapper;
using IztekTestCase.Context;
using IztekTestCase.Dtos.OrderDtos;
using Microsoft.EntityFrameworkCore;

namespace IztekTestCase.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly TestCaseDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(TestCaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            //using var transaction = await _context.Database.BeginTransactionAsync();
            //try
            //{
            //    var mappedOrder = _mapper.Map<Order>(createOrderDto);
            //    mappedOrder.OrderId = Guid.NewGuid();
            //    mappedOrder.CreatedAt = DateTime.UtcNow;

            //    var mappedOrderItems = _mapper.Map<OrderItem>(createOrderItemDto);
            //    await _context.Orders.AddAsync(mappedOrder);
            //    await _context.OrderItems.AddRangeAsync(mappedOrderItems);
            //    await _context.SaveChangesAsync();
            //    await transaction.CommitAsync();
            //}
            //catch (Exception ex)
            //{
            //    await transaction.RollbackAsync();
            //    throw;
            //}
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<ResultOrderDto> GetOrderByIdAsync(Guid id)
        {
            var order = await _context.Orders.Include(x => x.OrderStatus).Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.OrderId == id);
            var mappedOrder = _mapper.Map<ResultOrderDto>(order);
            return mappedOrder;
        }

        public async Task<List<ResultOrderDto>> GetOrderListAsync()
        {
            var orders = await _context.Orders.Include(x => x.OrderStatus).Include(x => x.OrderItems).ToListAsync();
            var mappedOrders = _mapper.Map<List<ResultOrderDto>>(orders);
            return mappedOrders;
        }

        public async Task UpdateOrderAsync(UpdateOrderDto updateOrderDto)
        {
            var order = await _context.Orders.FindAsync(updateOrderDto.OrderId);
            _mapper.Map(updateOrderDto, order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderStatusAsync(UpdateOrderStatusDto updateOrderStatusDto)
        {
            var order = await _context.Orders.FindAsync(updateOrderStatusDto.OrderId);
            _mapper.Map(updateOrderStatusDto, order);
            await _context.SaveChangesAsync();
        }
    }
}