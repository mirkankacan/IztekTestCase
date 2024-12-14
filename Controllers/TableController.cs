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
            var values = await _tableService.GetTableListAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableById(int id)
        {
            var value = await _tableService.GetTableByIdAsync(id);

            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTable(int id)
        {
            await _tableService.DeleteTableAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTable(CreateTableDto createTableDto)
        {
            await _tableService.CreateTableAsync(createTableDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTable(UpdateTableDto updateTableDto)
        {
            await _tableService.UpdateTableAsync(updateTableDto);
            return Ok();
        }
        [HttpPut("UpdateTableStatus")]
        public async Task<IActionResult> UpdateTableStatus(UpdateTableStatusDto updateTableStatusDto)
        {
            await _tableService.UpdateTableStatusAsync(updateTableStatusDto);
            return Ok();
        }
    }
}