using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.MusicApplication.Services
{
    public class BandService : IBandService
    {
        private readonly MusicServiceDbContext _db;
        private readonly ILogger<BandService> _logger;

        public BandService(MusicServiceDbContext db,
            ILogger<BandService> logger)
        {
            _db = db;
            _logger = logger;
        }
        public async Task<bool> AttachMusicSong(Guid bandId, Guid songId)
        {
            var band = await _db.Bands.FirstOrDefaultAsync(c => c.UserId == bandId);

            var song = await _db.Songs.FirstOrDefaultAsync(c => c.SongId == songId);

            if (band == null || song == null) return false;

            band.Songs.Add(song);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }

        public async Task<bool> AttachAlbum(Guid bandId, Guid albumId)
        {
            var band = await _db.Bands.FirstOrDefaultAsync(c => c.UserId == bandId);

            var album = await _db.Albums.FirstOrDefaultAsync(c => c.AlbumId == albumId);

            if (band == null || album == null) return false;

            band.Albums.Add(album);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }
    }
}
