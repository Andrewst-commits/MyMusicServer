using Server.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface IUsers
    {
        Task<bool> AttachMusicSong(Guid userId, Guid songId);
        Task<List<Account>> GetAllUsers();
        Task<Account> GetUser(Guid id);
    }
}