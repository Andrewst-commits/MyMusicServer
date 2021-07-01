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
    public class AlbumInMsSQlServerRepository : IAlbum
    {
        private readonly MusicServiceDbContext _db;
        private readonly ILogger<AlbumInMsSQlServerRepository> _logger;

        public AlbumInMsSQlServerRepository(MusicServiceDbContext db,
            ILogger<AlbumInMsSQlServerRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<List<Album>> GetAllAlbums()
        {
            await Task.CompletedTask;
            return _db.Albums.Where(c => c.IsDeleted == false).ToList();
        }

        public async Task<Album> GetAlbum(Guid id)
        {
            var albums = await _db.Albums.ToListAsync();

            var album = albums.FirstOrDefault(c => c.AlbumId == id && c.IsDeleted == false);

            if (album == null) return null;

            return album;
        }

        public async Task<Album> AddAlbum(AlbumCreateDto albumCreateDto)
        {
            var album = albumCreateDto.ToEntity();

            await _db.Albums.AddAsync(album);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return album;
        }

        public async Task<bool> UpdateAlbum(Guid id, AlbumCreateDto albumCreateDto)
        {
            var album = await _db.Albums.FirstOrDefaultAsync(c => c.AlbumId == id);

            if (album == null) return false;

            album = albumCreateDto.ToEntity();

            _db.Albums.Update(album);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }

        public async Task<bool> DeleteAlbum(Guid id)
        {
            var album = await _db.Albums.FirstOrDefaultAsync(c => c.AlbumId == id);

            if (album == null) return false;

            album.IsDeleted = true;

            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }

        public async Task<bool> AttachMusicSong(Guid albumId, Guid songId)
        {
            var album = await _db.Albums.FirstOrDefaultAsync(c => c.UserId == albumId);

            var song = await _db.Songs.FirstOrDefaultAsync(c => c.SongId == songId);

            if (album == null || song == null) return false;

            album.Songs.Add(song);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }

        public async Task<List<Album>> GetAllDeletedAlbums()
        {
            await Task.CompletedTask;
            return _db.Albums.Where(a => a.IsDeleted == true).ToList();
        }

        public async Task<bool> RestoreAlbum(Guid id)
        {
            var album = await _db.Albums.FirstOrDefaultAsync(a => a.AlbumId == id);

            if (album == null) return false;

            album.IsDeleted = false;

            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }

    }
}
