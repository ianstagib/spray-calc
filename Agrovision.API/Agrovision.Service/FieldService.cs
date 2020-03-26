using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Agrovision.Data;
using Agrovision.Dto;
using Agrovision.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Agrovision.Service
{
    public class FieldService : IFieldService
    {
        private readonly SprayCalcDbContext _dbContext;

        public FieldService(SprayCalcDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Field>> GetFieldListAsync()
        {
            return await _dbContext.Fields.ToListAsync();
        }
        
        public async Task<Field> GetFieldAsync(int id)
        {
            return await _dbContext.Fields.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddFieldAsync(Field field)
        {
            await _dbContext.Fields.AddAsync(field);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteFieldAsync(int id)
        {
            var itemToDelete = await _dbContext.Fields.FirstOrDefaultAsync(x => x.Id == id);
            
            if (itemToDelete == null) return;
            
            _dbContext.Fields.Remove(itemToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateFieldAsync(Field input)
        {
            _dbContext.Fields.Update(input);
            await _dbContext.SaveChangesAsync();
        }

        
    }
}