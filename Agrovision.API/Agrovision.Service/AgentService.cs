using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agrovision.Data;
using Agrovision.Dto;
using Agrovision.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Agrovision.Service
{
    public class AgentService : IAgentService
    {
        private readonly SprayCalcDbContext _dbContext;

        public AgentService(SprayCalcDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Agent>> GetAgentListAsync()
        {
            return await _dbContext.Agents.AsNoTracking().Select(s => s).ToListAsync();
        }

        public async Task<Agent> GetAgentAsync(int id)
        {
            return await _dbContext.Agents.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAgentAsync(Agent agent)
        {
            await _dbContext.Agents.AddAsync(agent);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAgentAsync(int id)
        {
            var itemToDelete = await _dbContext.Agents.FirstOrDefaultAsync(s => s.Id == id);

            if (itemToDelete == null) return;
            _dbContext.Agents.Remove(itemToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAgentAsync(Agent agent)
        {
            _dbContext.Agents.Update(agent);
            await _dbContext.SaveChangesAsync();
        }
    }
}