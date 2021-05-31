using Server.Entities;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface IPerformers
    {
        Task<Performer> AddPerformer(PerfomerCreateDto perfomerCreateDto);
        Task<bool> DeletePerformer(Guid performerId);
        Task<List<Performer>> GetAllPerformers();
        Task<Performer> GetPerformer(Guid performerId);
        Task<bool> UpdatePerformer(Guid performerId, PerfomerCreateDto perfomerCreateDto);
    }
}