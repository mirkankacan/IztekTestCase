using AutoMapper;
using IztekTestCase.Context;
using IztekTestCase.Dtos.TableDtos;
using IztekTestCase.Entities;
using Microsoft.EntityFrameworkCore;

namespace IztekTestCase.Services.TableServices
{
    public class TableService : ITableService
    {
        private readonly TestCaseDbContext _context;
        private readonly IMapper _mapper;

        public TableService(TestCaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateTableAsync(CreateTableDto createTableDto)
        {
            var mappedTable = _mapper.Map<Table>(createTableDto);
            mappedTable.TableStatusId = 1; // Boş
            await _context.Tables.AddAsync(mappedTable);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTableAsync(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
        }

        public async Task<ResultTableDto> GetTableByIdAsync(int id)
        {
            var table = await _context.Tables.Include(x => x.TableStatus).FirstOrDefaultAsync(x => x.TableId == id);
            var mappedTable = _mapper.Map<ResultTableDto>(table);
            return mappedTable;
        }

        public async Task<List<ResultTableDto>> GetTableListAsync()
        {
            var tables = await _context.Tables.Include(x => x.TableStatus).ToListAsync();
            var mappedTables = _mapper.Map<List<ResultTableDto>>(tables);
            return mappedTables;
        }

        public async Task UpdateTableAsync(UpdateTableDto updateTableDto)
        {
            var table = await _context.Tables.FindAsync(updateTableDto.TableId);
            _mapper.Map(updateTableDto, table);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTableStatusAsync(UpdateTableStatusDto updateTableStatusDto)
        {
            var table = await _context.Tables.FindAsync(updateTableStatusDto.TableId);
            _mapper.Map(updateTableStatusDto, table);
            await _context.SaveChangesAsync();
        }
    }
}