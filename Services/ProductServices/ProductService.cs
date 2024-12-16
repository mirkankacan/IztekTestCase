using AutoMapper;
using IztekTestCase.Context;
using IztekTestCase.Dtos.ProductDto;
using IztekTestCase.Entities;
using Microsoft.EntityFrameworkCore;

namespace IztekTestCase.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly TestCaseDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(TestCaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            try
            {
                var mappedProduct = _mapper.Map<Product>(createProductDto);
                await _context.Products.AddAsync(mappedProduct);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResultProductDto> DecreaseStockForOrderAsync(int id, int quantity)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            product.StockQuantity = product.StockQuantity - quantity;
            var mappedProduct = _mapper.Map<ResultProductDto>(product);
            return mappedProduct;
        }

        public async Task<ResultProductDto> IncreaseStockForOrderAsync(int id, int quantity)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            product.StockQuantity = product.StockQuantity + quantity;
            var mappedProduct = _mapper.Map<ResultProductDto>(product);
            return mappedProduct;
        }

        public async Task DeleteProductAsync(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResultProductDto> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.ProductId == id);
                var mappedProduct = _mapper.Map<ResultProductDto>(product);
                return mappedProduct;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ResultProductDto>> GetProductListAsync()
        {
            try
            {
                var products = await _context.Products.Include(x => x.Category).ToListAsync();
                var mappedProducts = _mapper.Map<List<ResultProductDto>>(products);
                return mappedProducts;
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            try
            {
                var product = await _context.Products.FindAsync(updateProductDto.ProductId);
                _mapper.Map(updateProductDto, product);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}