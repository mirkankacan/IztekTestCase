using AutoMapper;
using IztekTestCase.Dtos.OrderItemDtos;
using IztekTestCase.Entities;

namespace IztekTestCase.Mappings
{
    public class OrderItemMapping : Profile
    {
        public OrderItemMapping()
        {
            CreateMap<CreateOrderItemDto, OrderItem>().ReverseMap();
            CreateMap<ResultOrderItemDto, OrderItem>().ReverseMap();
            CreateMap<UpdateOrderItemDto, OrderItem>().ReverseMap();
        }
    }
}