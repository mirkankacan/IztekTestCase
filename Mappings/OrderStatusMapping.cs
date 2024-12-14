using AutoMapper;
using IztekTestCase.Dtos.OrderStatusDto;
using IztekTestCase.Entities;

namespace IztekTestCase.Mappings
{
    public class OrderStatusMapping : Profile
    {
        public OrderStatusMapping()
        {
            CreateMap<ResultOrderStatusDto, OrderStatus>().ReverseMap();
        }
    }
}