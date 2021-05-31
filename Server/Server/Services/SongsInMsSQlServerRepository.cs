using Microsoft.AspNetCore.Mvc;
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
    public class SongsInMsSQlServerRepository : ISongs
    {
        private readonly MusicServerDbContext _db;
        private readonly ILogger<UsersInMsSqlServerRepository> _logger;

        public SongsInMsSQlServerRepository(MusicServerDbContext db,
            ILogger<UsersInMsSqlServerRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<List<Song>> GetAllSongs()
        {
            await Task.CompletedTask;
            return _db.Songs.Where(c => c.IsDeleted == false).ToList();
        }

        public async Task<Song> GetSong(Guid id)
        {
            var songs = await _db.Songs.ToListAsync();

            var song = songs.FirstOrDefault(c => c.SongId == id && c.IsDeleted == false);

            if (song == null) return null;

            return song;
        }

        public async Task<bool> AddSong(SongCreateDto songCreateDto)
        {
            var performer = await _db.Performers.FirstOrDefaultAsync(c => c.PerformerId == songCreateDto.PerformerIdDto);

            if (performer == null) return false;

            var song = await songCreateDto.ToEntity();

            await _db.Songs.AddAsync(song);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }

        public async Task<bool> UpdateSong(Guid id, SongCreateDto songCreateDto)
        {
            var song = await _db.Songs.FirstOrDefaultAsync(c => c.SongId == id);

            if (song == null) return false;


            var performer = await _db.Performers.FirstOrDefaultAsync(c => c.PerformerId == songCreateDto.PerformerIdDto);

            if (performer == null) return false;


            song = await songCreateDto.ToEntity();

            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }

        public async Task<bool> DeleteSong(Guid id)
        {
            var song = await _db.Songs.FirstOrDefaultAsync(c => c.SongId == id);

            if (song == null) return false;

            song.IsDeleted = true;

            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }
    }
}

