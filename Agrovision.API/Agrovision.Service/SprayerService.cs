using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Agrovision.Data;
using Agrovision.Dto;
using Agrovision.Helpers;
using Agrovision.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Agrovision.Service
{
    public class SprayerService : ISprayerService
    {
        private readonly SprayCalcDbContext _dbContext;

        public SprayerService(SprayCalcDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async  Task<List<Sprayer>> GetSprayerListAsync()
        {
            return await _dbContext.Sprayers.ToListAsync();
        }
        
        public async Task<Sprayer> GetSprayerAsync(int id)
        {
            return await _dbContext.Sprayers.FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task AddSprayerAsync(Sprayer sprayer)
        {
            await _dbContext.Sprayers.AddAsync(sprayer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSprayerAsync(int id)
        {
            var itemToDelete = await _dbContext.Sprayers.FirstOrDefaultAsync(x => x.Id == id);
            
            if (itemToDelete == null) return;
            
            _dbContext.Sprayers.Remove(itemToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateSprayerAsync(Sprayer sprayer)
        {
            _dbContext.Sprayers.Update(sprayer);
            await _dbContext.SaveChangesAsync();
        }

        
    }
}