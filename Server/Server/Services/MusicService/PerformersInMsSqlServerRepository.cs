using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Server.Context;
using Server.Entities;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class PerformersInMsSqlServerRepository : IPerformers
    {
        MusicServerDbContext _db;
        ILogger<PerformersInMsSqlServerRepository> _logger;

        public PerformersInMsSqlServerRepository(MusicServerDbContext db,
            ILogger<PerformersInMsSqlServerRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<List<Performer>> GetAllPerformers()
        {
            await Task.CompletedTask;
            return _db.Performers.Where(c => c.IsDeleted == false).Include(c => c.Songs).ToList();
        }

        public async Task<Performer> GetPerformer(Guid id)
        {
            var performers = await _db.Performers.Include(c => c.Songs).ToListAsync();

            var performer = performers.FirstOrDefault(c => c.PerformerId == id && c.IsDeleted == false);

            if (performer == null) return null;

            return performer;
        }

        public async Task<Performer> AddPerformer(PerfomerCreateDto perfomerCreateDto)
        {
            var performer = await perfomerCreateDto.ToEntity();

            await _db.Performers.AddAsync(performer);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return performer;
        }

        public async Task<bool> UpdatePerformer(Guid id, PerfomerCreateDto perfomerCreateDto)
        {
            var performer = await _db.Performers.FirstOrDefaultAsync(c => c.PerformerId == id);

            if (performer == null) return false;

            performer = await perfomerCreateDto.ToEntity();

            _db.Performers.Update(performer);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }

        public async Task<bool> DeletePerformer(Guid id)
        {
            var performer = await _db.Performers.FirstOrDefaultAsync(c => c.PerformerId == id);

            if (performer == null) return false;

            performer.IsDeleted = true;

            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }

    }
}
