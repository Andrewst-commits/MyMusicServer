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
    public class UsersInMS_SQL_ServerRepository : IUsers
    {
        private readonly MusicServerDbContext _db;
        private readonly ILogger<UsersInMS_SQL_ServerRepository> _logger;

        public UsersInMS_SQL_ServerRepository(MusicServerDbContext db,
            ILogger<UsersInMS_SQL_ServerRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        /// <summary>
        /// Извлекаем пользователя из базы данных по id
        /// </summary>
        public async Task<UserDto> GetUserAsync(int id)
        {
            await Task.CompletedTask;
            UserDto userDto = new UserDto(_db.Users.FirstOrDefault(c => c.UserId == id));
        }


        /// <summary>
        /// Посылаем пользователю информацию через Dto-объект
        /// </summary>
        public async Task<UserDto> GetUserDtoAsync(int id)
        {
            await Task.CompletedTask;
            var user = _db.Users.FirstOrDefault(c => c.UserId == id);
            UserDto userDto = new UserDto(user);

            return userDto;
        }

        /// <summary>
        /// Добавляем нового пользователя
        /// </summary>
        public async Task<User> AddUserAsync(string name, string surname,
            string lastName, DateTime birthDate)
        {
            var user = new User()
            {
                Name = name,
                Surname = surname,
                LastName = lastName,
                BirthDate = birthDate,
               
            };

            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return user;
        }

        /// <summary>
        /// Изменяем параметры пользователя по id
        /// </summary>
        public async Task<bool> PutUserAsync(int id, string newName, string newSurname,
            string newLastName, DateTime newBrthDate)
        {
            var user = await GetUserAsync(id);
            if (user == null)
            {
                return false;
            }

            user.Name = newName;
            user.Surname = newSurname;
            user.LastName = newLastName;
            user.BirthDate = newBrthDate;
         

            return true;
        }

        /// <summary>
        /// Удаляем пользователя по id
        /// </summary>
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await GetUserAsync(id);
            if (user == null)
            {
                return false;
            }

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }

    }
}
