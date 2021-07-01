using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.MusicApplication.Services
{
    public class PerformerService : IPerformerService
    {
        private readonly MusicServiceDbContext _db;
        private readonly ILogger<PerformerService> _logger;

        public PerformerService(MusicServiceDbContext db,
            ILogger<PerformerService> logger)
        {
            _db = db;
            _logger = logger;
        }
        public async Task<bool> AttachMusicSong(Guid performerId, Guid songId)
        {
            var performer = await _db.Performers.FirstOrDefaultAsync(c => c.UserId == performerId);

            var song = await _db.Songs.FirstOrDefaultAsync(c => c.SongId == songId);

            if (performer == null || song == null) return false;

            performer.Songs.Add(song);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }

        public async Task<bool> AttachAlbum(Guid performerId, Guid albumId)
        {
            var performer = await _db.Performers.FirstOrDefaultAsync(c => c.UserId == performerId);

            var album = await _db.Albums.FirstOrDefaultAsync(c => c.AlbumId == albumId);

            if (performer == null || album == null) return false;

            performer.Albums.Add(album);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }
    }
}
