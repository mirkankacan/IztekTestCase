using AutoMapper;
using IztekTestCase.Context;
using IztekTestCase.Dtos.CategoryDto;
using IztekTestCase.Entities;
using Microsoft.EntityFrameworkCore;

namespace IztekTestCase.Services.CategoryServices
{
    public class CategoryService : ICategoryService

    {
        private readonly TestCaseDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(TestCaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            try
            {
                var mappedCategory = _mapper.Map<Category>(createCategoryDto);
                await _context.Categories.AddAsync(mappedCategory);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResultCategoryDto> GetCategoryByIdAsync(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);
                var mappedCategory = _mapper.Map<ResultCategoryDto>(category);
                return mappedCategory;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ResultCategoryDto>> GetCategoryListAsync()
        {
            try
            {
                var categories = await _context.Categories.ToListAsync();
                var mappedCategorys = _mapper.Map<List<ResultCategoryDto>>(categories);
                return mappedCategorys;
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                var category = await _context.Categories.FindAsync(updateCategoryDto.CategoryId);
                _mapper.Map(updateCategoryDto, category);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}