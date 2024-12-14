using AutoMapper;
using IztekTestCase.Dtos.TableDtos;
using IztekTestCase.Entities;

namespace IztekTestCase.Mappings
{
    public class TableMapping : Profile
    {
        public TableMapping()
        {
            CreateMap<CreateTableDto, Table>().ReverseMap();
            CreateMap<UpdateTableDto, Table>().ReverseMap();
            CreateMap<ResultTableDto, Table>().ReverseMap();
            CreateMap<ResultTableStatusDto, TableStatus>().ReverseMap();
        }
    }
}