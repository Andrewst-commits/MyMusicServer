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

        public async Task<List<User>> GetAllUsers()
        {
            await Task.CompletedTask;
            return _db.Users.Where(c => c.IsDeleted == false).ToList();
        }

        public async Task<User> GetUser(Guid id)
        {
            var users = await _db.Users.Include(c => c.Performers).ToListAsync();

            var user = users.FirstOrDefault(c => c.UserId == id && c.IsDeleted == false);

            if (user == null) return null;

            return user;
        }

        public async Task<User> AddUser(UserCreateDto userCreateDto)
        {
            var user = await userCreateDto.ToEntity();

            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return user;
        }

        public async Task<bool> UpdateUser(Guid id, UserCreateDto userCreateDto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(c => c.UserId == id);

            if (user == null) return false;

            user = await userCreateDto.ToEntity();

            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }


        public async Task<bool> DeleteUser(Guid id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(c => c.UserId == id);

            if (user == null) return false;

            user.IsDeleted = true;
     
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }

        public async Task<bool> AttachMusicPerformer(Guid userId, Guid performerId)
        {
            var user = await _db.Users.FirstOrDefaultAsync(c => c.UserId == userId);

            var performer = await _db.Performers.FirstOrDefaultAsync(c => c.PerformerId == performerId);

            if (user == null || performer == null) return false;

            user.Performers.Add(performer);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }
    }
}


