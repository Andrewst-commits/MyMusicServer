using Microsoft.AspNetCore.Mvc;
using Server.Entities;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface IUsers
    {
        Task<UserDto> GetUserDtoAsync(int id);
        Task<UserDto> AddUserAsync(string name, string surname,
            string lastName, DateTime birthDate);
        Task<bool> PutUserAsync(int id, string newName, string newSurname,
            string newLastName, DateTime newBrthDate);
        Task<bool> DeleteUserAsync(int id);
    }
}
