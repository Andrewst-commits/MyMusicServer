using Microsoft.Extensions.Logging;
using Server.Context;
using Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class PerformersInMS_SQL_ServerRepository : IPerformers
    {
        private readonly MusicServerDbContext _db;
        private readonly ILogger<UsersInMS_SQL_ServerRepository> _logger;

        public PerformersInMS_SQL_ServerRepository(MusicServerDbContext db,
            ILogger<UsersInMS_SQL_ServerRepository> logger)
        {
            _db = db;
            _logger = logger;
        }
        public async Task<Performer> AddPerformerAsync(string name, string surname,
            string lastName, DateTime birthDate)
        {
            var performer = new Performer()
            {
                Name = name,
                Surname = surname,
                LastName = lastName,
                BirthDate = birthDate
            };

            await _db.Performers.AddAsync(performer);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return performer;
        }

        public async Task<bool> DeletePerformerAsync(int id)
        {
            var performer = await GetPerformerAsync(id);

            if (performer == null)
            {
                return false;
            }

            _db.Performers.Remove(performer);
            return true;
        }

        public async Task<Performer> GetPerformerAsync(int id)
        {
            await Task.CompletedTask;
            return _db.Performers.FirstOrDefault(c => c.PerformerId == id);
        }

        public async Task<bool> PutPerformerAsync(int id, string newName, string newSurname,
            string newLastName, DateTime newBirthDate)
        {
            await Task.CompletedTask;
            return true;
        }
    }
}
