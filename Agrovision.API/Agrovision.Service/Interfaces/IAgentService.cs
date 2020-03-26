using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Agrovision.Dto;

namespace Agrovision.Service.Interfaces
{
    public interface IAgentService
    {
        Task<IEnumerable<Agent>> GetAgentListAsync();
        Task AddAgentAsync(Agent input);
        Task DeleteAgentAsync(int id);
        Task UpdateAgentAsync(Agent agent);
        Task<Agent> GetAgentAsync(int id);
    }
}