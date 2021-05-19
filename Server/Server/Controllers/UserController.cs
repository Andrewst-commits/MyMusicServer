using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Entities;
using Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsers _users;
        private readonly ILogger<UserController> _logger;

        public UserController(IUsers users, ILogger<UserController> logger)
        {
            _users = users;
            _logger = logger;
        }

        /// <summary>
        /// Получить пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <response code = "200"> Пользователь найден </response>
        /// <response code = "404"> Пользователь не найден </response>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> GetUserByIdAsync(int id)
        {
            var user = await _users.GetUserDtoAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        /// <summary>
        /// Добавить нового пользователя
        /// </summary>
        /// <param name="name"> Имя</param>
        /// <param name="surname"> Фамилия</param>
        /// <param name="lastName"> Отчество</param>
        /// <param name="birthDate"> Дата рождения</param>
        /// <response code = "200"> Пользователь успешно добавлен </response>
        /// <response code = "500"> Ошибка сервера </response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> AddUserAsync(string name, string surname,
            string lastName, DateTime birthDate)
        {
            var user = await _users.AddUserAsync(name, surname, lastName, birthDate);
            return Ok(user);
        }


        /// <summary>
        /// Изменить информацию о пользователе
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newName"></param>
        /// <param name="newSurname"></param>
        /// <param name="newLastName"></param>
        /// <param name="newBrthDate"></param>
        /// <response code = "200"> Информация успешно обновлена </response>
        /// <response code = "404"> Пользователь не найден </response>
        /// <response code = "500"> Ошибка сервера </response>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> UpdateUserInfAsync(int id, string newName, string newSurname,
            string newLastName, DateTime newBrthDate)
        {
            var IsUpdated = await _users.PutUserAsync(id, newName, newSurname, newLastName, newBrthDate);
            return IsUpdated ? Ok() : NotFound();
        }

        /// <summary>
        ///  Удалить пользователя
        /// </summary>
        /// <param name="id"> </param>
        /// <response code = "200"> Пользователь удален </response>
        /// <response code = "404"> Пользователь не найден </response>
        /// <response code = "500"> Ошибка сервера </response>
        /// <returns></returns>   
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> DeleteUserByIdAsync(int id)
        {
            var isDeleted = await _users.DeleteUserAsync(id);
            return isDeleted ? Ok() : NotFound();
        }

    }
}
