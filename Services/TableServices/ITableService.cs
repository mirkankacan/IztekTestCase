using IztekTestCase.Dtos.TableDtos;

namespace IztekTestCase.Services.TableServices
{
    public interface ITableService
    {
        Task<List<ResultTableDto>> GetTableListAsync();

        Task<ResultTableDto> GetTableByIdAsync(int id);

        Task CreateTableAsync(CreateTableDto createTableDto);

        Task DeleteTableAsync(int id);

        Task UpdateTableAsync(UpdateTableDto updateTableDto);
    }
}