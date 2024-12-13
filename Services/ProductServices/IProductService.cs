using IztekTestCase.Dtos.ProductDto;

namespace IztekTestCase.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetProductListAsync();

        Task<ResultProductDto> GetProductByIdAsync(int id);

        Task CreateProductAsync(CreateProductDto createProductDto);

        Task DeleteProductAsync(int id);

        Task UpdateProductAsync(UpdateProductDto updateProductDto);
    }
}