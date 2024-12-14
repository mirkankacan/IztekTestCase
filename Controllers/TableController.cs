using IztekTestCase.Dtos.TableDtos;
using IztekTestCase.Services.TableServices;
using Microsoft.AspNetCore.Mvc;

namespace IztekTestCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTableList()
        {
            try
            {
                var values = await _tableService.GetTableListAsync();

                return Ok(values);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableById(int id)
        {
            try
            {
                var value = await _tableService.GetTableByIdAsync(id);

                return Ok(value);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTable(int id)
        {
            try
            {
                await _tableService.DeleteTableAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTable(CreateTableDto createTableDto)
        {
            try
            {
                await _tableService.CreateTableAsync(createTableDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTable(UpdateTableDto updateTableDto)
        {
            try
            {
                await _tableService.UpdateTableAsync(updateTableDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message}");
            }
        }

        [HttpPut("UpdateTableStatus")]
        public async Task<IActionResult> UpdateTableStatus(UpdateTableStatusDto updateTableStatusDto)
        {
            try
            {
                await _tableService.UpdateTableStatusAsync(updateTableStatusDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hata: {ex.Message}");
            }
        }
    }
}