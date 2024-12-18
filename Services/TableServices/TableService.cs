﻿using AutoMapper;
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
            try
            {
                var mappedTable = _mapper.Map<Table>(createTableDto);
                mappedTable.TableStatusId = 1; // Boş
                await _context.Tables.AddAsync(mappedTable);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteTableAsync(int id)
        {
            try
            {
                var table = await _context.Tables.FindAsync(id);
                _context.Tables.Remove(table);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResultTableDto> GetTableByIdAsync(int id)
        {
            try
            {
                var table = await _context.Tables.Include(x => x.TableStatus).FirstOrDefaultAsync(x => x.TableId == id);
                var mappedTable = _mapper.Map<ResultTableDto>(table);
                return mappedTable;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ResultTableDto>> GetTableListAsync()
        {
            try
            {
                var tables = await _context.Tables.Include(x => x.TableStatus).ToListAsync();
                var mappedTables = _mapper.Map<List<ResultTableDto>>(tables);
                return mappedTables;
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateTableAsync(UpdateTableDto updateTableDto)
        {
            try
            {
                var table = await _context.Tables.FindAsync(updateTableDto.TableId);
                _mapper.Map(updateTableDto, table);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateTableStatusAsync(UpdateTableStatusDto updateTableStatusDto)
        {
            try
            {
                var table = await _context.Tables.FindAsync(updateTableStatusDto.TableId);
                table.TableStatusId = updateTableStatusDto.TableStatusId;
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}