using AutoMapper;
using IztekTestCase.Dtos.CategoryDto;
using IztekTestCase.Entities;

namespace IztekTestCase.Mappings
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<ResultCategoryDto, Category>().ReverseMap();
        }
    }
}