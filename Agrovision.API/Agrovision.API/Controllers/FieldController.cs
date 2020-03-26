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
    public class FieldController : ControllerBase
    {
        private readonly IFieldService _fieldService;

        public FieldController(IFieldService fieldService)
        {
            _fieldService = fieldService;
        }

        [HttpGet]
        public async Task<IEnumerable<FieldCM>> GetAsync()
        {
            var result = await _fieldService.GetFieldListAsync();
            var fieldList = TypeMapper.MapMany<Field, FieldCM>(result);
            return fieldList;
        }
        
        [HttpGet("{id}")]
        public async Task<FieldCM> GetAsync(int id)
        {
            var result = await _fieldService.GetFieldAsync(id);
            var agent = TypeMapper.MapSingle<Field, FieldCM>(result);
            return agent;
        }
        
        [HttpPost]
        public async Task AddAsync([FromBody] FieldCM agent)
        {
            var input = TypeMapper.MapSingle<FieldCM, Field>(agent);
            await _fieldService.AddFieldAsync(input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _fieldService.DeleteFieldAsync(id);
        }

        [HttpPut]
        public async Task UpdateAsync([FromBody] FieldCM agent)
        {
            var input = TypeMapper.MapSingle<FieldCM, Field>(agent);
            await _fieldService.UpdateFieldAsync(input);
        }
    }
}