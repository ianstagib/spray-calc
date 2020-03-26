using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Agrovision.API.Controllers.ClientModels;
using Agrovision.Dto;
using Agrovision.Helpers;
using Agrovision.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Agrovision.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [HttpGet]
        public async Task<IEnumerable<AgentCM>> GetAsync()
        {
            var result = await _agentService.GetAgentListAsync();
            var agentList = TypeMapper.MapMany<Agent, AgentCM>(result.ToList());
            return agentList;
        }
        
        [HttpGet("{id}")]
        public async Task<AgentCM> GetAsync(int id)
        {
            var result = await _agentService.GetAgentAsync(id);
            var agent = TypeMapper.MapSingle<Agent, AgentCM>(result);
            return agent;
        }

        [HttpPost]
        public async Task AddAsync([FromBody] AgentCM agent)
        {
            var input = TypeMapper.MapSingle<AgentCM, Agent>(agent);
            await _agentService.AddAgentAsync(input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _agentService.DeleteAgentAsync(id);
        }

        [HttpPut]
        public async Task UpdateAsync([FromBody] AgentCM agent)
        {
            var input = TypeMapper.MapSingle<AgentCM, Agent>(agent);
            await _agentService.UpdateAgentAsync(input);
        }
    }
}