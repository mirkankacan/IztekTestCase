using AutoMapper;
using IztekTestCase.Dtos.ProductDto;
using IztekTestCase.Entities;

namespace IztekTestCase.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
            CreateMap<ResultProductDto, Product>().ReverseMap();
        }
    }
}