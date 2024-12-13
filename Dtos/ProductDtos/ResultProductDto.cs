using IztekTestCase.Dtos.CategoryDto;

namespace IztekTestCase.Dtos.ProductDto
{
    public class ResultProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public ResultCategoryDto Category { get; set; }
    }
}