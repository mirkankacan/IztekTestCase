using AutoMapper;
using IztekTestCase.Dtos.TableStatusDtos;
using IztekTestCase.Entities;

namespace IztekTestCase.Mappings
{
    public class TableStatusMapping : Profile
    {
        public TableStatusMapping()
        {
            CreateMap<ResultTableStatusDto, TableStatus>().ReverseMap();
        }
    }
}