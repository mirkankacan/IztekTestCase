using AutoMapper;
using IztekTestCase.Context;
using IztekTestCase.Dtos.OrderDtos;
using IztekTestCase.Dtos.OrderStatusDto;
using IztekTestCase.Entities;
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
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var mappedOrder = _mapper.Map<Order>(createOrderDto);
                mappedOrder.OrderId = Guid.NewGuid();
                mappedOrder.CreatedAt = DateTime.UtcNow;
                mappedOrder.OrderStatusId = 1; // Sipariş alındı

                if (createOrderDto.OrderItems.Any())
                {
                    var orderItems = new List<OrderItem>();
                    foreach (var item in createOrderDto.OrderItems)
                    {
                        var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == item.ProductId);
                        product.StockQuantity = product.StockQuantity - item.Quantity;
                        var orderItem = new OrderItem
                        {
                            OrderId = mappedOrder.OrderId,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            UnitPrice = product.Price,
                            Total = item.Quantity * product.Price,
                        };
                        orderItems.Add(orderItem);
                    }
                    mappedOrder.OrderItems = orderItems;
                    mappedOrder.Amount = orderItems.Sum(x => x.Total);
                }

                var table = await _context.Tables.FirstOrDefaultAsync(x => x.TableId == createOrderDto.TableId);
                table.TableStatusId = 2; // Masa dolu

                await _context.Orders.AddAsync(mappedOrder);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResultOrderDto> GetOrderByIdAsync(Guid id)
        {
            try
            {
                var order = await _context.Orders.Include(x => x.OrderStatus).Include(x => x.OrderItems).ThenInclude(x => x.Product).ThenInclude(x => x.Category).Include(x => x.Table).ThenInclude(x => x.TableStatus).FirstOrDefaultAsync(x => x.OrderId == id);
                var mappedOrder = _mapper.Map<ResultOrderDto>(order);
                return mappedOrder;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ResultOrderDto>> GetOrderListAsync()
        {
            try
            {
                var orders = await _context.Orders.Include(x => x.OrderStatus).Include(x => x.OrderItems).ThenInclude(x => x.Product).ThenInclude(x => x.Category).Include(x => x.Table).ThenInclude(x => x.TableStatus).ToListAsync();
                var mappedOrders = _mapper.Map<List<ResultOrderDto>>(orders);
                return mappedOrders;
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateOrderAsync(UpdateOrderDto updateOrderDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var order = await _context.Orders.Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.OrderId == updateOrderDto.OrderId);
                if (order.TableId != updateOrderDto.TableId)
                {
                    var nextTable = await _context.Tables.FirstOrDefaultAsync(x => x.TableId == updateOrderDto.TableId);
                    if (nextTable.TableStatusId == 2 || nextTable.TableStatusId == 3)
                    {
                        throw new Exception("Yeni masa dolu ya da rezerve edilmiş");
                    }
                    var prevTable = await _context.Tables.FirstOrDefaultAsync(x => x.TableId == order.TableId);
                    prevTable.TableStatusId = 1;
                    nextTable.TableStatusId = 2;
                    order.TableId = updateOrderDto.TableId;
                }
                order.UpdatedAt = DateTime.UtcNow;
                order.OrderStatusId = updateOrderDto.OrderStatusId;

                if (updateOrderDto.OrderItems.Any())
                {
                    foreach (var item in updateOrderDto.OrderItems)
                    {
                        var orderItem = order.OrderItems.FirstOrDefault(x => x.OrderItemId == item.OrderItemId);
                        if (orderItem.Quantity != item.Quantity)
                        {
                            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == orderItem.ProductId);
                            product.StockQuantity = product.StockQuantity + (orderItem.Quantity - item.Quantity);
                        }
                        orderItem.Quantity = item.Quantity;

                        orderItem.Total = orderItem.UnitPrice * item.Quantity;
                    }
                    order.Amount = order.OrderItems.Sum(x => x.Total);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateOrderStatusAsync(UpdateOrderStatusDto updateOrderStatusDto)
        {
            var order = await _context.Orders.FindAsync(updateOrderStatusDto.OrderId);
            order.UpdatedAt = DateTime.UtcNow;
            _mapper.Map(updateOrderStatusDto, order);
            await _context.SaveChangesAsync();
        }
    }
}