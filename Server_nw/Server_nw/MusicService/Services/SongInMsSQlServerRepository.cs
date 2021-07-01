using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Server_nw.MusicApplication.Entities;
using Server_nw.MusicService.DtoModels.CreateDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.MusicApplication.Services
{
    public class SongInMsSQlServerRepository : ISong
    {
        private readonly MusicServiceDbContext _db;
        private readonly ILogger<SongInMsSQlServerRepository> _logger;

        public SongInMsSQlServerRepository(MusicServiceDbContext db,
            ILogger<SongInMsSQlServerRepository> logger)
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

        public async Task<Song> AddSong(SongCreateDto songCreateDto)
        {
            var song = songCreateDto.ToEntity();

            await _db.Songs.AddAsync(song);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return song;
        }

        public async Task<bool> UpdateSong(Guid id, SongCreateDto songCreateDto)
        {
            var song = await _db.Songs.FirstOrDefaultAsync(c => c.SongId == id);

            if (song == null) return false;

            song = songCreateDto.ToEntity();

            _db.Songs.Update(song);
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

        public async Task<List<Song>> GetAllDeletedSongs()
        {
            await Task.CompletedTask;
            return _db.Songs.Where(c => c.IsDeleted == true).ToList();
        }

        public async Task<bool> RestoreSong(Guid id)
        {
            var song = await _db.Songs.FirstOrDefaultAsync(s => s.SongId == id);

            if (song == null) return false;

            song.IsDeleted = false;

            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }


    }
}
