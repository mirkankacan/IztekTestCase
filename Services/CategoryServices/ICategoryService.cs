using IztekTestCase.Dtos.CategoryDto;

namespace IztekTestCase.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetCategoryListAsync();

        Task<ResultCategoryDto> GetCategoryByIdAsync(int id);

        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);

        Task DeleteCategoryAsync(int id);

        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    }
}