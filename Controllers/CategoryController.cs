﻿using IztekTestCase.Dtos.CategoryDto;
using IztekTestCase.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace IztekTestCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            try
            {
                var values = await _categoryService.GetCategoryListAsync();

                return Ok(values);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message} - {ex.InnerException}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var value = await _categoryService.GetCategoryByIdAsync(id);

                return Ok(value);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message} - {ex.InnerException}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(id);
                return Ok("Kategori başarılı bir şekilde silindi");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message} - {ex.InnerException}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            try
            {
                await _categoryService.CreateCategoryAsync(createCategoryDto);
                return Ok("Kategori başarılı bir şekilde oluşturuldu");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message} - {ex.InnerException}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                await _categoryService.UpdateCategoryAsync(updateCategoryDto);
                return Ok("Kategori başarılı bir şekilde güncellendi");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message} - {ex.InnerException}");
            }
        }
    }
}