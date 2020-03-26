using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Agrovision.Dto;

namespace Agrovision.Service.Interfaces
{
    public interface ISprayerService
    {
        Task<List<Sprayer>> GetSprayerListAsync();
        Task AddSprayerAsync(Sprayer sprayer);
        Task DeleteSprayerAsync(int id);
        Task UpdateSprayerAsync(Sprayer sprayer);
        Task<Sprayer> GetSprayerAsync(int id);
    }
}