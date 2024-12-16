using AutoMapper;
using IztekTestCase.Context;
using IztekTestCase.Dtos.OrderDtos;
using IztekTestCase.Dtos.OrderStatusDto;
using IztekTestCase.Dtos.TableDtos;
using IztekTestCase.Entities;
using IztekTestCase.Services.OrderItemServices;
using IztekTestCase.Services.TableServices;
using Microsoft.EntityFrameworkCore;

namespace IztekTestCase.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly TestCaseDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITableService _tableService;
        private readonly IOrderItemService _orderItemService;

        public OrderService(TestCaseDbContext context, IMapper mapper, ITableService tableService, IOrderItemService orderItemService)
        {
            _context = context;
            _mapper = mapper;
            _tableService = tableService;
            _orderItemService = orderItemService;
        }

        public async Task CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                if (!createOrderDto.OrderItems.Any())
                {
                    throw new Exception("Siparişe ürün ekleyiniz");
                }
                var table = await _context.Tables.FirstOrDefaultAsync(x => x.TableId == createOrderDto.TableId);
                if (table.TableStatusId == 2)
                {
                    throw new Exception("Masa dolu sipariş oluşturamazsınız");
                }
                table.TableStatusId = 2; // Masa dolu

                var mappedOrder = _mapper.Map<Order>(createOrderDto);
                mappedOrder.OrderItems = null;
                mappedOrder.OrderId = Guid.NewGuid();
                mappedOrder.CreatedAt = DateTime.UtcNow;
                mappedOrder.OrderStatusId = 1; // Sipariş alındı

                await _context.Orders.AddAsync(mappedOrder);
                await _context.SaveChangesAsync();

                var totalAmount = await _orderItemService.CreateOrderItemAsync(mappedOrder.OrderId, createOrderDto.OrderItems);
                mappedOrder.Amount = totalAmount;

                _context.Orders.Update(mappedOrder);
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
                order.UpdatedAt = DateTime.UtcNow;
                order.OrderStatusId = updateOrderDto.OrderStatusId;
                if (order.TableId != updateOrderDto.TableId)
                {
                    var nextTable = await _tableService.GetTableByIdAsync(updateOrderDto.TableId);
                    if (nextTable.TableStatus.TableStatusId == 2 || nextTable.TableStatus.TableStatusId == 3)
                    {
                        throw new Exception("Yeni masa dolu ya da rezerve edilmiş");
                    }
                    var prevTable = await _tableService.GetTableByIdAsync(order.TableId);
                    var prevDto = new UpdateTableStatusDto()
                    {
                        TableId = prevTable.TableId,
                        TableStatusId = 1
                    };
                    await _tableService.UpdateTableStatusAsync(prevDto);
                    var nextDto = new UpdateTableStatusDto()
                    {
                        TableId = nextTable.TableId,
                        TableStatusId = 2
                    };
                    await _tableService.UpdateTableStatusAsync(nextDto);

                    order.TableId = updateOrderDto.TableId;
                }

                if (updateOrderDto.OrderItems.Any())
                {
                    order.Amount += await _orderItemService.UpdateOrderItemAsync(updateOrderDto.OrderItems);
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
            order.OrderStatusId = updateOrderStatusDto.OrderStatusId;
            await _context.SaveChangesAsync();
        }
    }
}