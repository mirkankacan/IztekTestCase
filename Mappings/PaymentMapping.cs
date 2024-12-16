using AutoMapper;
using IztekTestCase.Dtos.PaymentDtos;
using IztekTestCase.Entities;

namespace IztekTestCase.Mappings
{
    public class PaymentMapping : Profile
    {
        public PaymentMapping()
        {
            CreateMap<CreatePaymentDto, Payment>().ReverseMap();
            CreateMap<ResultPaymentDto, VwPaymentWithOrder>().ReverseMap();
        }
    }
}