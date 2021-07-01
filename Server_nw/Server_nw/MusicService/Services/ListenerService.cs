using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_nw.MusicApplication.Services
{
    public class ListenerService : IListenerService
    {
        private readonly MusicServiceDbContext _db;
        private readonly ILogger<ListenerService> _logger;

        public ListenerService(MusicServiceDbContext db,
            ILogger<ListenerService> logger)
        {
            _db = db;
            _logger = logger;
        }
        public async Task<bool> AttachMusicSong(Guid listenerId, Guid songId)
        {
            var listener = await _db.Listeners.FirstOrDefaultAsync(c => c.UserId == listenerId);

            var song = await _db.Songs.FirstOrDefaultAsync(c => c.SongId == songId);

            if (listener == null || song == null) return false;

            listener.Songs.Add(song);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }

        public async Task<bool> AttachAlbum(Guid listenerId, Guid albumId)
        {
            var listener = await _db.Listeners.FirstOrDefaultAsync(c => c.UserId == listenerId);

            var album = await _db.Albums.FirstOrDefaultAsync(c => c.AlbumId == albumId);

            if (listener == null || album == null) return false;

            listener.Albums.Add(album);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }
    }
}
