using AutoMapper;
using IztekTestCase.Dtos.OrderDtos;
using IztekTestCase.Entities;

namespace IztekTestCase.Mappings
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<CreateOrderDto, Order>().ReverseMap();
            CreateMap<UpdateOrderDto, Order>().ReverseMap();
            CreateMap<ResultOrderDto, Order>().ReverseMap();
        }
    }
}