using System;
using System.Collections.Generic;
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
    public class SprayerController : ControllerBase
    {
        
        private readonly ISprayerService _sprayerService;

        public SprayerController(ISprayerService sprayerService)
        {
            _sprayerService = sprayerService;
        }

        [HttpGet]
        public async Task<IEnumerable<SprayerCM>> GetAsync()
        {
            var result = await _sprayerService.GetSprayerListAsync();
            var fieldList = TypeMapper.MapMany<Sprayer, SprayerCM>(result);
            return fieldList;
        }
        
        [HttpGet("{id}")]
        public async Task<SprayerCM> GetAsync(int id)
        {
            var result = await _sprayerService.GetSprayerAsync(id);
            var agent = TypeMapper.MapSingle<Sprayer, SprayerCM>(result);
            return agent;
        }
        
        [HttpPost]
        public async Task AddAsync([FromBody] SprayerCM agent)
        {
            var input = TypeMapper.MapSingle<SprayerCM, Sprayer>(agent);
            await _sprayerService.AddSprayerAsync(input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _sprayerService.DeleteSprayerAsync(id);
        }

        [HttpPut]
        public async Task UpdateAsync([FromBody] SprayerCM agent)
        {
            var input = TypeMapper.MapSingle<SprayerCM, Sprayer>(agent);
            await _sprayerService.UpdateSprayerAsync(input);
        }
    }
}