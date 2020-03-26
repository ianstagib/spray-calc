using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Agrovision.Dto;

namespace Agrovision.Service.Interfaces
{
    public interface IFieldService
    {
        Task<List<Field>> GetFieldListAsync();
        Task AddFieldAsync(Field input);
        Task DeleteFieldAsync(int id);
        Task UpdateFieldAsync(Field input);
        Task<Field> GetFieldAsync(int id);
    }
}