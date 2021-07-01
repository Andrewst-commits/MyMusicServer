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
    public class UsersInMsSqlServerRepository : IUsers
    {
        private readonly MusicServerDbContext _db;
        private readonly ILogger<UsersInMsSqlServerRepository> _logger;

        public UsersInMsSqlServerRepository(MusicServerDbContext db,
            ILogger<UsersInMsSqlServerRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<List<Account>> GetAllUsers()
        {
            await Task.CompletedTask;
            return _db.Users.Include(c => c.Songs).Where(c => c.IsDeleted == false).ToList();
        }

        public async Task<Account> GetUser(Guid id)
        {
            var users = await _db.Users.Include(c => c.Songs).ToListAsync();

            var user = users.FirstOrDefault(c => c.UserId == id && c.IsDeleted == false);

            if (user == null) return null;

            return user;
        }

        private async Task<bool> AttachMusicPerformer(Guid userId, Guid performerId)
        {
            var user = await _db.Users.FirstOrDefaultAsync(c => c.UserId == userId);

            var performer = await _db.Performers.FirstOrDefaultAsync(c => c.PerformerId == performerId);

            if (user == null || performer == null) return false;

            user.Performers.Add(performer);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }


        public async Task<bool> AttachMusicSong(Guid userId, Guid songId)
        {
            var user = await _db.Users.FirstOrDefaultAsync(c => c.UserId == userId);

            var song = await _db.Songs.FirstOrDefaultAsync(c => c.SongId == songId);

            if (user == null || song == null) return false;

            await AttachMusicPerformer(userId, song.PerformerId);

            user.Songs.Add(song);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }
    }
}


