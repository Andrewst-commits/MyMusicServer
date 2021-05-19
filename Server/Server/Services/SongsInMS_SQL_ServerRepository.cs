
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Context;
using Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class SongsInMS_SQL_ServerRepository : ISongs
    {
        private readonly MusicServerDbContext _db;
        private readonly ILogger<UsersInMS_SQL_ServerRepository> _logger;

        public SongsInMS_SQL_ServerRepository(MusicServerDbContext db,
            ILogger<UsersInMS_SQL_ServerRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<Song> AddSongAsync(string title, int duration,
            DateTime productionDate, int performerId)
        {
            var song = new Song()
            {
                Title = title,
                Duration = duration,
                ProductionDate = productionDate,
                PerformerId = performerId
            };

            await _db.Songs.AddAsync(song);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return song;
        }

        public async Task<bool> DeleteSongAsync(int id)
        {
            var song = await GetSongAsync(id);

            if(song == null)
            {
                return false;
            }

            _db.Songs.Remove(song);
            return true;
        }

        public async Task<Song> GetSongAsync(int id)
        {
            await Task.CompletedTask;
            return _db.Songs.FirstOrDefault(c => c.SongId == id);
        }

        public async Task<bool> PutSongAsync(int id, string newTitle, int newDuration,
            DateTime newProductionDate, int newPerformerId)
        {
            var song = await GetSongAsync(id);
            if (song == null)
            {
                return false;
            }

            song.Title = newTitle;
            song.Duration = newDuration;
            song.ProductionDate = newProductionDate;
            song.PerformerId = newPerformerId;
        

            return true;
        }
    }
}
