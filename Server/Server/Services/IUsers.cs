using Server.Entities;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface IUsers
    {
        Task<User> AddUser(UserCreateDto userCreateDto);
        Task<bool> AttachMusicPerformer(Guid userId, Guid performerId);
        Task<bool> DeleteUser(Guid id);
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(Guid id);
        Task<bool> UpdateUser(Guid id, UserCreateDto userCreateDto);
    }
}