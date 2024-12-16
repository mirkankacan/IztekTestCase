using AutoMapper;
using IztekTestCase.Context;
using IztekTestCase.Dtos.OrderItemDtos;
using IztekTestCase.Entities;
using IztekTestCase.Services.ProductServices;
using Microsoft.EntityFrameworkCore;

namespace IztekTestCase.Services.OrderItemServices
{
    public class OrderItemService : IOrderItemService
    {
        private readonly TestCaseDbContext _context;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public OrderItemService(TestCaseDbContext context, IMapper mapper, IProductService productService)
        {
            _context = context;
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<decimal> CreateOrderItemAsync(Guid orderId, List<CreateOrderItemDto> createOrderItemDto)
        {
            try
            {
                var orderItems = new List<OrderItem>();
                foreach (var item in createOrderItemDto)
                {
                    var product = await _productService.DecreaseStockForOrderAsync(item.ProductId, item.Quantity);
                    var orderItem = new OrderItem
                    {
                        OrderId = orderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = product.Price,
                        Total = item.Quantity * product.Price,
                        CreatedAt = DateTime.UtcNow,
                    };
                    orderItems.Add(orderItem);
                }
                await _context.OrderItems.AddRangeAsync(orderItems);
                await _context.SaveChangesAsync();
                return orderItems.Sum(x => x.Total);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteOrderItemAsync(int id)
        {
            try
            {
                var orderItem = await _context.OrderItems.FindAsync(id);
                _context.OrderItems.Remove(orderItem);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResultOrderItemDto> GetOrderItemByIdAsync(int id)
        {
            try
            {
                var orderItem = await _context.OrderItems.Include(x => x.Product).ThenInclude(x => x.Category).FirstOrDefaultAsync(x => x.OrderItemId == id);
                var mappedOrderItem = _mapper.Map<ResultOrderItemDto>(orderItem);
                return mappedOrderItem;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ResultOrderItemDto>> GetOrderItemListAsync()
        {
            try
            {
                var orderItems = await _context.OrderItems.Include(x => x.Product).ThenInclude(x => x.Category).ToListAsync();
                var mappedOrderItems = _mapper.Map<List<ResultOrderItemDto>>(orderItems);
                return mappedOrderItems;
            }
            catch
            {
                throw;
            }
        }

        public async Task<decimal> UpdateOrderItemAsync(List<UpdateOrderItemDto> updateOrderItemDto)
        {
            try
            {
                var orderItems = new List<OrderItem>();
                foreach (var item in updateOrderItemDto)
                {
                    var orderItem = await _context.OrderItems.Include(x => x.Product).FirstOrDefaultAsync(x => x.OrderItemId == item.OrderItemId);
                    if (orderItem.Quantity != item.Quantity)
                    {
                        var newQuantity = orderItem.Quantity - item.Quantity;
                        await _productService.IncreaseStockForOrderAsync(orderItem.Product.ProductId, newQuantity);
                    }
                    orderItem.Quantity = item.Quantity;
                    orderItem.UnitPrice = orderItem.Product.Price;
                    orderItem.Total = orderItem.Product.Price * item.Quantity;
                    orderItem.UpdatedAt = DateTime.UtcNow;
                    orderItems.Add(orderItem);
                }
                await _context.SaveChangesAsync();
                return orderItems.Sum(x => x.Total);
            }
            catch
            {
                throw;
            }
        }
    }
}